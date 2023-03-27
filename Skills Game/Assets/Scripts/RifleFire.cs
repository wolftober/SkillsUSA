using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFire : MonoBehaviour
{
    public float volume = 0.5f;
    public int ammo = 21;
    public int current_ammo = 21;
    public float burstTime = 0.5f;

    public Transform fire_point;
    public GameObject bulletPrefab;

    public float bullet_force = 20f;

    void Update(){
        if (Input.GetMouseButtonDown(0))
        {
            if (current_ammo > 0)
            {
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot(){
        for(int i = 0; i < 3; i++){
            current_ammo--;
            GameObject bullet = Instantiate(bulletPrefab, fire_point.position, fire_point.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(fire_point.forward * bullet_force, ForceMode.Impulse);
            yield return new WaitForSeconds(burstTime);
        }
    }
}
