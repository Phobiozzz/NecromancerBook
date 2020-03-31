using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject player;

    public float OffsetX;
    public float OffsetY;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void SmoothFollow()
    {
        if (player != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + OffsetX, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + OffsetY , ref velocity.y, smoothTimeY);

            transform.position = new Vector3(posX, posY, transform.position.z);

        }

    }


    private void FixedUpdate()
    {
        SmoothFollow();


    }
}
