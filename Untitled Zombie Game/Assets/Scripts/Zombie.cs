using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public NavMeshAgent Enemy;

    void Start()
    {

    }

    void Update()
    {
        Enemy.SetDestination(GameObject.FindWithTag("Player").transform.position);
    }
}
