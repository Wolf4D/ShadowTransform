using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JumpingOutText : MonoBehaviour {

	private Text text;
	public int maxSize = 60;

	void Start () {
		text = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {

			if (text.fontSize < maxSize)
				text.fontSize += 1;
			else
				Debug.Log ("Restart level!");

	}
}

