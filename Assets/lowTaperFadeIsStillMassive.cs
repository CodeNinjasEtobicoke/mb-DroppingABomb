using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowTaperFadeIsStillMassive : MonoBehaviour
{
    public GameObject bombPrefab;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);
    private Vector2 screenBounds;
    void Start() 
    {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    IEnumerator EnemyGenerator() {
        yield return new WaitForSeconds(delay);
        
        if(active){

        }
    }

    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
