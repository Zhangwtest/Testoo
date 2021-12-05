using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public PlayerControl player;

    private float bornTime;
    private float randomTime;
    void Start()
    {
        bornTime = 0;
        //InvokeRepeating("ObstacleBorn", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        BornControl();
    }

    void BornControl()
    {
        if (player.isRun)
        {
            randomTime = Random.Range(0.8f, 1.2f);
            bornTime += Time.deltaTime;

            if (bornTime >= randomTime)
            {
                bornTime = 0;
                ObstacleBorn();
            }
            Debug.Log("bornTime = " + bornTime);
            Debug.Log("randomTime = " + randomTime);
        }
    }

    void ObstacleBorn()
    {
        float x = Random.Range(0, 4);
        switch (x)
        {
            case 0:
                Vector3 newPos_1 = new Vector3(Random.Range(0, 18) + player.transform.position.x + 18, 2.8f, 0);
                Instantiate(obstaclePrefab, newPos_1, Quaternion.identity);
                break;
            case 1:
                Vector3 newPos_2 = new Vector3(Random.Range(0, 18) + player.transform.position.x + 18, 1.0f, 0);
                Instantiate(obstaclePrefab, newPos_2, Quaternion.identity);
                break;
            case 2:
                Vector3 newPos_3 = new Vector3(Random.Range(0, 18) + player.transform.position.x + 18, -1.0f, 0);
                Instantiate(obstaclePrefab, newPos_3, Quaternion.identity);
                break;
            case 3:
                Vector3 newPos_4 = new Vector3(Random.Range(0, 18) + player.transform.position.x + 18, -2.8f, 0);
                Instantiate(obstaclePrefab, newPos_4, Quaternion.identity);
                break;
        }
    }
}
