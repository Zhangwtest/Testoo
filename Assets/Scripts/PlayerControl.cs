using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float startSpeed;

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
    }

    void PlayerStartRun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", true);
            rig.velocity = transform.right * startSpeed;
        }
    }

}
