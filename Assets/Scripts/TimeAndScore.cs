using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndScore : MonoBehaviour
{
    
    float timer = 0;
    public Text timerText;
    public Text currentTime;
    public Text bestTime;
    void Start()
    {
        currentTime.gameObject.SetActive(false);
        bestTime.gameObject.SetActive(false);
        //PlayerPrefs.SetFloat("CurrentTime", 0);
        //PlayerPrefs.SetFloat("BestTime", 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("F2");
        PlayerPrefs.SetFloat("CurrentTime",timer);
    }
    public void BestTime()
    {
        currentTime.gameObject.SetActive(true);
        bestTime.gameObject.SetActive(true);
        float cTime = PlayerPrefs.GetFloat("CurrentTime", 0);
        float bTime = PlayerPrefs.GetFloat("BestTime", 0);
        currentTime.text = "Current time: " + cTime.ToString("F2");
        bestTime.text = "Best time: " + bTime.ToString("F2");
        if (PlayerPrefs.GetFloat("BestTime")  == 0) 
        {
            PlayerPrefs.SetFloat("BestTime", cTime);    
        }
        if (PlayerPrefs.GetFloat("BestTime")  > cTime) 
        {
            PlayerPrefs.SetFloat("BestTime", cTime);
        }
    }
    
}
