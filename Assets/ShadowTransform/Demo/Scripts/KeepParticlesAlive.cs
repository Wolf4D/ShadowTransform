using UnityEngine;
using System.Collections;

public class KeepParticlesAlive : MonoBehaviour {
	public float timer = 6.0f;
	// Use this for initialization
	void OnDestroy()
	{
		ParticleSystem[] part;
		part = GetComponentsInChildren<ParticleSystem>();

		foreach (ParticleSystem ps in part)
		{
			ps.transform.parent = null;
			ps.gameObject.AddComponent<Rigidbody> ();
			Destroy(ps.gameObject, timer);
		}
	}
}
