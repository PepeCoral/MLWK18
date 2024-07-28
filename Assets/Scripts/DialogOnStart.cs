using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOnStart : MonoBehaviour
{

    [SerializeField] GameObject text;
    bool isDialogOpen = true;
    [SerializeField] PlayerMovement mov;

    void Start()
    {
        OpenDialog();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDialogOpen)
        {
            CloseDialog();
        }
    }

    void OpenDialog()
    {
        text.SetActive(true);
        mov.canWalk = false;
    }
    void CloseDialog()
    {
        text.SetActive(false);
        isDialogOpen = false;
        mov.canWalk = true;
    }
}
