using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    float time = 0f;
    public TMP_Text timerText;
    public TMP_Text finalText;

    public int limitTime = 15;

    private int timeShowed;

    public static bool GameIsFinished = false;

    void Start(){

        timerText.text = "0";

    }

    void Update()
    {
        //update the position

            
        time += Time.deltaTime;
        if (time >= limitTime) 
        {
            Time.timeScale = 0f;

        }
            timeShowed = (int)time;
            timerText.text = timeShowed.ToString();


    }
        
    

}
