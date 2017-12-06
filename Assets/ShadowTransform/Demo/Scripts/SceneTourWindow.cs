﻿using UnityEngine;
using UnityEditor;


[System.Serializable]
public class TourStages
{
	public TourStages(string ctitle, string cmainText, Vector3 cposition, Vector3 ceulerAngles, bool cplay=false) 
	{
		title = ctitle;
		mainText = cmainText;
		cposition = position;
		ceulerAngles = eulerAngles;
		playTest = cplay;
	}

	public string title = "";
	public string mainText = "";
	public Vector3 position;
	public Vector3 eulerAngles;
	public bool playTest = false;
};


public class SceneTourWindow : EditorWindow {
	bool doNotShowAnymore = false;
	TourStages[] stages = new TourStages[9];

	int currentStage = 0;


	void Awake()
	{
		currentStage = 8;
		this.titleContent = new GUIContent("Quick tutorial");
		this.minSize = new Vector2 (410,220);

		stages [0] = new TourStages ("Welcome to ShadowTransform Tutorial!\n", 
			"Thank you for downloading our product.\n\n" +
		"This window will guide you throught our great <b>10 steps tour</b>.\n" +
		"We will show you main capabilities of our <b>ShadowTransform</b>.\n\n" +
		"P.S. You can return to this tutorial any time you want using <b><i>''Launch tutorial''</i></b> object in this scene.", new Vector3 (), new Vector3 ());

		stages [1] = new TourStages ("1. What is ShadowTransform?", 
			"\n<b>ShadowTransform</b> is a tool to make process of creation and tweaking your levels more comfortable.\n\n" +
			"It will <b>remember previous positions</b> for any of your objects and let you <b>switch between them</b> in one click.\n\n" +
			"<b><i>Just move your object without fear of loosing its old perfect position.</i></b>\n" +
			"Our ShadowTransform will take care of this for you!", new Vector3 (), new Vector3 ());

		stages [2] = new TourStages ("2. Usage of ShadowTransform", 
			"\nOkay, let's take a look at this scene.\n" +
			"Consider this as a level of some jumping arcade game.\n\n" +
			"This level is still <b>in the middle of tweaking process</b> - we've made some experimental changes in player's physics " +
			"to make gameplay more interesting.\n\nIt is a good time to make a play-test.\n<b>Press >> to try this level out!</b>", new Vector3 (), new Vector3 ());

		stages [3] = new TourStages ("3. Play!", 
			"\nWe think, you <b>won't</b> get to the landing pad, marked with yellow light.\n\n\n\n\n<b>But that's ok.</b> " +
			"Latest experimetal tweaks made this part of our level totally unpassable.", new Vector3 (), new Vector3 (), true);

		stages [4] = new TourStages ("4. Various variants", 
			"\nBut two of our designers, <b><i>Alice</i></b> and <b><i>Bob</i></b>, has proposed their own fixes. " +
			"That variants are stored by <b>ShadowTransform</b>.\n" +
			"<b>To test both of them, just:</b> \n\n" +
			"<b>1)</b> Select a <b>LandingPad object</b>,\n" +
			"<b>2)</b> Find a <b>Shadow Transform</b> among its components,\n" +
			"<b>3)</b> Switch between saved variants using <b><< or >> buttons</b>.\n\n" +
			"Try our gameplay with each of the variants!", new Vector3 (), new Vector3 ());

		stages [5] = new TourStages ("5. What's this..?", 
			"\nBoth of variants were remembered by <b>ShadowTransform</b>.\n" +
			"\nJust one click, and <b>object's position, rotation and scale</b> will return back in time to some previous state.\n" +
			"Also, you can select desired state using <b>drop-down list</b>.\n\n\n" +
			"That's how you may <b>switch between saved object's states</b>.\n" +
			"And you may do this in Inspector even during play!" 
			, new Vector3 (), new Vector3 ());

		stages [6] = new TourStages ("6. ...and that purple things..?", 
			"\nThat misterious things are <b>visual representations</b> for remembered states. That things are called <b>shadows</b>." +
			"\n\nEach shadow is labeled by the <b>state's name</b> and <b>object's name</b>.\n" +
			"\nYou may <b>click</b> on a shadow to <b>select a corresponding object</b>.\n"
			, new Vector3 (), new Vector3 ());

		stages [7] = new TourStages ("7. Adding ShadowTransform to object", 
			"\nYou can easily add a new ShadowTransform to any of your GameObjects. Let's try this together on a <b>TooSmallPlatform</b>:\n\n" +
			"<b>1)</b> Select a <b>TooSmallPlatform object</b>,\n" +
			"<b>2)</b> Right-click at <b>Transform component</b> and select <i><b>Add Shadow Transform</b></i>.\n" +
			"\nSee new <b>ShadowTransform</b>? Now add a <b><i>base state</i></b>, change <b><i>Scale</i></b> by <b><i>X</i></b> to 10, and add an <b><i>another state</i></b>."
			, new Vector3 (), new Vector3 ());

		stages [8] = new TourStages ("8. Let's make some play-testing!", 
			"\nSelect a <b>RollerBall object</b> and switch its state to <b>''At the begining of the ladder''</b>.\n\n" +
			"<b>Ok.</b> Now play and try to pass through the <b>TooSmallPlatform</b>." +
			"\n\nSwitch its <b><i>state</i></b> to another and try to <b>play again</b>.\n" +
			"\nSee?\n<i>Play-testing a certain part of the level now is the easiest thing!</i>"
			, new Vector3 (), new Vector3 ());
		//+
		//"See that <b>purple things?</b> That's <b><i>object shadows</i></b> - a visual representations of objects saved states. " +
		//"They're labeled with state names. <i>You may select objects by clicking on them.</i>"
		/*
		ST умеет запоминать несколько положений объекта и переключать
		ся между ними.
		одним нажатием
		С ST Вы можете проводить плей-тесты, сравнивая
		эстетическое чувство подсказывает, что объект
		шобъект нужно чуть переместить, 
		Перемещая объекты, Вы боитесь потерять идеально рассчитанную начальную позицию? Теперь ST совозьмёт на себя заботы об этом
		Проектируйте уров
		Перепроектируйте уровни, перемещайте объекты, проводите плей-тесты различных ситуаций - ST поможет Вам!
		ShadowTransform is a nice tool to make creation and tweaking of your levels more comfortable.
		It remembers old 
		It can remember previous positions of your object and sw
		any of
		itch between them in one click.
		Just move your object
		without fear of loosing its 
		Now ShadowTransform will take care of this!
		for you
			Move, rotate and scale your scenery, monsters, player. Make a play-testing of different game situations. 
			a better one.
			and so on
			with a
			ShadowTransform will help you.
*/
	}

	/*
	 * show you a ShadowTransform's capabilities.

P.S. If you became too boored, you can end up your tour by closing this window. 
	 * 
	 * show you a ShadowTransform's capabilities.

P.S. If you became too boored, you can end up your tour by closing this window. 
	 * 
	 */

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

		GUILayout.BeginHorizontal ();

		if (GUILayout.Button ("<<")) 
			currentStage--;
		
		if (GUILayout.Button (">>")) {
			currentStage++;
			if (stages [currentStage].playTest)
			if (!EditorApplication.isPlaying)
				EditorApplication.isPlaying = true;
		}

		GUILayout.EndHorizontal ();

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
