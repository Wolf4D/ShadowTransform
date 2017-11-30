using UnityEngine;
using UnityEditor;


[System.Serializable]
public class TourStages
{
	public TourStages(string ctitle, string cmainText, Vector3 cposition, Vector3 ceulerAngles) 
	{
		title = ctitle;
		mainText = cmainText;
		cposition = position;
		ceulerAngles = eulerAngles;
	}

	public string title = "";
	public string mainText = "";
	public Vector3 position;
	public Vector3 eulerAngles;
};


public class SceneTourWindow : EditorWindow {
	bool doNotShowAnymore = false;
	TourStages[] stages = new TourStages[2];

	int currentStage = 0;


	void Awake()
	{
		currentStage = 0;
		this.titleContent = new GUIContent("Quick tutorial");
		this.minSize = new Vector2 (410,220);

		stages [0] = new TourStages ("Welcome to ShadowTransform Tutorial!\n", "Thank you for downloading our product.\n\n" +
		"This window will guide you throught our great <b>3-minutes tour</b>.\n" +
		"We will show you main capabilities of our <b>ShadowTransform</b>.\n\n" +
		"P.S. You can return to this tutorial any time you want using <b><i>''Launch tutorial''</i></b> object in this scene.", new Vector3 (), new Vector3 ());

		stages [1] = new TourStages ("What is ShadowTransform?", "\n<b>ShadowTransform</b> is a tool to make process of creation and tweaking your levels more comfortable.\n\n" +
			"It will <b>remember previous positions</b> for any of your objects and let you <b>switch between them</b> in one click.\n\n" +
			"<b><i>Just move your object without fear of loosing its old perfect position.</i></b>\n" +
			"Our ShadowTransform will take care of this for you!", new Vector3 (), new Vector3 ());
	}

	void OnGUI()
	{
		
		GUILayout.BeginVertical ();
		EditorGUIUtility.labelWidth = EditorGUIUtility.currentViewWidth - 50;

		//	return;
		GUIStyle styleTitle = new GUIStyle (EditorStyles.boldLabel);
		styleTitle.alignment = TextAnchor.MiddleCenter;
		styleTitle.wordWrap = true;
		styleTitle.fontSize = 14;
		styleTitle.richText = true;

		GUIStyle styleMainText = new GUIStyle (EditorStyles.wordWrappedLabel);
		styleMainText.fontSize = 12;
		styleMainText.richText = true;
		styleMainText.stretchHeight = true;


		GUILayout.Label (stages[currentStage].title, styleTitle);
		GUILayout.Label (stages [currentStage].mainText, styleMainText);
		if (GUILayout.Button (">>")) 
		{
			currentStage++;
		}
		//Rect tst = new Rect (100, 350, 200, 200);
		doNotShowAnymore = EditorGUILayout.Toggle ("Close & do not show this window anymore", doNotShowAnymore, new GUILayoutOption[] {GUILayout.MaxWidth(500), GUILayout.Width(500), GUILayout.ExpandWidth(true)});
			
		if (doNotShowAnymore) {
			PlayerPrefs.SetInt ("ShadowTransform/HideTour", 1);
			this.Close ();
		}


		GUILayout.EndVertical ();
	}

	/*
	public Rect windowRect = new Rect (20, 20, 120, 50);

	void OnGUI()
	{
		windowRect = GUI.Window (0, windowRect, TestWindow, "Test Window");
	}

	void TestWindow(int windowID)
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Test"))
			print("Test!");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	*/
}
