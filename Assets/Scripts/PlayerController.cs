using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float speed; //スピードを格納する変数
    public float up;
    private Rigidbody2D rd2d; // 2D physicsに必要なコンポーネントへの参照を格納
    //private Vector2 Player_pos;
    private Vector2 defaultScale;
	//private Rigidbody rigid;
    public bool jump;
	public bool inair = false;	//playerが空中かどうか　1128

	//public BoxCollider2D cs;
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        rd2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        defaultScale = transform.localScale;
        //defaultHandPos = transform.GetChild(0).gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // 横移動
        //Player_pos = transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        if (inair == true && jump == false)
        {
			 //up -= 0.9f;
            up = 0.0f;

			inair = true;
        }


        //1129
        if (jump == true && inair == true)
        {
            up = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&(jump == false)&&(inair == false))
        {
            up = 60.0f;
            jump = true;

			inair = true;
        }

		

		//scale
        if(moveHorizontal > 0)
        {
            transform.localScale = defaultScale;
        }
        else if(moveHorizontal < 0)
        {
            transform.localScale = new Vector2(-defaultScale.x, defaultScale.y);
        }
     

        // ２つの変数を使ってVector2変数を作成
        Vector2 movement = new Vector2(moveHorizontal, up);
		//Debug.Log (movement.y);
        // movementにspeedを乗算。その後にAddForce関数を呼び出す
		rd2d.AddForce(movement * speed);

        

    }
		
	
	 void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Ground")
		{
			// Debug.Log("HitBox");

			up = 0;
			jump = false;
			inair = false; //1128

		}

		/*if (other.gameObject.tag == "Box")
        {
			up = 0;
			jump = false;
			inair = false; //1128
        }*/



			
    }


	/*public void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "Ground")
		{
			// Debug.Log("HitBox");

			up = 0;
			jump = false;
			inair = false; //1128

		}

	}*/
    
}