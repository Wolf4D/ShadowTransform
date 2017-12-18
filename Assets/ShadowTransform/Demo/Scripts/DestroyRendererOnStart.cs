///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// This class just destroys object's renderer at level start.
// Used for drawing zones which should not be visible in editor
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class DestroyRendererOnStart : MonoBehaviour
{
    void Start ()
    {
        Destroy(this.gameObject.GetComponent<Renderer>());
    }

}

///////////////////////////////////////////////////////////////////////////////
