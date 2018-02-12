///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2018.
//
// All rights reserved.
// Under BSD-3-Clause License.
// So, use it as you wish, just don't remove this credits.
/////////////////////////////
//
// This script is for zone, which makes object to catch fire and be removed
// after some time.
//
// This script takes object after collision, drops an instance of prepared
// object to it, and then destroys it after some time. Nice and simple!
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ObjectDestroyerZone : MonoBehaviour
{
    public GameObject detonatorEffect; // effect for BOOM and fire
    public float destroyTime = 1.5f;   // time before destroying an object

    void OnTriggerEnter(Collider target)
    {
        if (target!=null)
            if (!target.gameObject.isStatic) // we will not destroy a static objects
            {
                // let's make a new instance of BOOM&fire effect
                GameObject tmp = Instantiate (detonatorEffect, target.transform) as GameObject;

                // set a right position of our new effect
                tmp.transform.position = target.transform.position;
                tmp.transform.rotation = target.transform.rotation;

                // launch a timed destruction for an object
                Destroy (target.transform.gameObject, destroyTime);
            }
    }
}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////
