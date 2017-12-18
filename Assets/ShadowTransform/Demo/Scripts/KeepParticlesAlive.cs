///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// Simple script to make all child particle systems of object alive afer
// destruction of object. Just let's make that system independent, and
// let each of them have its own rigidbody for a beautiful visuals.
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class KeepParticlesAlive : MonoBehaviour
{
    public float timer = 6.0f; // time before particles destruction

    void OnDestroy()
    {
        // go and find all of child particle systems
        ParticleSystem[] part;
        part = GetComponentsInChildren<ParticleSystem>();

        // now let's detach each of them from parent,
        // add a rigidbody and prepare for destruction
        foreach (ParticleSystem ps in part)
        {
            ps.transform.parent = null;
            ps.gameObject.AddComponent<Rigidbody> ();
            Destroy(ps.gameObject, timer);
        }
    }
}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////
