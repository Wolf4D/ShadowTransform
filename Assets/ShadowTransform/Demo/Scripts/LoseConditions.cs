using UnityEngine;
using System.Collections;

public class LoseConditions : MonoBehaviour {
	public GameObject demonstrator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		if (demonstrator!=null)
			demonstrator.SetActive (true);
	}
}
