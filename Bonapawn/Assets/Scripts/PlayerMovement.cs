using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 1;
    private bool walking;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    private Vector3 moveToPosition;
    bool facingRight = true;

    private AudioSource audioSource;

    public LayerMask MovementStop;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(!walking)
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
            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.fixedDeltaTime);
            yield return null;
        }
        transform.position = newPos;

        walking = false;

    }

    private void Flip()
	{
		facingRight = !facingRight;
		transform.Rotate(0f, 180f, 0f);
	}

}
