using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public GameObject howtoplay;
    public GameObject about;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HowToPlay()
    {
        howtoplay.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void About()
    {
        about.SetActive(true);
    }

    public void Back()
    {
        about.SetActive(false);
        howtoplay.SetActive(false);
    }
}
