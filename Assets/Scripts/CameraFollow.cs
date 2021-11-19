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
                transform.position = new Vector3(player.position.x, player.position.y, player.position.z - 0.5f);
            }
        }
    }

    void Update()
    {
        
    }
}
