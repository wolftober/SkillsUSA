using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playAgain : MonoBehaviour
{
    public Button button;
    public GameObject player;
    public TMP_Text gameOverText;
    public GameObject playAgainButton;
    public TMP_Text timeText;
    public GameObject EnemySpawn;
    public GameObject returnToMenu;

    void Start()
    {
        Button b = button.GetComponent<Button>();
        b.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        /*
        player.SetActive(true);
        player.transform.position = new Vector3(0, 1.13f, 0);
        gameOverText.text = "";
        playAgainButton.SetActive(false);
        returnToMenu.SetActive(false);

        // restart the clock
        timeText.text = "0";
        timeText.GetComponent<Score>().currentTime = 0;
        timeText.GetComponent<Score>().track = true;

        // ========= Start Spawning ==========
        EnemySpawn.GetComponent<EnemyManager>().starting();
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
