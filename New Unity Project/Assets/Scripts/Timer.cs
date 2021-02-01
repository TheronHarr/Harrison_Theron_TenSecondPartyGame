using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer = 0f;
    Text timerText;

    
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + Mathf.Round(timer);
    }
    
    void FixedUpdate()
    {
        if (timer >= 10)
        {
            Time.timeScale = 0;
            GetComponent<AudioSource>().Play();
        }
    }
}
