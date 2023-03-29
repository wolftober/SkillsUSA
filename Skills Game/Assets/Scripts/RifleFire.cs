using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFire : GenericShoot
{
    public float volume = 0.5f;
    public int ammo = 21;
    public float burstTime = 0.25f;

    public Transform fire_point;
    public GameObject bulletPrefab;

    public float bullet_force = 20f;
    
    
    public float shootingSpeed = 1f;
    
    bool shot = false;

    void Update(){
        if(shot){
            return;
        }
        if(Input.GetMouseButtonDown(0)){
            fire();
        }
    }
    void Start(){
        current_ammo = ammo;
    }
    
    IEnumerator fireRate()
    {
        shot = true;
        yield return new WaitForSeconds(shootingSpeed);
        shot = false;
    }

    public override void fire()
    {
            if (current_ammo > 0)
            {
                StartCoroutine(shoot());
                StartCoroutine(fireRate());
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
