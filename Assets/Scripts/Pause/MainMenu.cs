using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject options;
    public GameObject tutorial;

    public void Play()
    {
        SceneManager.LoadScene("level");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        options.SetActive(true);
    }
    public void CloseOptions()
    {
        options.SetActive(false);
    }


    public void OpenTutorial()
    {
        tutorial.SetActive(true);
    }
    public void CloseTutorial()
    {
        tutorial.SetActive(false);
    }
}
