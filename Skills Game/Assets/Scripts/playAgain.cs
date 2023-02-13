using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playAgain : MonoBehaviour
{
    public Button button;

    void Start()
    {
        Button b = button.GetComponent<Button>();
        //b.onClick.AddListener(OnClick);
    }


}
