using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float startSpeed;
    public float slowtime;
    public float moveDistance;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerStartRun();
        PlayerMove();
    }

    //Player��ʼ�ܲ���
    //ToDo:�ƶ��������٣�Ҫ�ĳ�Խ��Խ�졣
    //ToDo�������ĳɵ��UI��ť����ʼ�ܲ���
    void PlayerStartRun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", true);
            rig.velocity = transform.right * startSpeed;
        }
    }

    //Player�����ƶ���
    void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (this.transform.position.y + moveDistance < 3.5f)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + moveDistance, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (this.transform.position.y - moveDistance > -3.5f)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - moveDistance, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            rig.velocity = transform.right * startSpeed / 20;
            StartCoroutine(NormalSpeed());
        }
    }

    IEnumerator NormalSpeed()
    {
        yield return new WaitForSeconds(slowtime);
        rig.velocity = transform.right * startSpeed;
    }



    //void Attack()
    //{
    //    if (Input.GetButtonDown("Attack"))
    //    {
    //        anim.SetTrigger("Attack");
    //        StartCoroutine(StartAttack());
    //        SoundManager.PlaySwordClip();
    //    }
    //}


}
