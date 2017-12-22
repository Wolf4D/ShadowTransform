///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// This class activates some object at destruction of this script.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ActivateOnDestroy : MonoBehaviour
{
    public GameObject objectToActivate;

    void OnDestroy()
    {
        if (objectToActivate!=null)
            objectToActivate.SetActive (true);
    }
}

///////////////////////////////////////////////////////////////////////////////
