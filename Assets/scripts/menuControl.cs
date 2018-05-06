using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour {

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    public void playStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //gets next scene which is level 1
    }

    public void quit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void muteMusic()
    {
        audioSource.mute = !audioSource.mute;
    }
}
