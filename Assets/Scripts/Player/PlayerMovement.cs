using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class PlayerMovement : MonoBehaviour
{
    private bool havePenalty = false;
    private Vector2 input;

    void Update()
    {
        var pad = GamePad.CirclePad.normalized;
        var cross = GetCross();

#if UNITY_EDITOR
        pad = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
