using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private bool havePenalty = false;
    private Vector2 input;



    private Rigidbody2D rb;
    [SerializeField] float _speed;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var pad = GamePad.CirclePad.normalized;
        var cross = GetCross();

        if (GamePad.GetButtonTrigger(N3dsButton.L) || Input.GetKeyDown(KeyCode.B))
        {
            havePenalty = !havePenalty;
        }

#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.A))
        {
            pad = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            pad = Vector2.right;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            pad = Vector2.up;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            pad = Vector2.down;
        }
        else{
            pad = Vector2.zero;
        }
        
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
#endif

        if (havePenalty)
        {
            input = new Vector2(cross.x, pad.y);
        }
        else
        {
            input = pad + cross;
        }

        input = input.normalized;

        print(input);

        rb.velocity = input * _speed * Time.deltaTime;
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
