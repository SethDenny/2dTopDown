using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class PlayerMovement: MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Vector3 moveDelta;

    private BoxCollider2D boxcollider;

    public AudioSource audioSrc;

    public Animator animator;

    public bool freeze = false;


    public bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
        audioSrc = GetComponent<AudioSource>();

    }



    //update is called once per frame
    void Update()
    {
        if (freeze == true)
        {
            moveDelta.x = 0;
            moveDelta.y = 0;
            animator.SetFloat("Horizontal", moveDelta.x);
            animator.SetFloat("Vertical", moveDelta.y);
            animator.SetFloat("Speed", moveDelta.sqrMagnitude);
            audioSrc.Stop();
            return;
        }
        ProcessInputs();

        animator.SetFloat("Horizontal", moveDelta.x);
        animator.SetFloat("Vertical", moveDelta.y);
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);

        if (moveDelta.x != 0 || moveDelta.y != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            if (!audioSrc.isPlaying)

                audioSrc.Play();
        }
        else
            audioSrc.Stop();

            
        
    }
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDelta.x * moveSpeed, moveDelta.y * moveSpeed);
    }

    public void Freeze()
    {
        freeze = true;
    }
    public void UnFreeze()
    {
        freeze = false; ;
    }
}
