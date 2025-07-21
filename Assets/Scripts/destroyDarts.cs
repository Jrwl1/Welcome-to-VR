using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDarts : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands")) 
        {
            // Find all spawned objects with a specific tag and destroy them
            GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("Dart"); 
            foreach (GameObject obj in spawnedObjects)
            {
                Destroy(obj);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("Dart");
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
