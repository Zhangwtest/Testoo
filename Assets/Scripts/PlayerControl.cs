using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float startSpeed;            //player的起始速度
    public float accSpeedEachSecond;    //player的加速度

    private float accTimeCount = 0;
    private float currentSpeed = 0;
    private float playerMaxSpeed = 32;
    private bool isRun = false;

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
        PlayerSpeed();
        PlayerMove();

    }

    void PlayerSpeed()
    {
        if (isRun)
        {
            if (currentSpeed < playerMaxSpeed)
            {
                accTimeCount += Time.deltaTime;
                currentSpeed = startSpeed + accTimeCount * accSpeedEachSecond;
            }
            if (currentSpeed >= playerMaxSpeed)
            {
                currentSpeed = playerMaxSpeed;
            }
            rig.velocity = transform.right * currentSpeed;
            Debug.Log(currentSpeed);
        }
    }

    //Player开始跑步。
    void PlayerStartRun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", true);
            isRun = true;
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
            isRun = false;
            currentSpeed = currentSpeed / 50f;
            rig.velocity = transform.right * currentSpeed;
            StartCoroutine(NormalSpeed());
        }
    }

    IEnumerator NormalSpeed()
    {
        yield return new WaitForSeconds(slowtime);
        isRun = true;
    }



}
