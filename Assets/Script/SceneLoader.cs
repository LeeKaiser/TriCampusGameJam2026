using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public AudioClip travelSound;

    public void LoadNextScene(int sceneIndex)
    {
        StartCoroutine(loadLevel(sceneIndex));
    }   

    IEnumerator loadLevel(int sceneIndex)
    {
        transition.SetTrigger("Start");
        GetComponent<AudioSource>().PlayOneShot(travelSound);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
