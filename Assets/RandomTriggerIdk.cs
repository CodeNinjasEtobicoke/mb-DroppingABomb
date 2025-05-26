using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriggerIdk : MonoBehaviour
{
    [Header("Kaboom parts")]
    public GameObject explosionkapow;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionkapow,transform.position,transform.rotation);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
