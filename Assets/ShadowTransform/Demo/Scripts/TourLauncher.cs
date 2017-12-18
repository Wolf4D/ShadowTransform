///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// Class to provide our shiny tour a not-so-ugly launcher :)
// It holds state of dialog into PlayerPrefs, which is not a good way, but
// UnityEditor tools seems does not another good project-wise controls for
// a tool assets to keep a settings.
//
///////////////////////////////////////////////////////////////////////////////


using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class TourLauncher : MonoBehaviour
{
    public bool ShowTour; // does this tour needs demonstration?

    void Awake()
    {
        CheckTourState ();
    }

    // function for checking a saved tour state
    void CheckTourState()
    {
        if (PlayerPrefs.GetInt ("ShadowTransform/HideTour") != 1)
            ShowTour = true;
        else
            ShowTour = false;
    }

    void OnValidate()
    {
        if (ShowTour)
            if (!Application.isPlaying)
            {
                SceneTourWindow w = EditorWindow.GetWindow<SceneTourWindow> ();
                w.Show ();
            }

        ShowTour = false;
    }
}
