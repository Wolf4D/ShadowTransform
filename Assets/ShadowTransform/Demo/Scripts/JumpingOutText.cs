using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;

public class JumpingOutText : MonoBehaviour {

	private Text text;
	public int maxSize = 60;
	public bool isWin = false;

	void Start () {
		text = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {

		if (text.fontSize < maxSize)
			text.fontSize += 1;
		else if (Input.anyKeyDown) {
			if (!isWin)
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			else {
				if (EditorApplication.isPlaying) {
					Debug.Log ("Game over!\nYou win!");
					EditorApplication.isPlaying = false;
				}
				else
				Application.Quit ();
			}
		}
	}
}

