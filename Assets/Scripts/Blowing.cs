using System;
using System.Linq;
using UnityEngine;

public class Blowing : MonoBehaviour
{
    private string deviceName;

    private readonly float clipLength = 0.9f;

    private float debugMean;

    private float currentClipLength;

    private bool isBlowing;
    private bool isRecording;

    private AudioClip clip;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        UnityEngine.N3DS.Microphone.Enable();
        deviceName = Microphone.devices[0];
    }

    private void Update()
    {
        if (currentClipLength == 0)
        {
            StartRecording();
            isRecording = true;
        }
        else if (currentClipLength >= clipLength)
        {
            EndRecording();
            isRecording = false;
            currentClipLength = 0;
            isBlowing = ReadData();
        }

        if (isRecording)
            currentClipLength += Time.deltaTime;

        if (isBlowing)
        {
            Debug.Log("Blowing");

        }
        spriteRenderer.enabled = isBlowing;
    }

    // gui that displays a number
    private void OnGUI()
    {
        UnityEngine.N3DS.Microphone.IsEnabled();
        GUI.Label(new Rect(10, 10, 100, 20), debugMean.ToString());
    }



    private bool ReadData()
    {
        var data = new float[clip.samples * clip.channels];
        clip.GetData(data, 0);

        float mean = data.Select(Math.Abs).Sum();

        mean /= data.Length;

        debugMean = mean;

        return mean > 0.04f;
    }

    private void StartRecording()
    {
        int lengthSeconds = 1;
        int frequency = 32728;
        clip = Microphone.Start(deviceName, false, lengthSeconds, frequency);
    }

    private void EndRecording()
    {
        Microphone.End(deviceName);
    }

    private void OnDestroy()
    {
        UnityEngine.N3DS.Microphone.Disable();
    }
}