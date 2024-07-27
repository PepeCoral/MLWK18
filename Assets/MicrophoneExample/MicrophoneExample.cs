using UnityEngine;
using System.Collections;

public class MicrophoneExample : MonoBehaviour
{
	void Start()
	{
		foreach (string device in Microphone.devices)
		{
			Debug.Log("Found Microphone: '" + device + "'");
		}

		audioSource = GetComponent<AudioSource>();
	}
	
	int frequency = 32728; // 8182

	// void OnGUI()
	// {
	// 	int xpos = 160 - (width / 2);
	// 	int ypos = 40;
		
	// 	int minFreq, maxFreq;
	// 	Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq);	
	// 	GUI.Label(new Rect(5, 5, 160, 40), minFreq + " - " + maxFreq);
		
		
	// 	if (ButtonPressed(xpos, ref ypos, "Power On: ", ref isPowerEnabled))
	// 	{
	// 		if (isPowerEnabled)
	// 		{
	// 			UnityEngine.N3DS.Microphone.Enable();
	// 		}
	// 		else
	// 		{
	// 			UnityEngine.N3DS.Microphone.Disable();
	// 		}
	// 		deviceName = Microphone.devices[0];
	// 	}

	// 	if (isPowerEnabled)
	// 	{
	// 		if (Microphone.IsRecording(deviceName) == false)
	// 		{
	// 			if (ButtonPressed(xpos, ref ypos, "Start Recording"))
	// 			{
	// 				bool loop = false;
	// 				int lengthSeconds = 3;
	// 				audioSource.clip = Microphone.Start(deviceName, loop, lengthSeconds, frequency);
	// 				hasRecorded = true;
	// 			}
	// 		}
	// 		else
	// 		{
	// 			if (ButtonPressed(xpos, ref ypos, "Stop Recording"))
	// 			{
	// 				Microphone.End(deviceName);
	// 			}
	// 		}
	// 	}

	// 	if (hasRecorded)
	// 	{
	// 		if (ButtonPressed(xpos, ref ypos, "Play"))
	// 		{
	// 			audioSource.Play();
	// 		}
	// 	}
		
	// 	frequency = (int)GUI.HorizontalSlider(new Rect(5, 50, width - 30, height), frequency, 0, 100);
	// }

	private bool ButtonPressed(int xpos, ref int ypos, string label)
	{
		bool result = GUI.Button(new Rect(xpos, ypos, width, height), label);
		ypos += height + spacingV;
		return result;
	}

	private bool ButtonPressed(int xpos, ref int ypos, string label, ref bool flag)
	{
		bool result = false;
		if (GUI.Button(new Rect(xpos, ypos, width, height), label + flag))
		{
			flag = !flag;
			result = true;
		}
		ypos += height + spacingV;
		return result;
	}

	private string deviceName = null;
	private AudioSource audioSource;

	private bool isPowerEnabled;
	private bool hasRecorded;

	private const int width = 120;
	private const int height = 32;
	private const int spacingV = 10;
}
