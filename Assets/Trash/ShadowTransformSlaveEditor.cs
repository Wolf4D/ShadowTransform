using UnityEngine;
using System.Collections;
using UnityEditor;

//[ExecuteInEditMode]
[CustomEditor(typeof(ShadowTransformSlave))]
public class ShadowTransformSlaveEditor : Editor {

	/*
	// Use this for initialization
	void Start () {
		Debug.Log ("St");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Up");
	}

	void OnValidate()
	{
		Debug.Log ("Val");

	}
	*/

	public override void OnInspectorGUI()
	{
		//Debug.Log("1234");
	//	Selection.activeGameObject = ((ShadowTransformSlave) target).ParentShadowTransform.gameObject;
	//	EditorGUIUtility.PingObject (((ShadowTransformSlave) target).ParentShadowTransform);
		//Debug.Log ("inspector GUI");
	}
}
