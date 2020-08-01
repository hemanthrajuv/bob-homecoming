using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 speed;
    public float x, y,sp=2;
    bool forward = true;
    void Update()
    {
        speed = new Vector3(0.5f, 0, 0) * Time.deltaTime * sp;
        if (transform.position.x >= x)
        {
            forward = false;
        }
        else if (transform.position.x <= y)
        {
            forward = true;
        }
        if (forward)
        {
            transform.Translate(speed);
        }
        else
        {
            transform.Translate(-speed);
        }
    }
}
