///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// Class to control the UI timer.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerAtUI : MonoBehaviour
{
    private Text text;          // text UI component for timer
    public string timerText;    // additional text before the time in UI

    void Start () {
        text = GetComponent<Text> ();
    }

    void FixedUpdate () {
        text.text = timerText + Time.timeSinceLevelLoad + " sec";
    }
}

///////////////////////////////////////////////////////////////////////////////
