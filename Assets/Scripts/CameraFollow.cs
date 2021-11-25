using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (player != null)
        {
            if (transform.position != player.position)
            {
                //transform.position = player.position;
                transform.position = new Vector3(player.position.x + 4.5f, player.position.y + 1f, player.position.z - 0.85f);
            }
        }
    }

    void Update()
    {
        
    }
}
