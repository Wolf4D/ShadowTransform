using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShadowTransformSlave : MonoBehaviour {

	public PhantomTransform ParentShadowTransform;

	// Use this for initialization
	void Awake () {
		Destroy (this);
	}

	public void Init(PhantomTransform newParent, string pname)
	{
		this.transform.position = newParent.transform.position;
		this.transform.eulerAngles = newParent.transform.eulerAngles;

		Transform cparent = newParent.transform.parent;
		newParent.gameObject.transform.SetParent (null);
		this.transform.localScale = newParent.transform.localScale;
		newParent.transform.SetParent (cparent);

		Component[] components;
		components = this.GetComponentsInChildren<Component> ();

		foreach (Component cmp in components) 
		{
			if ((cmp.GetComponent<Renderer> () != cmp)
				&& (cmp.GetComponent<Transform> () != cmp)
				&& (cmp.GetComponent<MeshFilter> () != cmp)
				&& (cmp!=this)) 
				DestroyImmediate (cmp);
		}

		this.name = newParent.name + " (shadow " + pname + ")";

		Renderer[] renderers;
		renderers = this.GetComponentsInChildren<Renderer> ();

		foreach (Renderer rend in renderers) 
			rend.material = (Material)Resources.Load("ShadowTransformMaterial");

		this.GetComponent<Renderer> ().material = (Material)Resources.Load("ShadowTransformMaterial");

		//this.hideFlags = HideFlags.HideInInspector;
		//this.gameObject.hideFlags = HideFlags.HideInHierarchy;

		ParentShadowTransform = newParent;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = new Color (1.0f, 0, 0, 0.2f);
		Gizmos.DrawCube (new Vector3(0,0, 0), transform.localScale * 3.0f);
	}
	

}
