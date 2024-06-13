using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public AudioSource clickSound;
    public Image pause;
    public Image settings;
    public Image instructions;
    void Start()
    {
        Time.timeScale = 1.0f;
        pause.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            pause.gameObject.SetActive(true);

            clickSound.Play();
        }
    }
    public void Resume()
    {
        pause.gameObject.SetActive(false);
        clickSound.Play();
        Time.timeScale = 1f;
    }
    public void Settings()
    {
        pause.gameObject.SetActive(false);
        clickSound.Play();
        settings.gameObject.SetActive(true);
    }
    public void Instructions()
    {
        pause.gameObject.SetActive(false);
        clickSound.Play();
        instructions.gameObject.SetActive(true);
    }
    public void Menu()
    {
        clickSound.Play();
        Invoke("AMenu", 0.5f);
        pause.gameObject.SetActive(false);
    }
    public void Back()
    {
        pause.gameObject.SetActive(true);
        instructions.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        clickSound.Play();
    }
    void AMenu()
    {
        SceneManager.LoadScene(0);
    }
}
