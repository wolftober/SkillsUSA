using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDies : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text gameoverText;
    public GameObject playAgain;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            // game over / reset

            // stopping time and getting the end score
            timeText.GetComponent<Score>().track = false;
            
            int finalScore = (int) timeText.GetComponent<Score>().currentTime;

            // game over text
            gameoverText.text = "Game Over! \n You stayed alive for " + finalScore + " seconds.";

            // turning on the play again button
            playAgain.SetActive(true);
        }
    }

}
