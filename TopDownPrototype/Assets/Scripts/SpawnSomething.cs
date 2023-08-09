using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSomething : MonoBehaviour
{
    public GameObject[] obstacles;
   
    public void Awake()
    {
        int rndm = Random.Range(0, obstacles.Length);
        

        int positionX = Random.Range(-10, 10);
        int positionY = Random.Range(-3, 3);
        Vector2 newPosition = new Vector2(transform.position.x + positionX, transform.position.y + positionY);

        GameObject obstacle = Instantiate(obstacles[rndm],newPosition, Quaternion.identity);
        
        obstacle.transform.localScale = new Vector3(Random.Range(0.1f, 0.5f), 0.07f);
       

    }
}
