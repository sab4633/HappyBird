using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject pipe;
    private float time = 0.0f;
    List<GameObject> pipes;
    public float interpolationPeriod;
    public float bounds = 20;


    void Start()
    {
        interpolationPeriod = Random.Range(1f, 1.8f);
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
        GameObject clone = Instantiate(pipe) as GameObject;
        clone = (GameObject)Instantiate(pipe, screenPosition, Quaternion.identity);
        pipes.Add(clone);
        if (pipes.Count >= 3)
        {
            Destroy(pipes[0]);
            pipes.RemoveAt(0);
            Debug.Log(pipes.Count);
        }
    }
    /*
    public void DestoryPipes()
    {
        if (pipes.Count >= 3)
        {
            
            for(int i= 0; i < pipes.Count - 2; i++)
            {
                Destroy(pipes.GetEnumerator(i));
            }
        }
    }
    */
   
    
}
