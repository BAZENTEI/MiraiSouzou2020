using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxMove : MonoBehaviour {
    //Vector2 pos;
    public bool catch_box;
    private Vector2 defaultHandPos;
    private Vector2 HandUp;
   // private Vector2 parentPos;
    //private Vector2 charcter_size;
    public GameObject root;
	//boxの変数
	private GameObject boxTem;
    //Rigidbody2D RigidTem;
    bool collected = false; //1210
    // Use this for initialization
    void Start()
    {
        root = transform.root.gameObject;
        defaultHandPos = transform.localPosition;
        //charcter_size = root.gameObject.GetComponent<RectTransform>().sizeDelta;
		
		HandUp = new Vector2( 0.0f,  4.5f);//修正　頭の上

		//boxTem = GameObject.Find("Box (1)");
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
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!collected)
        {
            //ジャンプ中は持ち上げることができない
            if (other.gameObject.tag == "boxTrigger")
            {
                // Debug.Log(Time.deltaTime);
                //if (this.root.GetComponent<PlayerController> ().inair == false) 
                {
                    if (Input.GetKeyDown(KeyCode.X) && catch_box == false)
                    {
                        transform.localPosition = HandUp;

                        catch_box = true;

                        GameObject box = other.transform.root.gameObject;

                        box.transform.parent = transform;

                        box.transform.position = transform.position;


                        boxTem = box.gameObject;
                        //LPBody更新

                        //Debug.Log("key down");
                        //boxに加える力を無視するようにする
                        box.GetComponent<Rigidbody2D>().isKinematic = true;
                        box.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
                        //box.GetComponent<Rigidbody2D> ().Sleep();//= false;
                        //this.root.GetComponent<PlayerController>().cs = box.GetComponent<BoxCollider2D>();

                        // Instantiate(box.GetComponent<Rigidbody2D>()) ;

                        // Destroy(box.GetComponent<Rigidbody2D>());
                        Debug.Log("Key Up 1");
                        collected = true;   //1210
                    }
                    else if (Input.GetKeyDown(KeyCode.X) && catch_box == true)
                    {
                        catch_box = false;
                        Debug.Log("Key Up2");
                        collected = true;//1210

                    }


                }


            }

        }

    }
}
