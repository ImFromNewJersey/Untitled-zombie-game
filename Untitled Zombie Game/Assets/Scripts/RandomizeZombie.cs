using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeZombie : MonoBehaviour
{

    Transform[] Models;

    void Start()
    {
        Models = GetComponentsInChildren<Transform>();
        Randomize();
    }

    void Randomize()
    {
        Models[4].gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;

        Models[Random.Range(1, 50)].gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;

    }

}
