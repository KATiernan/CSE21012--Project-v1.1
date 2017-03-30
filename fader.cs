using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	public Image FadeTo;
	public float fadespeed = 1.5f;
	public bool sceneStarted = true;

	void Awake()
	{
		FadeTo.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}

	void Update()
	{
	if(sceneStarted)
	StartScene();
	}
//start to transition from image to black
	void FadeToBlack()
	{
	FadeTo.color = Color.Lerp(FadeTo.color, Color.black, fadespeed * Time.deltaTime);
	}
//fades texture to black
	void StartScene()
	{
	FadetoBlack();
//checks if image is almost black
	if(FadeTo.color.a <= 0.95f)
	{
		FadeTo.color = Color.black;
		FadeTo.enabled = false;
//ends scene
		sceneStarted = false;
	}
    }

public void EndScene(int SceneNode)
    {
        sceneStarting = false;
        StartCoroutine("EndSceneRoutine", SceneNode);
    }

    public IEnumerator EndSceneRoutine(int SceneNode)
    {
        // Make sure the RawImage is enabled.

        FadeTo.enabled = true;
        do
        {
            // Start fading towards black.
            FadeToBlack();

            // If the screen is almost black...
            if (FadeImg.color.a >= 0.95f)
            {
                // ... reload the level
                SceneManager.LoadScene(SceneNumber);
                yield break;
            }
            else
            {
                yield return null;
            }
        }while (true);


    }
}