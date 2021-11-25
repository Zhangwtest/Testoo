using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //初始值设为0.
    public int Index { get; private set; } = 0;

    public GameObject obstacle;

    public void SetIndex(int index)
    {
        this.Index = index;
    }

    void Start()
    {
        BornObstacle();
    }

    void BornObstacle()
    {
        float x = Random.Range(0, 4);
        switch (x)
        {
            case 0:
                Vector3 newPos_1 = new Vector3(Random.Range(-9,9) + Index * 18f, 2.8f, 0);
                Instantiate(obstacle, newPos_1, Quaternion.identity);
                break;
            case 1:
                Vector3 newPos_2 = new Vector3(Random.Range(-9, 9) + Index * 18f, 1.0f, 0);
                Instantiate(obstacle, newPos_2, Quaternion.identity);
                break;
            case 2:
                Vector3 newPos_3 = new Vector3(Random.Range(-9, 9) + Index * 18f, -1.0f, 0);
                Instantiate(obstacle, newPos_3, Quaternion.identity);
                break;
            case 3:
                Vector3 newPos_4 = new Vector3(Random.Range(-9, 9) + Index * 18f, -2.8f, 0);
                Instantiate(obstacle, newPos_4, Quaternion.identity);
                break;
        }
    }


}
