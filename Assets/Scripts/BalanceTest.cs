using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceTest : MonoBehaviour
{



    Gyroscope gyro;
    [SerializeField] GameObject ga;
    [SerializeField] GameObject gb;
    [SerializeField] GameObject gc;

    private void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    private void Update()
    {
        Quaternion a = gyro.attitude;
        Vector3 b = a.eulerAngles;


        ga.transform.rotation = Quaternion.Euler(0, 0, b.x);
        gb.transform.rotation = Quaternion.Euler(0, 0, b.y);
        gc.transform.rotation = Quaternion.Euler(0, 0, b.z);

    }

}
