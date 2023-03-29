using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GenericShoot
{
    //public AudioSource gun_shot;
    public float volume = 0.5f;
    public int ammo = 10;
    public float reload_time = 2f;
    public float shootingSpeed = 1f;
    bool isReloading = false;
    bool shot = false;

    public Transform fire_point;
    public GameObject bulletPrefab;

    public float bullet_force = 20f;

    void Start(){
        current_ammo = ammo;
    }

    public override void fire()
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
    IEnumerator fireRate()
    {
        shot = true;
        yield return new WaitForSeconds(shootingSpeed);
        shot = false;
    }

    void Update()
    {
        if (isReloading || shot)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (current_ammo > 0)
            {
                current_ammo -= 1;
                //gun_shot.PlayOneShot(gun_shot.clip, volume);
                fire();
                StartCoroutine(fireRate());
            }
        }
        if (current_ammo == 0)
        {
            StartCoroutine(reload());
        }
    }
}
