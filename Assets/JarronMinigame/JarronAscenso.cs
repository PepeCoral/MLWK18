using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarronAscenso : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] float _minHeigh;

    private bool _isPlaying = false;

    void Update()
    {
        if (transform.position.y > _minHeigh && _isPlaying)
        {
            transform.position += Vector3.down * (_speed * Time.deltaTime);
        }
        else if (_isPlaying)
        {
            print("terminado");
            _isPlaying = false;
        }

    }

    public void StartGame()
    {
        _isPlaying = true;
    }

    public void CompleteMinigame()
    {
        _isPlaying = false;
    }

    public void JarronFall()
    {
    }


}
