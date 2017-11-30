using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class Test2 : MonoBehaviour {
	public bool ShowTour;

	void Awake()
	{
		CheckTourState ();
	}

	void CheckTourState()
	{
		if (PlayerPrefs.GetInt ("ShadowTransform/HideTour") != 1)
			ShowTour = true;
		else
			ShowTour = false;
	}

	void OnValidate()
	{
		//if (PlayerPrefs.GetInt("ShadowTransform/HideTour")!=1)
		if (ShowTour)
		if (!Application.isPlaying)  {
			//Debug.Log ("123");
			SceneTourWindow w = EditorWindow.GetWindow<SceneTourWindow> ();
			w.Show ();
			//DestroyImmediate (this);
			//this.enabled = false;
		}
		ShowTour = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
