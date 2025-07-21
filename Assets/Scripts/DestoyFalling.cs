using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyFalling : MonoBehaviour
{
    public GameObject SpawnPos;
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = SpawnPos.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = SpawnPos.transform.position;
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
