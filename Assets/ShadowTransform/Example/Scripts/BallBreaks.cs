///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2018.
//
// All rights reserved.
// Under BSD-3-Clause License.
// So, use it as you wish, just don't remove this credits.
/////////////////////////////
//
// Small class for ball's breaks. That was made as standalone script to save
// an original Unity's control script for a ball unchanged.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class BallBreaks : MonoBehaviour
{
    float oldDrag;  // old drag value for ball
    float oldADrag; // old angular drag value for ball

    void Start ()
    {
        oldDrag = this.GetComponent<Rigidbody> ().drag;
        oldADrag = this.GetComponent<Rigidbody> ().angularDrag;
    }

    void Update ()
    {
        // Brakes on
        if (Input.GetKeyDown (KeyCode.LeftShift))
        {
            this.GetComponent<Rigidbody> ().drag = oldDrag * 5.0f;
            this.GetComponent<Rigidbody> ().angularDrag = oldADrag * 5.0f;
        }

        // Brakes off
        if (Input.GetKeyUp (KeyCode.LeftShift))
        {
            this.GetComponent<Rigidbody> ().drag = oldDrag;
            this.GetComponent<Rigidbody> ().angularDrag = oldADrag;
        }

    }
}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////
