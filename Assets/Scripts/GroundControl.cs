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
        index = Mathf.FloorToInt(playerPos.position.x / distance);
        if (index % interval == 0)
        {
            foreach (Ground g in groundList)
            {
                if (g.index == index)
                    return;
            }

            if (groundList.Count > 0)
            {
                Ground g = groundList[0];
                groundList.Remove(g);
                Destroy(g.gameObject);
            }

            for (int i = 0; i < interval; i++)
            {
                Vector3 newPos = new Vector3((index + i) * distance, 0, 0);
                GameObject go = Instantiate(ground_a, newPos, Quaternion.identity);
                Ground ground = go.GetComponent<Ground>();
                ground.SetIndex(index + i);
                groundList.Add(ground);
                Debug.Log($"����IndexΪ{index + i}��Ground");
            }
        }
    }














    //public float moveSpeed = 8f;

    //void Update()
    //{
    //    this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);                                           ���������ƶ�
    //    Vector3 postion = this.transform.position;                                                                     ��ȡ��ǰ����λ��
    //    if (postion.y <= -8.52f)                                                                                       �жϸ�λ���Ƿ�С�ڵ���-8.52��Ҳ����˵�Ƿ񳬳�������
    //    {
    //        this.transform.position = new Vector3(postion.x, postion.y + 8.52f * 2, postion.z);//�����µ�λ��
    //    }

    //}

}
