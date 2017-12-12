using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerAtUI : MonoBehaviour {

	private Text text;
	public string timerText;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		text.text = timerText + Time.timeSinceLevelLoad + " sec";

	}
}
