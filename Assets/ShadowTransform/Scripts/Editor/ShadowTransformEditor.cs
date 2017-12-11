﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ShadowTransform))]
//[ExecuteInEditMode]
public class ShadowTransformEditor : Editor {

int oldShadow = -1;

int cselect = -1;
string newPhantomName = "Base state";
	[SerializeField]	ShadowTransform shadow;

void Awake()
{
    shadow = (ShadowTransform)this.target;
		cselect = shadow.CurrentPhantom ();
}

// Use this for initialization
public override void OnInspectorGUI()
{
		if ((shadow.gameObject.isStatic && Application.isPlaying)) {
			EditorGUILayout.HelpBox ("Sorry, operations with static objects are not avalible in play mode!", MessageType.Warning, true);
			return;
		}	
		//if (Event.current.type == EventType.Layout)
		//	return;

    GUIStyle styleCenter = new GUIStyle (GUI.skin.label);
    styleCenter.alignment = TextAnchor.MiddleCenter;



	//	if (shadow.phantoms.Count > 0)
	//		newPhantomName = "Alternative state";
		
   

    cselect = shadow.CurrentPhantom ();
    if 	(cselect<0)
			newPhantomName = GUILayout.TextField(newPhantomName);



    if (shadow.phantoms.Count > 0)
    {
        string[] tst = new string[shadow.phantoms.Count];
        for (int i = 0; i < shadow.phantoms.Count; i++)
				tst [i] = shadow.phantoms [i].name + " (" + i + ")";

        EditorGUILayout.LabelField ("State:", styleCenter);
        cselect = EditorGUILayout.Popup ("", cselect, tst);
    }

		if (shadow.phantoms.Count ==0)
			  EditorGUILayout.LabelField ("No saved shadow states", styleCenter);

			
    EditorGUILayout.BeginHorizontal ();

if (shadow.phantoms.Count > 0)
    if (GUILayout.Button ("<<")) {
        if (cselect <= 0)
            cselect = shadow.phantoms.Count-1;
        else
            cselect--;
    }

	if 	(cselect<0)
    if (GUILayout.Button ("+"))
        shadow.AddPhantom(newPhantomName);
   
		//Color newShadowColor = new Color (0.6f, 0.15f, 0.7f, 0.4f);
		//newShadowColor = EditorGUILayout.ColorField (newShadowColor);

if (shadow.phantoms.Count > 0)
if 	(cselect>=0)
    if (GUILayout.Button ("-"))
    {   
			shadow.DeletePhantom ();
			cselect--;
		}

if (shadow.phantoms.Count > 0)			
		if (GUILayout.Button (">>")) 
		{
			if (cselect >= shadow.phantoms.Count-1)
				cselect = 0;
			else
				cselect++;
		}

    EditorGUILayout.EndHorizontal ();

    if (cselect != oldShadow)
        shadow.SwitchToPhantom (cselect);

    oldShadow = cselect;

}
// Update is called once per frame
/*
                void OnValidate () {
                        Debug.Log ("535353");

                }
        */
void ButtonFunction1()
{
    Debug.Log ("2341");
}


	// Add a menu item called "Double Mass" to a Rigidbody's context menu.
	[MenuItem("CONTEXT/Transform/Add Shadow Transform")]
	static void AddShadowTransform(MenuCommand command)
	{
		Transform tmp = (Transform)command.context;
		if (tmp != null) 
		{
			if (!tmp.gameObject.GetComponent<ShadowTransform> ()) {
				//tmp.gameObject.AddComponent<PhantomTransform> ();
				Undo.AddComponent<ShadowTransform> (tmp.gameObject);
				ShadowTransform shadowtr = tmp.gameObject.GetComponent<ShadowTransform> ();
				for(int i=0; i<tmp.gameObject.GetComponents<Component>().Length; i++)
					UnityEditorInternal.ComponentUtility.MoveComponentUp(shadowtr);
			}
			else
				Debug.LogWarning ("This GameObject (" + tmp.gameObject.name +") already has one shadow transform!");
		}
		/*
		Rigidbody body = (Rigidbody)command.context;
		body.mass = body.mass * 2;
		Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
		*/
	}

}
