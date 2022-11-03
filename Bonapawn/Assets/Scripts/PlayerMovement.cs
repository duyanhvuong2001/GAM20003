using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 3;
    private bool walking;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    private Vector3 moveToPosition;
    bool facingRight = true;

    private AudioSource audioSource;

    public LayerMask MovementStop;

    Vector3 Adjustment = new Vector3(0,0,0);
    Vector3 AdjustmentTemp = new Vector3(0, 0, 0);

    private float dashDelay = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        dashCheck();

        if (Input.GetKey(KeyCode.LeftShift) && walking && dashDelay <= 0f)
        {
            pDash();
        }

        if (!walking)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if(movement.x != 0)
            {
                movement.y = 0;
            }

            if(movement != Vector2.zero)
            {
                if (!Physics2D.OverlapCircle(transform.position + new Vector3(movement.x, movement.y, 0), 0.01f, MovementStop))
                {
                    moveToPosition = transform.position + new Vector3(movement.x, movement.y, 0);

                    StartCoroutine(Move(moveToPosition));
                }
            }
            if (movement.x < 0 && facingRight){
                Flip();
            }
            else if (movement.x > 0 && !facingRight){
                Flip();
            }

            if (walking)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }
            // anim.SetBool("walking", walking);   
        }

        
    }

    IEnumerator Move(Vector3 newPos)
    {
        walking = true;

        while((newPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            if (Adjustment != AdjustmentTemp)
            {
                newPos += Adjustment;
                Adjustment = AdjustmentTemp;
            }
            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
            
            yield return null;
        }
        transform.position = newPos;
        moveSpeed = 3;
        walking = false;

    }

    private void Flip()
	{
		facingRight = !facingRight;
		transform.Rotate(0f, 180f, 0f);
	}

    public void pKnockback()
    {
        if (walking)
        {
            Adjustment -= transform.right * 3;
            moveSpeed = 9;
        }
        else
        {
            StartCoroutine(Move(transform.position -= transform.right * 2));
        }
    }

    public void pDash()
    {
        Adjustment += new Vector3(movement.x, movement.y, 0);
        moveSpeed = 20;
        dashDelay = 10f;
    }

    void dashCheck()
    {
        if(dashDelay > 0f)
        {
            dashDelay -= 0.1f;
        }
    }
}
