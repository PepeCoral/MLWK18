using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarronAscenso : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] float _minHeigh;

    [SerializeField] JarronGiroscopio _jarronGiroscopio;



    private bool _isPlaying = false;
    private bool _isFalling = false;
    private bool _hasFalled = false;

    [SerializeField] JarronMinigameManager _manager;

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
            _jarronGiroscopio.JarronFall();
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



    private void PlaySound()

    {
        _manager.CompleteMinigame();
    }




}
