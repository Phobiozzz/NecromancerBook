using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] templates;
    Transform player;
    Transform ground;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ground = GameObject.FindGameObjectWithTag("Ground").transform;
        //GameObject newTemplate = GenerateTemplate();

    }

    public void Update()
    {
        GenerateLevel();
    }

    public GameObject GenerateTemplate()
    {
        int random = Random.Range(0, templates.Length);

        return Instantiate(templates[random], transform.position, Quaternion.identity, ground);

    }

    public void GenerateLevel()
    {
        if (player != null)
        {
            if (player.transform.position.y >= transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 5.1f, transform.position.z);
                GameObject newTemplate = GenerateTemplate();  
            }
        }
        
    }
}
