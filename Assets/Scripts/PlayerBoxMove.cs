using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxMove : MonoBehaviour {
    
    public bool catch_box;
    private Vector2 defaultHandPos;
    public Vector2 HandUp;

    public GameObject root;

    public AudioSource soundPickup;
    public AudioSource soundDrop;

    //box用変数
    private GameObject boxTem;
    bool collected = false; //1210

    internal Animator animator;

    void Start()
    {
        root = transform.root.gameObject;
        defaultHandPos = transform.localPosition;
        animator = root.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update ()
    {		
        if(catch_box == true)
        {

        }
        else 
        {
			//Debug.Log ("1");		
            transform.localPosition = defaultHandPos;

            if(boxTem!=null&&boxTem.transform.IsChildOf(transform))
            {
                boxTem.transform.parent = null;

             //   boxTem.AddComponent<Rigidbody2D>();
                //boxTem.GetComponent<Rigidbody2D>() as Rigidbody2D = RigidTem;
                //boxに加える力を無視しないようにする
                boxTem.GetComponent<Rigidbody2D> ().isKinematic = false;
                boxTem = null;
				Debug.Log ("1");
            }
  
        }
        collected = false;//1210

        if(catch_box)
        {
            animator.SetBool("catchBox", true);
        }
        else
        {
            animator.SetBool("catchBox", false);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!collected)
        {
            if (other.gameObject.tag == "boxTrigger")
            {
                //ジャンプ中は持ち上げることができない
                if (this.root.GetComponent<player> ().IsGrounded) 
                {
                    if (Input.GetButtonDown("Interaction") && catch_box == false)
                    {
                        transform.localPosition = HandUp;

                        catch_box = true;

                        GameObject box = other.transform.root.gameObject;

                        box.transform.parent = transform;

                        box.transform.position = transform.position;


                        boxTem = box.gameObject;
                                            
                        //boxに加える力を無視するようにする
                        box.GetComponent<Rigidbody2D>().isKinematic = true;
                        box.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
                        //box.GetComponent<Rigidbody2D> ().Sleep();//= false;
                        //this.root.GetComponent<PlayerController>().cs = box.GetComponent<BoxCollider2D>();
                                          
                        collected = true;   //1210

                        if(!soundPickup.isPlaying)
                        {
                            soundPickup.Play();
                        }
                    }
                    else if (Input.GetButtonDown("Interaction") && catch_box == true)
                    {
                        catch_box = false;                    
                        collected = true;//1210

                        if (!soundDrop.isPlaying)
                        {
                            soundDrop.Play();
                        }
                    }


                }


            }

        }

    }
}
