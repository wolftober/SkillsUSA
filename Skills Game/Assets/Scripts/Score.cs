using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int currentTime = 0; // seconds
    public bool track = true;
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        while (track)
        {
            wait();
            currentTime++;
            timeText.text = "" + currentTime;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
}
