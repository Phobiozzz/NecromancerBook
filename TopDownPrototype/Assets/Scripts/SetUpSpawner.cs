using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpSpawner : MonoBehaviour
{
    public GameObject spawnerPrefab;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + 10f);
            Instantiate(spawnerPrefab, newPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
