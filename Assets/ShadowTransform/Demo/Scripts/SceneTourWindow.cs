///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// Class for Tutorial Tour window. A very tricky thing.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;

///////////////////////////////////////////////////////////////////////////////
// An additional class to save a tour stages.
// Needs to be serializable to be used properly.
[System.Serializable]
public class TourStages
{
    public TourStages(string ctitle, string cmainText, GameObject cfocusObject = null, bool cplay=false)
    {
        title = ctitle;
        mainText = cmainText;
        focusObject = cfocusObject;
        playTest = cplay;
    }

    public string title = "";             // tour screen title
    public string mainText = "";          // main text of the screen
    public GameObject focusObject;        // object for camera targeting
    public bool playTest = false;		  // start game at this state?
};

///////////////////////////////////////////////////////////////////////////////

public class SceneTourWindow : EditorWindow
{
	// Does this window needs to be hidden?
    bool doNotShowAnymore = false;

	// Stages (screens) of tour
    TourStages[] stages = new TourStages[12];

	// Current stage
    int currentStage = 0;

/////////////////////////////

	// Let's fill all data before showing our window
    void Awake()
    {
        this.titleContent = new GUIContent("Quick tutorial");
        this.minSize = new Vector2 (410,220);

		// Filling stages with text and config data before starting

        stages [0] = new TourStages ("Welcome to ShadowTransform Tutorial!\n",
                                     "Thank you for downloading our product.\n\n" +
                                     "This window will guide you throught our great <b>10 steps tour</b>.\n" +
                                     "We will show you main capabilities of our <b>ShadowTransform</b>.\n\n" +
                                     "P.S. You can return to this tutorial any time you want using <b><i>''Launch tutorial''</i></b> object in this scene.");

        stages [1] = new TourStages ("1. What is ShadowTransform?",
                                     "\n<b>ShadowTransform</b> is a tool to make process of creation and tweaking your levels more comfortable.\n\n" +
                                     "It will <b>remember previous positions</b> for any of your objects and let you <b>switch between them</b> in one click.\n\n" +
                                     "<b><i>Just move your object without fear of loosing its old perfect position.</i></b>\n" +
                                     "Our ShadowTransform will take care of this for you!", GameObject.Find("RollerBall"));

        stages [2] = new TourStages ("2. Usage of ShadowTransform",
                                     "\nOkay, let's take a look at this scene.\n" +
                                     "Consider this as a level of some jumping arcade game.\n\n" +
                                     "This level is still <b>in the middle of tweaking process</b> - we've made some experimental changes in player's physics " +
                                     "to make gameplay more interesting.\n\nIt is a good time to make a play-test.\n<b>Press >> to try this level out!</b>", GameObject.Find("JumpPad"));

        stages [3] = new TourStages ("3. Play!",
                                     "\nWe think, you <b>won't</b> get to the landing pad, marked with yellow light from the first trys.\n\n\n\n\n<b>But that's ok.</b> " +
                                     "Latest experimetal tweaks made this part of our level nearly unpassable.", null, true);

        stages [4] = new TourStages ("4. Switching between saved states",
                                     "\nBut two of our designers, <b><i>Alice</i></b> and <b><i>Bob</i></b>, has proposed their fixes. " +
                                     "That variants <b>(states)</b> stored by <b>ShadowTransform</b>.\n" +
                                     "<b>To test both of them, just:</b> \n\n" +
                                     "<b>1)</b> Select a <b>LandingPad object</b>.\n" +
                                     "<b>2)</b> Find a <b>Shadow Transform</b> among components.\n" +
                                     "<b>3)</b> Switch between states using <b><< or >> buttons</b>.\n\n" +
                                     "Try to pass this place with each of the variants!", GameObject.Find("LandingPad"));

        stages [5] = new TourStages ("5. What are states?",
                                     "\nBoth of that <b>states</b> were remembered by <b>ShadowTransform</b>.\n" +
                                     "\nJust one click, and <b>object's position, rotation and scale</b> will return to some previous state.\n" +
                                     "Also, you can select desired state using <b>drop-down list</b>.\n\n\n" +
                                     "That's how you may <b>switch between saved object's states</b>.\n" +
                                     "And you may do this in Inspector even during play!");

        stages [6] = new TourStages ("6. ...and that purple things..?",
                                     "\nThat misterious things are <b>visual representations</b> for remembered states. That things are called <b>shadows</b>." +
                                     "\n\nEach shadow is labeled by the <b>state's name</b> and <b>object's name</b>.\n" +
                                     "\nYou may <b>click</b> on a shadow to <b>select a corresponding object</b>.\n", GameObject.Find("CrateAtEntrance"));

        stages [7] = new TourStages ("7. Let's make some play-testing!",
                                     "\nSelect a <b>RollerBall object</b> and switch its state to <b>''At the begining of the ladder''</b>.\n\n" +
                                     "<b>Ok.</b> Now play and try to pass through the <b>next platform</b>." +
                                     "\n\nSwitch its <b><i>state</i></b> to another and try to <b>play again</b>.\n" +
                                     "\nSee?\n<i>Play-testing a certain part of the level now is the easiest thing!</i>", GameObject.Find("Ladder1"));

        stages [8] = new TourStages ("8. Adding ShadowTransform to object",
                                     "\nYou can easily add a new ShadowTransform to any of your GameObjects.\n" +
                                     "Let's try this together on a <b>TooSmallPlatform</b>:\n\n" +
                                     "<b>1)</b> Select a <b>TooSmallPlatform object</b>,\n" +
                                     "<b>2)</b> Right-click at <b>Transform component</b> and select <i><b>Add Shadow Transform</b></i>.\n" +
                                     "\nSee new <b>ShadowTransform</b>?", GameObject.Find("TooSmallPlatform"));

        stages [9] = new TourStages ("9. Adding new states",
                                     "\nHow to add a new state in object's <b>ShadowTransform</b>?\n\n" +
                                     "<b>1)</b> Change object's <b>position, rotation</b> or <b>scale</b>,\n" +
                                     "<b>2)</b> New input field will appear at the top of <b>ShadowTransform component</b>. " +
                                     "Enter here name for a new state.\n" +
                                     "<b>3)</b> Click on <b>+</b> button between arrows." +
                                     "\n\n<b>Try it!</b> Add a <b><i>base state</i></b> to <b>TooSmallPlatform</b>, " +
                                     "change <b><i>Scale</i></b> by <b><i>X</i></b> to 10, then add an <b><i>another state</i></b>.", GameObject.Find("TooSmallPlatform"));

        stages [10] = new TourStages ("10. Deleting saved state",
                                      "\nAnd, at last, if you don't need any of states anymore, you may delete it:\n\n" +
                                      "<b>1)</b> Switch to state you want to delete,\n" +
                                      "<b>2)</b> Click on <b>-</b> button between arrows.\n\n" +
                                      "After deleting a state, <b>ShadowTransform</b> will automatically switch to a previous one (if exists).", GameObject.Find("TooSmallPlatform"));

        stages [11] = new TourStages ("Thanks for choosing ShadowTransform!",
                                      "\nNow you know how to use <b>ShadowTransform</b> and ready to unleash its power in your projects!\n\n" +
                                      "<b>REMEMBER!</b> This asset is free for ANY LEGAL USAGE - just mention our asset in your credits, and write a small letter to us, please :)\n" +
                                      "Read a readme file for an additional info. If you need some help, advice or technical support, you may write to: Wolf4D@list.ru, Ivan Klenov, at your service :)");

       
    }

/////////////////////////////

