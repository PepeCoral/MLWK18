using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [Header("Debug Touch")]
    [SerializeField] public bool EnableTouchDebug = true;
    [SerializeField] public GameObject TapDebugActor;
    [SerializeField] public GameObject WhilePressedDebugActor;
    [SerializeField] public GameObject EndedDebugActor;
    [SerializeField] public Camera LowerCamera;

    [Header("Resolution Options")]
    [SerializeField] public float xRes = 320;

    [SerializeField] public float yRes = 240;


    public Touch TouchInput { get; private set; }
    public Vector3 TouchLocationFromLowerCam { get; private set; }
    public bool TouchPressedThisFrame { get; private set; }
    public bool TouchReleasedThisFrame { get; private set; }

    private bool IsMouseDown = false;

    void Awake()
    {
        Touch initialTouch = new Touch();
        initialTouch.phase = TouchPhase.Canceled;

        TouchInput = initialTouch;
        TouchPressedThisFrame = false;
        TouchReleasedThisFrame = false;
    }

    // Update is called once per frame
    void Update()
    {
        Touch newTouch = TouchInput;

        //This should be executed in the DS by its touch input
        if (Input.touchCount > 0)
        {
            newTouch = Input.GetTouch(0);

            //This should be executed while in editor and using the mouse. This emulates a touch input
        }
        else if (Input.mousePresent)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            newTouch.type = TouchType.Direct;

            //Mouse Left Click starts/ends the touch phase
            if (Input.GetMouseButton(0))
            {
                //If previous frame mouse was already pressed, the touch phase has already began
                if (IsMouseDown)
                {
                    if (TouchInput.position == mousePosition)
                    {
                        newTouch.phase = TouchPhase.Stationary;
                        newTouch.position = TouchInput.position;
                    }
                    else
                    {
                        newTouch.phase = TouchPhase.Moved;
                        newTouch.position = ClampMousePositionToTouchLimits(mousePosition);
                    }
                }
                else
                {
                    IsMouseDown = true;

                    newTouch.phase = TouchPhase.Began;
                    newTouch.position = ClampMousePositionToTouchLimits(mousePosition);
                }

            }
            else if (IsMouseDown)
            {
                IsMouseDown = false;

                newTouch.phase = TouchPhase.Ended;
                newTouch.position = ClampMousePositionToTouchLimits(TouchInput.position);
            }
        }

        TouchPressedThisFrame = HasTouchStartedThisFrame(TouchInput.phase, newTouch.phase);
        TouchReleasedThisFrame = HasTouchFinishedThisFrame(TouchInput.phase, newTouch.phase);

        UpdateTouch(newTouch);

        if (EnableTouchDebug)
        {
            DoTouchDebug();
        }
    }

    void UpdateTouch(Touch touch)
    {
        TouchInput = touch;

        Vector3 WorldToScreen = LowerCamera.ScreenToWorldPoint(TouchInput.position);
        WorldToScreen.z = 0;
        
        TouchLocationFromLowerCam = WorldToScreen;
    }

    public Vector2 GetPosition()
    {

        return new Vector2(TouchInput.position.x, TouchInput.position.y);
    }
    //Clamping to the resolution -1 because the screen has xRes pixels, starting to count from 0.
    private Vector2 ClampMousePositionToTouchLimits(Vector2 mousePosition)
    {
        if (mousePosition.x < 0)
        {
            mousePosition.x = 0;
        }
        else if (mousePosition.x >= xRes)
        {
            mousePosition.x = xRes - 1;
        }

        if (mousePosition.y < 0)
        {
            mousePosition.y = 0;
        }
        else if (mousePosition.y > yRes)
        {
            mousePosition.y = yRes - 1;
        }

        return mousePosition;
    }

    private void DoTouchDebug()
    {
        //Touch position from mouse or from 3DS is in ScreenPosition.
        Vector3 spawnPosition = TouchLocationFromLowerCam;

        if (TouchPressedThisFrame)
        {
            if (TapDebugActor == null)
            {
                Debug.LogError("No TapDebugActor selected");
            }
            else
            {
                Instantiate(TapDebugActor, spawnPosition, Quaternion.identity);
            }
        }

        if (TouchReleasedThisFrame)
        {
            if (EndedDebugActor == null)
            {
                Debug.LogError("No EndedDebugActor selected");
            }
            else
            {
                Instantiate(EndedDebugActor, spawnPosition, Quaternion.identity);
            }
        }

        if (!IsTouchPhaseCanceledOrEnded(TouchInput.phase))
        {
            if (WhilePressedDebugActor == null)
            {
                Debug.LogError("No WhilePressedDebugActor selected");
            }
            else
            {
                Instantiate(WhilePressedDebugActor, spawnPosition, Quaternion.identity);
            }
        }

    }

    static bool HasTouchStartedThisFrame(TouchPhase previousPhase, TouchPhase currentPhase)
    {
        if (!IsTouchPhaseCanceledOrEnded(currentPhase))
        {
            if (IsTouchPhaseCanceledOrEnded(previousPhase))
            {
                return true;
            }
        }

        return false;
    }

    static bool HasTouchFinishedThisFrame(TouchPhase previousPhase, TouchPhase currentPhase)
    {
        if (IsTouchPhaseCanceledOrEnded(currentPhase))
        {
            if (!IsTouchPhaseCanceledOrEnded(previousPhase))
            {
                return true;
            }
        }

        return false;
    }

    static bool IsTouchPhaseCanceledOrEnded(TouchPhase phase)
    {
        return phase == TouchPhase.Canceled || phase == TouchPhase.Ended;
    }
}
