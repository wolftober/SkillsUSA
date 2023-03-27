using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject pistol;
    public void SetPistolActive(bool isActive){
        pistol.SetActive(isActive);
    }
}
