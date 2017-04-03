using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fader : Monobehaviour {
	[HideInInspector]
	public bool SceneStarted = false;
	[HideInInspector]
	public float fadeDamp = 0.0f;
	[HideInInspector]
	public string fadeScene;
	[HideInInspector]
	public float alpha = 0.0f;
	[HideInInspector]
	public Color fadeColor;
	[HideInInspector]
	public bool isFadeIn = false;

	//Create callback
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	//Remove callback
	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	//Create a texture, color it, fade it away
	void OnGUI () {
	//Fallback check
		if (!start)
			return;
	//Assign color with alpha variable
	GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
	//Temporary texture
	Texture2D myTexture;
	myTexture = new Texture2D(1,1);
	myTexture.SetPixel(0,0,fadeColor);
	myTexture.Apply ();
	//Print Texture to be the size of the screen, whatever that may be
	GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), myTexture);
	//Fade in & out
	if (isFadeIn)
		alpha = Mathf.Lerp (alpha, -0.1f, fadeDamp * Time.deltaTime);
	else
		alpha = Mathf.Lerp (alpha, 1.1f, fadeDamp * Time.deltaTime);
	//Load New Scene
	if (alpha >= 1 && !isFadeIn) {
		SceneManager.LoadScene(fadeScene);
		DontDestroyOnLoad(gameObject);
		} else
		if (alpha <= 0 && isFadeIn) {
		Destroy(gameObject);
		}
	}
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		isFadeIn = true;
	}	
}	