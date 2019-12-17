using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : KinematicObject{
    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }

    /// <summary>
    /// Max horizontal speed of the player.
    /// </summary>
    public float maxSpeed = 7;
    /// <summary>
    /// Initial jump velocity at the start of a jump.
    /// </summary>
    public float jumpTakeOffSpeed = 7;

    public JumpState jumpState = JumpState.Grounded;
    private bool stopJump;
    /*internal new*/
    //public Collider2D collider2d;
    /*internal new*/
    //public AudioSource audioSource;
  //  public Health health;
    public bool controlEnabled = true;

    bool jump;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    internal Animator animator;
    //  readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    public float m_time = 0.0f;//1217
    public float m_MaxTime;

    void Awake()
    {
        //health = GetComponent<Health>();
        //audioSource = GetComponent<AudioSource>();
       // collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    protected override void Update() {
        if (controlEnabled)
        {
            //1217
            if (m_time > m_MaxTime)
            {
                stopJump = true;
                //Debug.Log("stopJump");
                m_time = 0.0f;
                //Schedule<PlayerStopJump>().player = this;

            }
            else if (jumpState == JumpState.InFlight )
            {
                //!
                if (velocity.y > 0)
                {
                    m_time += Time.deltaTime;
                }
                   
              
            }
            if(jumpState == JumpState.Landed)
            {
                m_time = 0.0f;
            }
           

            move.x = Input.GetAxis("Horizontal");
            if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
            {
                jumpState = JumpState.PrepareToJump;
                //stopJump = true;
            }
            //Input.GetButtonUp("Jump")
             
        }
        else
        {
            move.x = 0;
        }
        UpdateJumpState();
        base.Update();
    }

    void UpdateJumpState()
    {
        jump = false;
        switch (jumpState)
        {
            case JumpState.PrepareToJump:
                jumpState = JumpState.Jumping;
                jump = true;
                stopJump = false;
                break;
            case JumpState.Jumping:
                if (!IsGrounded)
                {
                    //Schedule<PlayerJumped>().player = this;
                    jumpState = JumpState.InFlight;
                }
                break;
            case JumpState.InFlight:
                if (IsGrounded)
                {
                   // Schedule<PlayerLanded>().player = this;
                    jumpState = JumpState.Landed;
                }
                break;
            case JumpState.Landed:
                jumpState = JumpState.Grounded;

                break;
        }
    }

    protected override void ComputeVelocity()
    {
        if (jump && IsGrounded)
        {
            //model.jumpModifier
            velocity.y = jumpTakeOffSpeed * 1.5f;
            jump = false;
        }
        else if (stopJump)
        {
            stopJump = false;
            if (velocity.y > 0)
            {
                //model.jumpDeceleration
                velocity.y = velocity.y * 0.5f ;
            }
        }

        if (move.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (move.x < -0.01f)
            spriteRenderer.flipX = true;

        //animator.SetBool("grounded", IsGrounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
