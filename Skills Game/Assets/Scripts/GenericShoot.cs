using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericShoot : MonoBehaviour
{
    public int current_ammo;

    public abstract void fire();
}
