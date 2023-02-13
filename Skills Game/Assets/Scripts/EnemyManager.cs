using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float waittime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemyspawn());
    }

    public void starting()
    {
        StartCoroutine(Enemyspawn());
    }

    IEnumerator Enemyspawn(){
        while(true){
            Vector3 enemySpawn = new Vector3(Random.Range(-16f,16f), 0, Random.Range(-24f, 20f));
            if((enemySpawn - transform.position).magnitude < 20){
                Debug.Log("too close");
                continue;
            }
            else{
                Instantiate(enemy, enemySpawn, Quaternion.identity);
            }
            Debug.Log("spawn!");
            yield return new WaitForSeconds(waittime);
        }
    }
}
