using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShadowState
{
	public string name = "";
	public Vector3 position;
	public Vector3 eulerAngles;
	public Vector3 lossyScale;
};

public class PhantomTransform : MonoBehaviour {

	[SerializeField] public List<ShadowState> phantoms = new List<ShadowState>();
	public Color shadowColor = new Color (0.6f, 0.15f, 0.7f, 0.4f);

	// Use this for initialization
	void Awake () {
		if (this.gameObject.GetComponents<PhantomTransform> ().Length > 1) {
			Debug.LogWarning ("This GameObject (" + this.gameObject.name +") already has one shadow transform!");
			Destroy (this);
		}
		//(Material)Resources.Load("ShadowTransformMaterial");
		//Destroy (this);		//На старте игры - отключаем все фантомы!!!
	}

	public void AddPhantom(string pname)
	{
		ShadowState newShadow = new ShadowState ();

		newShadow.name = pname + " (" + phantoms.Count + ")";
		newShadow.position = this.gameObject.transform.position;
		newShadow.eulerAngles = this.gameObject.transform.eulerAngles;
		//Debug.Log (newShadow.eulerAngles);

		Transform cparent = this.gameObject.transform.parent;
		this.gameObject.transform.SetParent (null);
		newShadow.lossyScale = this.gameObject.transform.lossyScale;
		this.gameObject.transform.SetParent (cparent);

		//добавить сюда гизмо
		//скрыть дочерний фантом из дерева
		phantoms.Add (newShadow);

		// вызовем принудительно, чтобы отрисовать гизмо
		EditorUtility.SetDirty(this);

	}

	public void SwitchToPhantom(int id)
	{
		if ((id >= 0) && (id < phantoms.Count)) {
			this.transform.position = phantoms [id].position;
			this.transform.rotation = Quaternion.Euler (phantoms [id].eulerAngles);

			Transform cparent = this.transform.parent;
			this.transform.SetParent (null);
			this.transform.localScale = phantoms[id].lossyScale;
			this.gameObject.transform.SetParent (cparent);
		}
	}

	public void DeletePhantom()
	{
		//удаляем фантом из массива
		//переключаемся на другой фантом
		//удаляем объект фантома
		phantoms.Remove(phantoms[CurrentPhantom()]);

		EditorUtility.SetDirty(this);
	}

	public int CurrentPhantom()
	{
		int current = -1;
			foreach (ShadowState obj in phantoms) 
			if (obj!=null)
			{
				if ((obj.position == this.transform.position) &&
				    (obj.eulerAngles == this.transform.eulerAngles) &&
				    (obj.lossyScale == this.transform.lossyScale))
					current = phantoms.LastIndexOf (obj);
			}
			
		return current;
	}


	void OnDrawGizmos()
	{
		Gizmos.color = shadowColor;
		//Handles.color = Color.white;
		MeshFilter meshFilter = this.GetComponent<MeshFilter> ();
		foreach (ShadowState obj in phantoms) {
			if (!(this.gameObject.isStatic && Application.isPlaying))
			{
			if (meshFilter!=null)
				Gizmos.DrawMesh (meshFilter.sharedMesh, obj.position, Quaternion.Euler (obj.eulerAngles), obj.lossyScale);
			else
				Debug.LogWarning ("This GameObject (" + this.gameObject.name +") has no MeshFilters!\nThis version won't draw nested meshes - no shadow objects will be drawn.");
			}

			//if (!Application.isPlaying)
			//{
			Vector3 objInView = Camera.current.WorldToViewportPoint (obj.position);
			if ((objInView.x>=0) && (objInView.x<=1) && (objInView.y>=0) && (objInView.y<=1) && (objInView.z>0))
				Handles.Label (obj.position, this.gameObject.name + "\n" + obj.name);
			//}
			//else
			//	Handles.Label (obj.position, this.gameObject.name + "\n" + obj.name);
			//Gizmos.DrawIcon (obj.position, "shadowtransformicon.png");
		}
	}
		
}
