using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject levelScreen;
    public GameObject mainScreen;
    public GameObject optionsScreen;
    public GameObject creditsScreen;

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        ContinueLoader loaders = FindObjectOfType<ContinueLoader>();
        SceneManager.LoadScene(loaders.sceneNumber);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void LevelsButton()
    {
        mainScreen.SetActive(false);
        levelScreen.SetActive(true);
    }

    public void CreditsButton()
    {
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
    
    public void CreditsBackButton()
    {
        mainScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void LevelSelectBackButton()
    {
        levelScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
    public void OptionsButton()
    {
        mainScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }
    public void OptionsBackButton()
    {
        mainScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // Level Loading
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene(8);
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadLevel9()
    {
        SceneManager.LoadScene(10);
    }
    public void LoadLevel10()
    {
        SceneManager.LoadScene(11);
    }
}
