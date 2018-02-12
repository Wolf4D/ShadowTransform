///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2018.
//
// All rights reserved.
// Under BSD-3-Clause License.
// So, use it as you wish, just don't remove this credits.
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
