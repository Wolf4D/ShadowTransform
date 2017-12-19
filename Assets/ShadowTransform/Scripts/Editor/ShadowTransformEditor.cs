///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// Editor class for ShadowTransform.
// Contains some Unity Editor UI hacks, cause normally
// you shouldn't change data in OnInspectorGUI.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEditor;

///////////////////////////////////////////////////////////////////////////////

[CustomEditor(typeof(ShadowTransform))]
public class ShadowTransformEditor : Editor
{

    [SerializeField] ShadowTransform shadow; // editor's ShadowTransform object
    int oldShadowID = -1;                    // last selected state id
    int selectedShadowID = -1;               // currently selected state id
    string newPhantomName = "Base state";    // new state's name

    // Unity Editor UI is a very complex thing. For example, OnInspectorGUI
    // method is called on each changes multiple times - one time for Layout
    // event, and one time for Redraw event. And if you make something during
    // Layout which makes extra buttons to appear (or existing buttons to
    // disappear), your Redraw event may throw at you a nasty error.
    // This is a problem of Unity, and it's a counter-intuitive thing.
    // So, my solution is not perfect, but useful. We'll just ignore first
    // Repaint event(s) after any crucial changes.

    int doNotRepaintTimes = 0;   // number of times to ignore Repaint

///////////////////////////////////////////////////////////////////////////////

    void Awake()
    {
        shadow = (ShadowTransform)this.target;
        selectedShadowID = shadow.CurrentPhantom ();
    }

///////////////////////////////////////////////////////////////////////////////

    public override void OnInspectorGUI()
    {
        // Ignoring Repaint event, as said before
        if ((Event.current.type == EventType.Repaint) && (doNotRepaintTimes > 0))
        {
            doNotRepaintTimes--;
            return;
        }

        // No editor for static in runtime,
        // cause you can't move static in runtime
        if ((shadow.gameObject.isStatic && Application.isPlaying))
        {
            EditorGUILayout.HelpBox ("Sorry, operations with static objects are not avalible in play mode!", MessageType.Warning, true);
            return;
        }

        // Style for drawing caption
        GUIStyle styleCenter = new GUIStyle (GUI.skin.label);
        styleCenter.alignment = TextAnchor.MiddleCenter;

        selectedShadowID = shadow.CurrentPhantom ();
        if (selectedShadowID<0) // write state's name if selected
            newPhantomName = GUILayout.TextField(newPhantomName);

        // Let's draw a list of states
        if (shadow.phantoms.Count > 0)
        {
            string[] tst = new string[shadow.phantoms.Count];
            for (int i = 0; i < shadow.phantoms.Count; i++)
                tst [i] = shadow.phantoms [i].name + " (" + i + ")";

            EditorGUILayout.LabelField ("State:", styleCenter);
            selectedShadowID = EditorGUILayout.Popup ("", selectedShadowID, tst);
        }

        // If no states are present - text would be outputed
        if (shadow.phantoms.Count ==0)
            EditorGUILayout.LabelField ("No saved shadow states", styleCenter);

        // A big layout for lower buttons
        EditorGUILayout.BeginHorizontal ();

        // If list is not empty - let's draw switch buttons
        if (shadow.phantoms.Count > 0)
            if (GUILayout.Button ("<<"))
            {
                // Adding an undo state
                Undo.RegisterFullObjectHierarchyUndo(((ShadowTransform)this.target).gameObject, "changing a shadow state");

                // Scrolling through 0
                if (selectedShadowID <= 0)
                    selectedShadowID = shadow.phantoms.Count-1;
                else
                    selectedShadowID--;
            }

        // If no state is selected - let's give our user a button to add state
        if (selectedShadowID<0)
            if (GUILayout.Button ("+"))
            {
                Undo.RegisterFullObjectHierarchyUndo(((ShadowTransform)this.target).gameObject, "adding a shadow state");

                // Skip next repaint
                //if (shadow.phantoms.Count == 0)
                    doNotRepaintTimes = 1;

                shadow.AddPhantom(newPhantomName);
            }

        //Color newShadowColor = new Color (0.6f, 0.15f, 0.7f, 0.4f);
        //newShadowColor = EditorGUILayout.ColorField (newShadowColor);

        // If state is selected - let's make a button to remove state
        if (shadow.phantoms.Count > 0)
            if 	(selectedShadowID>=0)
                if (GUILayout.Button ("-"))
                {
                    // New undo state
                    Undo.RegisterFullObjectHierarchyUndo(((ShadowTransform)this.target).gameObject, "deleting a shadow state");
                    shadow.DeletePhantom ();
                    selectedShadowID--;

                    // Skip next repaint
                    //if (shadow.phantoms.Count == 0)
                        doNotRepaintTimes = 1;
                }


        // Another scroll arrow
        if (shadow.phantoms.Count > 0)
            if (GUILayout.Button (">>"))
            {
                // New undo state
                Undo.RegisterFullObjectHierarchyUndo(((ShadowTransform)this.target).gameObject, "changing a shadow state");
                if (selectedShadowID >= shadow.phantoms.Count-1)
                    selectedShadowID = 0;
                else
                    selectedShadowID++;
            }

        // End of layout
        EditorGUILayout.EndHorizontal ();

        // If we have changed shadow ID, let's switch ShadowTransform
        // of object to selected
        if (selectedShadowID != oldShadowID)
            shadow.SwitchToPhantom (selectedShadowID);

        oldShadowID = selectedShadowID;

    }

///////////////////////////////////////////////////////////////////////////////

    // Adding component through context menu
    [MenuItem("CONTEXT/Transform/Add Shadow Transform")]
    static void AddShadowTransform(MenuCommand command)
    {
        Transform targetTransform = (Transform)command.context;
        if (targetTransform != null)
        {
            if (!targetTransform.gameObject.GetComponent<ShadowTransform> ()) {
                //targetTransform.gameObject.AddComponent<PhantomTransform> ();
                Undo.AddComponent<ShadowTransform> (targetTransform.gameObject);
                ShadowTransform shadowtr = targetTransform.gameObject.GetComponent<ShadowTransform> ();

                // Move new component up to Transform
                for(int i=0; i<targetTransform.gameObject.GetComponents<Component>().Length; i++)
                    UnityEditorInternal.ComponentUtility.MoveComponentUp(shadowtr);
            }
            else
                Debug.LogWarning ("This GameObject (" + targetTransform.gameObject.name +") already has one shadow transform!");
        }

    }

}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////
