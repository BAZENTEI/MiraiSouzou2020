using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : KinematicObject
{
    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }

    public AudioSource soundJump;
    public AudioSource soundWalk;

    private double dTime;

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

    public bool controlEnabled = true;

    bool jump;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    internal Animator animator;

    public float m_time = 0.0f;
    public float m_MaxTime;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void UpdateSound()
    {
        double time = AudioSettings.dspTime;

        if (move.x != 0.0f && IsGrounded)
        {
            if (!soundWalk.isPlaying)
            {
                if (time > dTime)
                {
                    dTime = AudioSettings.dspTime;
                    soundWalk.Play();
                    dTime += 0.25;
                }
            }
            else
            {
                soundWalk.Stop();
            }
        }

        if (jumpState == JumpState.PrepareToJump && !soundJump.isPlaying)
        {
            soundJump.Play();
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (controlEnabled)
        {
            // ポーズ中の動作を禁止する
            if (Time.timeScale == 0)
                return;

            if (m_time > m_MaxTime)
            {
                stopJump = true;
                m_time = 0.0f;

            }
            else if (jumpState == JumpState.InFlight)
            {
                if (velocity.y > 0)
                {
                    m_time += Time.deltaTime;
                }
            }

            if (jumpState == JumpState.Landed)
            {
                m_time = 0.0f;
            }

            move.x = Input.GetAxis("Horizontal");

            if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
            {
                jumpState = JumpState.PrepareToJump;
            }
        }
        else
        {
            move.x = 0;
        }

        UpdateSound();
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
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (move.x > 0.01f)
        {
            if (transform.localScale.x > 0)
                transform.localScale =
                new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
        else if (move.x < -0.01f)
        {
            if (transform.localScale.x < 0)
                transform.localScale =
                new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }

        animator.SetBool("grounded", IsGrounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
