using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundControl : MonoBehaviour
{
    public GameObject ground_a;
    public Transform playerPos;
    public float distance;
    public int interval = 2;

    private int index;
    List<Ground> groundList = new List<Ground>();

    void Start()
    {
    }

    void Update()
    {
        //得到的index值，表示player当前在那一格场景中。
        index = Mathf.FloorToInt(playerPos.position.x / distance);

        //取余为0时，表示在该位置可以生成新场景。
        if (index % interval == 0)
        {
            //起的什么作用？？？
            foreach (Ground g in groundList)
            {
                if (g.Index == index)
                    return;
            }

            //当List中已经存在成员的情况下，删除首个成员。
            if (groundList.Count > 0)
            {
                Ground g1 = groundList[0];
                Ground g2 = groundList[1];
                groundList.Remove(g1);
                groundList.Remove(g2);
                Destroy(g1.gameObject);
                Destroy(g2.gameObject);
            }

            //生成interval个新场景。
            for (int i = 0; i < interval; i++)
            {
                Vector3 newPos = new Vector3((index + i) * distance + 10, 0, 0);
                GameObject go = Instantiate(ground_a, newPos, Quaternion.identity);

                //获取GameObject上名为Ground的脚本组件，运行SetIndex函数设置Index的值。
                Ground ground = go.GetComponent<Ground>();
                ground.SetIndex(index + i);
                ground.BornObstacle();

                groundList.Add(ground);
                //Debug.Log($"生成Index为{index + i}的Ground");
            }
        }
    }

}
