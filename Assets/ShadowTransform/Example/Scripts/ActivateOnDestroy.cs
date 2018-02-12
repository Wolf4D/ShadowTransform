///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2018.
//
// All rights reserved.
// Under BSD-3-Clause License.
// So, use it as you wish, just don't remove this credits.
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
