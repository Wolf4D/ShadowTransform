using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class Test1 : MonoBehaviour {


	void Awake()
	{
		//Debug.Log ("123");
		SceneTourWindow w = ScriptableObject.CreateInstance<SceneTourWindow>();
		w.Show ();
	}

}
