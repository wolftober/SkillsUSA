using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float waittime = 1f;
    // Start is called before the first frame update
    public List <GameObject> spawnTable = new List<GameObject>();
    void Start()
    {
        StartCoroutine(Enemyspawn());
    }

    public void starting()
    {
        StopAllCoroutines();
        StartCoroutine(Enemyspawn());
    }

    static int count = 0;
    IEnumerator Enemyspawn(){
        print("num of enemy spawn calls: " + count);
        count++;
             
        while(true){
            Vector3 enemySpawn = new Vector3(Random.Range(-16f,16f), 0, Random.Range(-24f, 20f));
            if((enemySpawn - transform.position).magnitude < 20){
                Debug.Log("too close");
                continue;
            }
            else{
                int item = Random.Range(0,spawnTable.Count);
                GameObject spawn =  spawnTable[item];
                Instantiate(spawn, enemySpawn, Quaternion.identity);
            }
            Debug.Log("spawn!");
            yield return new WaitForSeconds(waittime);
        }
    }
}
