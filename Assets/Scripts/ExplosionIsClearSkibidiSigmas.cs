using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionIsClearSkibidiSigmas : MonoBehaviour
{
    private ParticleSystem particleSmokeIsMewing;
    private void Awake()
    {
        particleSmokeIsMewing = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!particleSmokeIsMewing.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
