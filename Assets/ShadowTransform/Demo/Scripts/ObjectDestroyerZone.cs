using UnityEngine;
using System.Collections;

public class ObjectDestroyerZone : MonoBehaviour {
	public GameObject detonatorEffect;
	public float timer = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider target)
	{
		if (target!=null)
		if (!target.gameObject.isStatic) {
			GameObject tmp = Instantiate (detonatorEffect, target.transform) as GameObject;
			tmp.transform.position = target.transform.position;
			tmp.transform.rotation = target.transform.rotation;

			Destroy (target.transform.gameObject, timer);
		}
		//Debug.Log (target);
	}
}
