using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.N3DS;

public class DialogManagerLevel0 : MonoBehaviour
{

    [SerializeField] TextAsset firstDialog;
    [SerializeField] StoryReader storyReader;
    void Start()
    {
        storyReader.StartStory(firstDialog);
    }
}
