using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    private bool walking;

    private Rigidbody2D rb;
    // private Animator anim;

    private Vector2 movement;
    private Vector3 moveToPosition;

    public LayerMask MovementStop;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
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
                    // anim.SetFloat("X", movement.x);
                    // anim.SetFloat("Y", movement.y);
                    // anim.SetBool("walking", true)

                    StartCoroutine(Move(moveToPosition));
                }
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


}
