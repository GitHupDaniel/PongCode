using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public float moveSpeed;
    
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical_p1");

        bool isPressingUp = vertical > 0;
        bool isPressingDown = vertical < 0;

        if (isPressingUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }

        if (isPressingDown)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
    }
}
