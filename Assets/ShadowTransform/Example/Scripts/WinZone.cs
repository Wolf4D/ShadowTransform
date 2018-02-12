///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2018.
//
// All rights reserved.
// Under BSD-3-Clause License.
// So, use it as you wish, just don't remove this credits.
/////////////////////////////
//
// That's a script for a win zone. After object comes to this zone, script
// must start a winning sequence - show a text, stop player's timer, and begin
// to rise object up to the sky!
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour
{
    private GameObject targetObject;   // object to be lifted up to the sky
    public  GameObject winTextObject;  // object with a congratulations text
    public  GameObject timerObject;    // object which contains player's timer

    void FixedUpdate()
    {
        if (targetObject != null)  // when object is assigned, just lift it up!
            targetObject.transform.position = new Vector3 (targetObject.transform.position.x,
                                                           targetObject.transform.position.y + 0.1f,
                                                           targetObject.transform.position.z);
    }

    void OnTriggerEnter(Collider target)
    {
        // TODO: if we may have some other object at the finish,
        // you may need to check that it's a player.

        if (target!=null)
            if (!target.gameObject.isStatic)
            {
                targetObject = target.gameObject;

                // now object is under control of uplifting code
                targetObject.GetComponent<Rigidbody> ().isKinematic = true;

                // now it's time to show congratulations and stop timer
                winTextObject.SetActive (true);
                timerObject.GetComponent<TimerAtUI>().enabled = false;
            }
    }
}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////

