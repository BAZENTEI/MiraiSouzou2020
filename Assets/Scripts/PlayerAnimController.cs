using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    private GameObject hand;
    private PlayerBoxMove script;
    //private float time = 0.0f;
    private Animator animator;
    private bool stop;
    private bool box;
    public PlayerBoxMove Hand;
    // Use this for initialization
    void Start()
    {
        hand = GameObject.Find("Hand").gameObject;
        script = hand.GetComponent<PlayerBoxMove>();
        animator = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("walk", false);
        GetComponent<Animator>().SetBool("walk_b", false);

        box = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        box = script.catch_box;
        //box = false;
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal  != 0)
        {
            GetComponent<Animator>().SetBool("walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk", false);
        }
        if (box == false)
        {
            GetComponent<Animator>().SetBool("walk_b", false);

        }
        else if (box == true)
        {
            GetComponent<Animator>().SetBool("walk_b", true);
            if (Input.GetAxis("Horizontal") == 0)
            {
                animator.SetFloat("MoveSpeed", 0.0f);
            }
            else
            {
                animator.SetFloat("MoveSpeed", 1.0f);
            }
        }

        //if (Input.GetAxis("Horizontal") == 0)
        //{
        //    stop = true;
        //    animator.SetFloat("MoveSpeed", 0.0f);

        //}
        //else
        //{
        //    stop = false;
        //    animator.SetFloat("MoveSpeed", 1.0f);

        //}


        //if (Input.GetKeyDown(KeyCode.Z) == true)
        //{
        //    stop = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.C) == true)
        //{
        //    stop = false;
        //}
        //if (stop == false)
        //{
        //    animator.SetFloat("MoveSpeed", 1.0f);
        //}
        //else if (stop == true)
        //{
        //    animator.SetFloat("MoveSpeed", 0.0f);
        //}
        //else
        //{
        //    animator.SetFloat("MoveSpeed", 1.0f);
        //}
        //if (Input.GetAxis("Horizontal") == 0)
        //{
        //    stop = true;
        //    animator.SetFloat("MoveSpeed", 0.0f);

        //}
        //else
        //{
        //    stop = false;
        //    animator.SetFloat("MoveSpeed", 1.0f);

        //}
    }
}