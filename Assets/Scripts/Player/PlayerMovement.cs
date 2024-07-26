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

        if (GamePad.GetButtonTrigger(N3dsButton.L))
        {
            havePenalty = !havePenalty;
        }

#if UNITY_EDITOR
        pad = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // cross = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#endif

        if (havePenalty)
        {
            input += new Vector2(cross.x, pad.y);
        }
        else
        {
            input = pad + cross;
        }

        input = input.normalized;

        print(input);

        rb.velocity = input * _speed * Time.deltaTime;
    }


    void FixedUpdate()
    {


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
