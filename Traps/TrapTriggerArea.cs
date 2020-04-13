using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggerArea : MonoBehaviour
{

    public TrapSpawner[] Spawners;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player entered trigger area");
            foreach (TrapSpawner spawner in Spawners)
            {
                spawner.StartCoroutine("SpawnObjects");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player exited trigger area");
            foreach (TrapSpawner spawner in Spawners)
            {
                spawner.StopCoroutine("SpawnObjects");
            }
        }
    }
}
