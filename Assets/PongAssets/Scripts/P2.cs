using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        float verticalP2 = Input.GetAxisRaw("Vertical_p2");

        bool isPressingUp = verticalP2 > 0;
        bool isPressingDown = verticalP2 < 0;

        if (isPressingUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }

        if (isPressingDown)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }


    }
    void Start()
    {
        string[] joystickNames = Input.GetJoystickNames();
        for (int i = 0; i < joystickNames.Length; i++)
        {
            Debug.Log("Joystick " + (i + 1) + ": " + joystickNames[i]);
        }
    }
    }
