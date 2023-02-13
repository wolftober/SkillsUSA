using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public AudioSource gun_shot;
    public float volume = 0.5f;
    public int ammo = 10;
    public int current_ammo = 10;
    public int reload_time = 2;
    bool isReloading = false;

    public Transform fire_point;
    public GameObject bulletPrefab;

    public float bullet_force = 20f;

    void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, fire_point.position, fire_point.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(fire_point.forward * bullet_force, ForceMode.Impulse);
    }
    IEnumerator reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reload_time);
        current_ammo = ammo;
        isReloading = false;
    }

    void Update()
    {
        if (isReloading)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (current_ammo > 0)
            {
                //current_ammo -= 1;
                //gun_shot.PlayOneShot(gun_shot.clip, volume);
                fire();
            }
        }
        if (current_ammo == 0)
        {
            StartCoroutine(reload());
        }
    }
}
