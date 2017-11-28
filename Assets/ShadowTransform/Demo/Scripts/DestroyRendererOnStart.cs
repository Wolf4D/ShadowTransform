using UnityEngine;
using System.Collections;

public class DestroyRendererOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject.GetComponent<Renderer>());
	}

}
