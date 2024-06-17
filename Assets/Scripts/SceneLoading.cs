using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSound;

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
