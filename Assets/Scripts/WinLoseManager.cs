using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseManager : MonoBehaviour
{
    public Image winLose;
    public Text condition;
    public TimeAndScore tas;

    public AudioSource clickSound;
    public AudioSource music;
    public AudioSource winMusic;
    public AudioSource loseMusic;
    public Color winColor;
    public Color loseColor;
    void Start()
    {
        winLose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win()
    {
        winLose.gameObject.SetActive(true);
        Time.timeScale = 0f;
        winLose.color = winColor;
        tas.BestTime();
        condition.text = "YOU WIN";
        music.Stop();
        winMusic.Play();
    }
    public void Lose()
    {
        winLose.gameObject.SetActive(true);
        Time.timeScale = 0.5f;
        winLose.color = loseColor;
        condition.text = "YOU LOSE";
        music.Stop();
        loseMusic.Play();
    }

    
     public void Buttons(int destination)
    {
        clickSound.Play();
        SceneManager.LoadScene(destination);
    } 
}
