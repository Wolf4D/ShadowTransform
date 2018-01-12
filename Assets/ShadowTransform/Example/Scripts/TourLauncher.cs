///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// Class to provide our shiny tour a not-so-ugly launcher :)
// It holds state of dialog into EditorPrefs.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class TourLauncher : MonoBehaviour
{
    public bool ShowTour = false; // does this tour needs demonstration?

    // function for checking a saved tour state - true if tour not discarded
    bool CheckTourState()
    {
		if (EditorPrefs.GetInt ("ShadowTransform/HideTour", 0) == 0)
            return true;
        else
            return false;
    }

    void OnValidate()
    {
		if ((CheckTourState ()) || (ShowTour))
            if (!Application.isPlaying)
            {
                SceneTourWindow w = EditorWindow.GetWindow<SceneTourWindow> ();
                w.Show ();
            }

        ShowTour = false;
    }
}

///////////////////////////////////////////////////////////////////////////////