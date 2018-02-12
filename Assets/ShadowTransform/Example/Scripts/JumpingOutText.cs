///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2018.
//
// All rights reserved.
// Under BSD-3-Clause License.
// So, use it as you wish, just don't remove this credits.
/////////////////////////////
//
// This class controls a jumping-out text. That's a "You win/lose" text here.
// Idea is simple - when activated, script will scale size of the text to
// the max, and later control the next player's actions.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;

//public
class JumpingOutText : MonoBehaviour
{
    private Text text;         // text component for... err... jump out
    public int maxSize = 60;   // upper limit for a text size
    public bool isWin = false; // is this a win text?

    void Start ()
    {
        text = GetComponent<Text>();
    }

    void Update ()
    {
        // if size is not maximal - let's increase it
        if (text.fontSize < maxSize)
            text.fontSize += 1;
        else if (Input.anyKeyDown)  // now waiting for user input
        {
            if (!isWin) // for lose text - just restarting the scene
                SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
            else
            {
                // for win - let's stop the game
                if (EditorApplication.isPlaying)
                {
                    Debug.Log ("Game over!\nYou win!");
                    EditorApplication.isPlaying = false;
                }
                else
                    Application.Quit ();
            }
        }
    }
}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////
