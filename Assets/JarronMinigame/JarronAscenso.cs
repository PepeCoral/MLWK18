using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarronAscenso : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] float _minHeigh;

    private bool _isPlaying = true;

    void Update()
    {
        if (transform.position.y < _minHeigh)
        {
            transform.position += Vector3.down * (_speed * Time.deltaTime);
        }
        else if (_isPlaying)
        {
            _isPlaying = false;
        }

    }
}
