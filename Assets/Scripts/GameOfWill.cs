using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class GameOfWill : MonoBehaviour
{
    private LowTaperSpawner spawner;
    public GameObject title;
    private Vector2 screenBounds;

    [Header("Player of josh character")]
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    private void Awake()
    {
        spawner = GameObject.Find("SpawnUnicorn").GetComponent<LowTaperSpawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
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
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                ResetGame();
            }
           
        }
        else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }
        if (Input.anyKeyDown)
        {
            spawner.active = true;
            title.SetActive(false);
        }

        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (-screenBounds.y - 12))
            {
                Destroy(bombObject);
            }
         }
    }

    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);

        playerPrefab = Instantiate(playerPrefab, new Vector3(0, 0, 8), playerPrefab.transform.rotation);
        gameStarted = true;
    }


}