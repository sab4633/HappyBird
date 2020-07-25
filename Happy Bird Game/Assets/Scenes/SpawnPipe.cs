using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject pipe;
    private GameObject[] pipeObj;
    private int indexer;
    private float time = 0.0f;
    public float interpolationPeriod = Random.Range(1f, 1.8f);
    public float bounds = 20;


    void Start()
    {
        indexer = 0;
        SpawnRandom();
    }

    

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            interpolationPeriod = Random.Range(1f, 1.8f);
            SpawnRandom();

            // execute block of code here
        }
    }

    public void SpawnRandom()
    {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane+5)); //will get the middle of the screen
        
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(bounds, Screen.height-bounds), Camera.main.farClipPlane / 2));
       
        Instantiate(pipe, screenPosition, Quaternion.identity);
      
    }
   
    
}
