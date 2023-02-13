using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float currentTime = 0; // seconds
    public bool track = true;
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        if (track)
        {
            timeText.text = "" + (int)currentTime;
            currentTime += 1f * Time.deltaTime;
        }
    }
}
