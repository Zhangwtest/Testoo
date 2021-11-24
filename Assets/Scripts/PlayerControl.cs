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

    //Player开始跑步。
    //ToDo:移动还是匀速，要改成越跑越快。
    //ToDo：后续改成点击UI按钮来开始跑步。
    void PlayerStartRun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", true);
            rig.velocity = transform.right * startSpeed;
        }
    }

    //Player上下移动。
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
