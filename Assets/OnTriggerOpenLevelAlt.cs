using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerOpenLevelAlt : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
            OpenDialog();
        }
    }

    [SerializeField] GameObject text;
    bool isDialogOpen = false;



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
        isDialogOpen = true;
    }
    void CloseDialog()
    {
        text.SetActive(false);
        isDialogOpen = false;
        SceneSwitcher.Instance.SwitchToNextScene();

    }


}
