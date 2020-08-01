using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstruction : MonoBehaviour
{
    public Transform Target, Player;
    public Transform Obstruction;
    float zoomSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ViewObstructed();
    }
    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                transform.position = Obstruction.position;
                transform.rotation = Obstruction.rotation;
            }
            else
            {
                transform.position = Target.position;
                transform.rotation = Target.rotation;
            }
        }
    }

}
