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
            gameObject.SetActive(false);

            // game over / reset

            // ========== Stop Spawning ==========


            // deleting all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }

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
