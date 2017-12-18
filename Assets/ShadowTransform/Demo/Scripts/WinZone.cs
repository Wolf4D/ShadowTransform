using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour {
	
	private GameObject targetObject;
	public  GameObject winObject;
	public  GameObject timerObject;
	private  TimerAtUI timer;

	void Start()
	{
		timer = timerObject.GetComponent<TimerAtUI> ();
	}

	void FixedUpdate()
	{
		if (targetObject != null) {
				targetObject.transform.position = new Vector3 (targetObject.transform.position.x,
					targetObject.transform.position.y +  0.1f, 
					targetObject.transform.position.z);

		}
	}

	void OnTriggerEnter(Collider target)
	{
		if (target!=null)
		if (!target.gameObject.isStatic) {
			targetObject = target.gameObject;
			targetObject.GetComponent<Rigidbody> ().isKinematic = true;
			winObject.SetActive (true);
			timer.enabled = false;
		}
		//Debug.Log (target);
	}
}
