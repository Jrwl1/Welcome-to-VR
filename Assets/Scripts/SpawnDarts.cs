using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDarts : MonoBehaviour
{
    public GameObject Darts;
    public float spawnOffsetX = 1.0f;
    public float spawnOffsetZ = 1.0f;
    public float spawnHeight = 1.0f;

    public bool hasSpawned = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned && other.CompareTag("Hands")) 
        {
            Vector3 spawnPosition = transform.position + new Vector3(spawnOffsetX, spawnHeight, spawnOffsetZ); 
            Instantiate(Darts, spawnPosition, Quaternion.identity);
            hasSpawned = true; 
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            hasSpawned = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
