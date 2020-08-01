using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
public class direction : MonoBehaviour
{
    public NavMeshAgent a;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public GameObject finish;
    public GameObject gates;
    public connec c;
    public GameObject home;
    float count = 2f;
    bool start_count = false;
    int target = 0;
    bool gat = true;
    public Material sb;
    void Start()
    {
        RenderSettings.skybox = sb;
        target =1;
    }
    void Update()
    {
        if (gat)
        {
            if (c.getStatus(18))
            {
                TextMeshProUGUI[] t = home.GetComponentsInChildren<TextMeshProUGUI>();
                count -= Time.deltaTime;
                Debug.Log(count);
                if (count < 2)
                {
                    t[0].color = Color.green;
                }
                if (count < 1.5f)
                {
                    t[1].color = Color.green;
                }
                if (count < 1f)
                {
                    t[2].color = Color.green;
                }
                if (count < 0.5f)
                {
                    t[3].color = Color.green;
                }

            }
            else
            {
                TextMeshProUGUI[] t = home.GetComponentsInChildren<TextMeshProUGUI>();
                for (int i = 0; i < t.Length; i++)
                {
                    t[i].color = Color.grey;
                }
                //count = 2;
            }
        }
        if (count <= 0)
        {
            gates.SetActive(false);
            gat = false;
        }
        if (!gat)
        {
            if (target1 != null && target2 != null)//&& target3!=null)
            {
                if (target == 1)
                {
                    float dist = Vector3.Distance(new Vector3(0, 0, a.gameObject.transform.position.z), new Vector3(0, 0, target1.position.z));
                    if (dist > 1)
                    {
                        a.SetDestination(target1.position);
                    }
                    else
                    {
                        target = 2;
                    }
                }
                if (target == 2)
                {
                    float dist = Vector3.Distance(new Vector3(0, 0, a.gameObject.transform.position.z), new Vector3(0, 0, target2.position.z));
                    if (dist > 1)
                    {
                        a.SetDestination(target2.position);
                    }
                    else
                    {
                        target = 3;
                    }
                }
                if (target == 3)
                {
                    float dist = Vector3.Distance(new Vector3(0, 0, a.gameObject.transform.position.z), new Vector3(0, 0, target3.position.z));
                    if (dist > 1)
                    {
                        a.SetDestination(target3.position);
                    }
                    else
                    {
                        Debug.Log("win");
                        finish.SetActive(true);
                    }
                }
            }
        }
    }
}
