using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;
using TMPro;

public class GameOfWill : MonoBehaviour
{
    private LowTaperSpawner spawner;
    public GameObject title;
    private Vector2 screenBounds;

    public GameObject splash;

    [Header("Player of josh character")]
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;

    [Header("Skibidi score")]
    public TMP_Text scoreText;
    public int pointsWorth = 1;
    private int SkibidiScore;

    private int bestScoreFromOhio = 0;
    public TMP_Text bestSkibidiText;
    private bool beatBestToilet;

    public Color bestScoreColor;
    public Color normalColor;
   
    private bool sigmasmokeCleared = true;
    private void Awake()
    {
        spawner = GameObject.Find("SpawnUnicorn").GetComponent<LowTaperSpawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        scoreText.enabled = false;

        bestSkibidiText.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(false);
        splash.SetActive(false);

        bestScoreFromOhio = PlayerPrefs.GetInt("BestScoreFromOhio");
        bestSkibidiText.text = "Best Score From Ohio: " + bestScoreFromOhio.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            Debug.Log("not gamestarted" + gameStarted);
            if (Input.anyKeyDown && sigmasmokeCleared)
            {
                sigmasmokeCleared = false;
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
                if (gameStarted)
                {
                    SkibidiScore += pointsWorth;
                    scoreText.text = "Skibidi Score: " + SkibidiScore.ToString();
                }
                Destroy(bombObject);
            }
         }
    }

    

    void ResetGame()
    {
        bestSkibidiText.color = normalColor;
        spawner.active = true;
        title.SetActive(false);
        splash.SetActive(false) ;

        scoreText.enabled = true;
        SkibidiScore = 0;

        beatBestToilet = false;
        bestSkibidiText.enabled = true;

        scoreText.text = "score: " + SkibidiScore.ToString();

        player = Instantiate(playerPrefab, new Vector3(0, 0, 8), playerPrefab.transform.rotation);
        gameStarted = true;
    }

    void OnPlayerKilled()
    {
        Debug.Log("player killed");
        spawner.active = false;
        gameStarted = false;

        splash.SetActive(true);

        Invoke("SplashScreen", 2);

        if(SkibidiScore > bestScoreFromOhio)
        {
            bestSkibidiText.color = bestScoreColor;
            bestScoreFromOhio = SkibidiScore;
            PlayerPrefs.SetInt("BestScore", bestScoreFromOhio);
            beatBestToilet = true;
            bestSkibidiText.text = "Best Score From Ohio: " + bestScoreFromOhio.ToString();
        }
    }

    void SplashScreen()
    {
        sigmasmokeCleared = true;
        splash.SetActive(true);
    }


}