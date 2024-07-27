using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarronAscenso : MonoBehaviour
{

    [SerializeField] float _speed;

    [SerializeField] Vector3 _startingPos;
    [SerializeField] float _maxHeigh;

    private bool _isPlaying = true;


    void Start()
    {
        transform.position = _startingPos;
    }


    void Update()
    {
        if (transform.position.y < _maxHeigh)
        {
            transform.position += Vector3.up * (_speed * Time.deltaTime);
        }
        else if (_isPlaying)
        {
            _isPlaying = false;
        }

    }
}
