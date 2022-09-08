using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Zombie;
    public  float spawntime = 2f;
    private bool Waited = true;
    public int ZombiesSpawned;
    public float MaxZombies;

    void Start()
    {

    }

    void Update()
    {
        ZombiesSpawned = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Waves>().ZombiesSpawned;
        MaxZombies = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Waves>().MaxZombies;

        if (ZombiesSpawned <= MaxZombies && Waited)
        {
            StartCoroutine(Spawn());
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Waves>().ZombiesSpawned++;
        }
        else if(ZombiesSpawned >= MaxZombies)
        {
            if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
            {
                GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Waves>().waveended = true;
            }

        }
    }



    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 1);
    }

    IEnumerator Spawn()
    {
        Waited = false;
        yield return new WaitForSeconds(spawntime);
        Waited = true;
        Instantiate(Zombie, transform.position, Quaternion.identity);
    }

}
