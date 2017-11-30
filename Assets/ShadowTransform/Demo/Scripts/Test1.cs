using UnityEngine;
using UnityEditor;
using System.Collections;

//[ExecuteInEditMode]
public class Test1 : MonoBehaviour {


	void Awake()
	{
		if (!Application.isPlaying) {
			//Debug.Log ("123");
			SceneTourWindow w = EditorWindow.GetWindow<SceneTourWindow> ();
			w.Show ();
			//DestroyImmediate (this);
		}
	}

}
