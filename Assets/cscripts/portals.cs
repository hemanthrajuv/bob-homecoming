using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portals : MonoBehaviour
{
    GameObject center;
    generate_wave gw;
    static float wait_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("center");
        gw = center.GetComponent<generate_wave>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wait_time > 0)
        {
            wait_time -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (wait_time <= 0)
        {
            if (gameObject.name == "portallu" && other.tag == "Player")
            {
                wait_time = 1;
                gw.showStep(1);
            }
            if (gameObject.name == "portalld" && other.tag == "Player")
            {
                wait_time = 1;
                Debug.Log('1');
                gw.showStep(2);
            }
            if (gameObject.name == "portalru" && other.tag == "Player")
            {
                wait_time = 1;
                gw.showStep(3);
            }
            if (gameObject.name == "portalrd" && other.tag == "Player")
            {
                wait_time = 1;
                Debug.Log('2');
                gw.showStep(4);
            }
            if (gameObject.name == "portall2" && other.tag == "Player")
            {
                wait_time = 1;
                Debug.Log('2');
                gw.showStep(5);
            }
            if (gameObject.name == "portalr2" && other.tag == "Player")
            {
                wait_time = 1;
                Debug.Log('2');
                gw.showStep(6);
            }
        }
    }

}
