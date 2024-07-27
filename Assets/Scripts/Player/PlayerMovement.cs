using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private bool havePenalty = false;
    private Vector2 input;

    private  Animator animator;

    private Rigidbody2D rb;
    [SerializeField] float _speed;


    void Awake()
    {
        animator = this.GetComponent<Animator>();
        rb =  this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var pad = GamePad.CirclePad.normalized;
        var cross = GetCross().normalized;

        if (GamePad.GetButtonTrigger(N3dsButton.L) || Input.GetKeyDown(KeyCode.B))
        {
            havePenalty = !havePenalty;
        }

#if UNITY_EDITOR
        pad = PadEditor().normalized;
        cross = CrossEditor().normalized;
#endif

        if (havePenalty)
        {
            if (Math.Abs(pad.y) < 0.6)
            {
                pad.y = 0;
            }
            input = new Vector2(pad.x, cross.y);
        }
        else
        {
            input = pad + cross;
        }

        input = input.normalized;
        


        rb.velocity = input * (_speed * Time.deltaTime);
        
        animator.SetBool("isMoving", rb.velocity != Vector2.zero);
        
        Vector2 velocityNormalized = rb.velocity.normalized;

        if (input != Vector2.zero)
        {
            animator.SetFloat("Vertical", velocityNormalized.y);
            animator.SetFloat("Horizontal", velocityNormalized.x);   
        }
    }

    private static Vector2 CrossEditor()
    {
        Vector2 cross;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cross = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cross = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            cross = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cross = Vector2.right;
        }
        else
        {
            cross = Vector2.zero;
        }

        return cross;
    }

    private static Vector2 PadEditor()
    {
        Vector2 pad;
        if (Input.GetKey(KeyCode.A))
        {
            pad = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pad = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            pad = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pad = Vector2.down;
        }
        else
        {
            pad = Vector2.zero;
        }

        return pad;
    }


    private static Vector2 GetCross()
    {
        var cross = new Vector2();
        if (GamePad.GetButtonHold(N3dsButton.Up))
        {
            cross += Vector2.up;
        }

        if (GamePad.GetButtonHold(N3dsButton.Down))
        {
            cross += Vector2.down;
        }

        if (GamePad.GetButtonHold(N3dsButton.Left))
        {
            cross += Vector2.left;
        }

        if (GamePad.GetButtonHold(N3dsButton.Right))
        {
            cross += Vector2.right;
        }

        return cross;
    }
}
