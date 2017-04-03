using UnityEngine;
using System.Collections;

public class DemoScript : Monobehaviour {

	public string scene;
	public Color loadtocolor = Color.black;

	void OnGUI () {
		if (GUI.Button (new Rect (290, 250, 100, 30), "Start")) {
			Initiate.Fade(scene, loadtocolor, 0.5f);
		}
	}
}