	// Draw a window
    void OnGUI()
    {

        GUILayout.BeginVertical ();

		// For adjusting text label width to a window size (it's resizeble)
        EditorGUIUtility.labelWidth = EditorGUIUtility.currentViewWidth - 50;

		// Different styles for text fields
        GUIStyle styleTitle = new GUIStyle (EditorStyles.boldLabel);
        styleTitle.alignment = TextAnchor.MiddleCenter;
        styleTitle.wordWrap = true;
        styleTitle.fontSize = 14;
        styleTitle.richText = true;

        GUIStyle styleMainText = new GUIStyle (EditorStyles.wordWrappedLabel);
        styleMainText.fontSize = 12;
        styleMainText.richText = true;
        styleMainText.stretchHeight = true;

		// Title and main text labels
        GUILayout.Label (stages[currentStage].title, styleTitle);
        GUILayout.Label (stages [currentStage].mainText, styleMainText);

		// Control buttons
        GUILayout.BeginHorizontal ();

        if (GUILayout.Button ("<<")) 
		{
            currentStage--;

			// If we need to focus camera on a certain object - let's do it
            if (stages [currentStage].focusObject != null)
            {
                EditorGUIUtility.PingObject (stages [currentStage].focusObject);
                Selection.activeGameObject = stages [currentStage].focusObject;
                SceneView.lastActiveSceneView.FrameSelected ();
            }
        }

        if (GUILayout.Button (">>")) 
		{
            currentStage++;

			// Focusing camera
			if (stages [currentStage].focusObject != null)
            {
                EditorGUIUtility.PingObject (stages [currentStage].focusObject);
                Selection.activeGameObject = stages [currentStage].focusObject;
                SceneView.lastActiveSceneView.FrameSelected ();
            }

			// Launching game, if we need to do it
            if (stages [currentStage].playTest)
                if (!EditorApplication.isPlaying)
                    EditorApplication.isPlaying = true;


        }

        GUILayout.EndHorizontal ();

        // If someone does not want to see this window anymore
        doNotShowAnymore = EditorGUILayout.Toggle ("Close & do not show this window anymore", 
			doNotShowAnymore, new GUILayoutOption[] 
			{GUILayout.MaxWidth(500), GUILayout.Width(500), GUILayout.ExpandWidth(true)});

		// If so, let's write a parameter in playerprefs (not so good way, but...)
        if (doNotShowAnymore) 
		{
            PlayerPrefs.SetInt ("ShadowTransform/HideTour", 1);
            this.Close ();
        }
			
        GUILayout.EndVertical ();
    }

}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////
