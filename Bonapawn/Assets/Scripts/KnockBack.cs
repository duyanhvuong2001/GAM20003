using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockBack : MonoBehaviour
{
    private float moveSpeed = 1;
    private bool walking;


    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    private Vector3 moveToPosition;

    private AudioSource audioSource;

    public LayerMask MovementStop;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void KnockedBack()
    {
        if(!walking)
        {
            Vector2 direction = GameManager.instance.playerTransform.right;
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(direction.x, direction.y, 0), 0.01f, MovementStop))
            {
                    moveToPosition = transform.position + new Vector3(direction.x, direction.y, 0);

                    StartCoroutine(Move(moveToPosition));
            }
        }
    }

    public void KnockedBackPlayer()
    {
        if (!walking)
        {
            Vector2 direction = -GameManager.instance.playerTransform.right;
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(direction.x, direction.y, 0), 0.01f, MovementStop))
            {
                moveToPosition = transform.position + new Vector3(direction.x, direction.y, 0);

                StartCoroutine(Move(moveToPosition));
            }
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
