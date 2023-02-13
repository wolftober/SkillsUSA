using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playAgain : MonoBehaviour
{
    public Button button;
    public GameObject player;
    public TMP_Text gameOverText;
    public GameObject playAgainButton;
    public TMP_Text timeText;

    void Start()
    {
        Button b = button.GetComponent<Button>();
        b.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        player.SetActive(true);
        gameOverText.text = "";
        playAgainButton.SetActive(false);

        // restart the clock
        timeText.text = "0";
        timeText.GetComponent<Score>().currentTime = 0;
        timeText.GetComponent<Score>().track = true;

        // ========= Start Spawning ==========

    }
}
