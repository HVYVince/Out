using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTick : MonoBehaviour {
    public int seconds;
    private int minutes;
    private int centiseconds;
    private TextMesh textMesh;

	// Use this for initialization
	void Awake () {
        textMesh = GetComponentInChildren<TextMesh>();
        minutes = seconds / 60;
        seconds %= 60;
        centiseconds = 60;
    }

    void Start()
    {
        if (minutes == 0 && seconds < 10)
            textMesh.text = String.Format("{0:00}", seconds) + ":" + String.Format("{0:00}", centiseconds);
        else
            textMesh.text = String.Format("{0:00}", minutes) + ":" + String.Format("{0:00}", seconds);
        StartCoroutine("Countdown");
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator Countdown()
    {
        String separator = ":";
        while (minutes > 0 || seconds > 0 || centiseconds > 0)
        {
            if (minutes == 0 && seconds < 10)
            {
                yield return new WaitForSeconds(0.01F);
                centiseconds--;
                if(centiseconds < 0)
                {
                    centiseconds = 59;
                    seconds--;
                }
                if (centiseconds < 30)
                    textMesh.text = String.Format("{0:00}", seconds) + separator + String.Format("{0:00}", centiseconds);
                else
                    textMesh.text = "";
            }
            else
            {
                yield return new WaitForSeconds(1);
                seconds--;
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                }
                textMesh.text = String.Format("{0:00}", minutes) + separator + String.Format("{0:00}", seconds);
            }
        }
    }
}
