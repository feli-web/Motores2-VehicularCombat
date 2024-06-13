using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
    public Image objective;
    public Image settingsImage;
    public Image instructionsImage;
    public Button[] mainButtons;
    AudioSource clickSound;
    public void Start()
    {
        Time.timeScale = 1f;
        objective.gameObject.SetActive(false);
        clickSound = GetComponent<AudioSource>();
        mainButtons[4].gameObject.SetActive(false);
        instructionsImage.gameObject.SetActive(false);
        settingsImage.gameObject.SetActive(false);
    }
    public void Play()
    {
        clickSound.Play();
        objective.gameObject.SetActive(true);
        Invoke("APlay", 1f);
    }
    public void Settings()
    {
        clickSound.Play();

        settingsImage.gameObject.SetActive(true);

        mainButtons[0].gameObject.SetActive(false);
        mainButtons[1].gameObject.SetActive(false);
        mainButtons[2].gameObject.SetActive(false);
        mainButtons[3].gameObject.SetActive(false);
        mainButtons[4].gameObject.SetActive(true);
    }
    public void Quit()
    {
        Invoke("AQuit", 3f);
        Application.Quit();
    }
    public void Instructions()
    {
        clickSound.Play();

        instructionsImage.gameObject.SetActive(true);
        
        mainButtons[0].gameObject.SetActive(false);
        mainButtons[1].gameObject.SetActive(false);
        mainButtons[2].gameObject.SetActive(false);
        mainButtons[3].gameObject.SetActive(false);
        mainButtons[4].gameObject.SetActive(true);
    }
    public void Back()
    {
        clickSound.Play();

        instructionsImage.gameObject.SetActive(false);
        settingsImage.gameObject.SetActive(false);
        mainButtons[0].gameObject.SetActive(true);
        mainButtons[1].gameObject.SetActive(true);
        mainButtons[2].gameObject.SetActive(true);
        mainButtons[3].gameObject.SetActive(true);
        mainButtons[4].gameObject.SetActive(false);
    }

    void APlay()
    {
        SceneManager.LoadScene(1);
    }
    void AQuit()
    {
        Application.Quit();
    }
}
