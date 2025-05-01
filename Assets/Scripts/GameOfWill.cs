using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class GameOfWill : MonoBehaviour
{
    private LowTaperSpawner spawner;
    public GameObject title;
    private void Awake()
    {
        spawner = GameObject.Find("SpawnUnicorn").GetComponent<LowTaperSpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            spawner.active = true;
        }
    }
}
