using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    public float startSpeed;            //player����ʼ�ٶ�
    public float accSpeedEachSecond;    //player�ļ��ٶ�

    private float accTimeCount = 0;
    private Vector2 currentSpeed = Vector2.zero;
    private float playerMaxSpeed = 32;
    private bool isRun = false;

    public float slowtime;             //�����ϰ������ٵ�ʱ��
    //public float moveDistance;         //player�����ƶ�һ�εľ���

    private Rigidbody2D rig;
    private Animator anim;

    public int heartNum;

    void Start()
    {
        //���¼��س����󣬽�timescale����Ϊ1
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        heartNum = 3;

    }

    void Update()
    {
        PlayerStartRun();
        PlayerSpeed();
        PlayerMove();
        Debug.Log(Time.timeScale);
    }

    //���ո�ʹplayer���˶�״̬�л�Ϊtrue
    void PlayerStartRun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", true);
            isRun = true;
        }
    }

    /// <summary>
    /// player���ƶ��ٶȼ���
    /// </summary>
    void PlayerSpeed()
    {
        if (isRun)
        {
            if (currentSpeed.x < playerMaxSpeed)
            {
                accTimeCount += Time.deltaTime;
                currentSpeed = new Vector2( startSpeed + accTimeCount * accSpeedEachSecond, 0);
            }

            if (currentSpeed.x >= playerMaxSpeed)
            {
                currentSpeed = new Vector2(playerMaxSpeed, 0);
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (this.transform.position.y < 3f)
                {
                    currentSpeed = new Vector2(currentSpeed.x, 5);
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (this.transform.position.y  > -3f)
                {
                    currentSpeed = new Vector2(currentSpeed.x, -5);
                }
            }
            rig.velocity = currentSpeed;
            //Debug.Log(currentSpeed);
        }
    }

    //Player�����ƶ���
    void PlayerMove()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    if (this.transform.position.y + moveDistance < 3.5f)
        //    {
        //        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + moveDistance, 0);
        //        transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y + moveDistance, 0), 0.5f);
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    if (this.transform.position.y - moveDistance > -3.5f)
        //    {
        //        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - moveDistance, 0);
        //        transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y - moveDistance, 0), 0.5f);
        //    }
        //}
    }

    //player��obstacle����ײ�¼�
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            isRun = false;
            heartNum = heartNum - 1;
            currentSpeed = currentSpeed / 500f;
            rig.velocity = currentSpeed;
            Destroy(other.gameObject);
            StartCoroutine(NormalSpeed());
        }
    }

    IEnumerator NormalSpeed()
    {
        yield return new WaitForSeconds(slowtime);
        isRun = true;
        accTimeCount = accTimeCount * 0.25f;
    }



}
