using UnityEngine;
using System.Collections;

public class BallBreaks : MonoBehaviour {

	float oldDrag;
	float oldADrag;

	// Use this for initialization
	void Start () {
		oldDrag = this.GetComponent<Rigidbody> ().drag;
		oldADrag = this.GetComponent<Rigidbody> ().angularDrag;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftAlt)) {
			this.GetComponent<Rigidbody> ().drag = oldDrag * 5.0f;
			this.GetComponent<Rigidbody> ().angularDrag = oldADrag * 5.0f;		
		}

		if (Input.GetKeyUp (KeyCode.LeftAlt)) {
			this.GetComponent<Rigidbody> ().drag = oldDrag;
			this.GetComponent<Rigidbody> ().angularDrag = oldADrag;		
		}

	}
}
