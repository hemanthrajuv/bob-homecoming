using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class update_logic : MonoBehaviour
{

    public GameObject connection;
    [Serializable]
    public class Gates
    {
        public string name;
        public int in1;
        public int in2;
        public int ou;
    }
    public Gates[] gates;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
            }

    // Update is called once per frame
    void Update()
    {
        connec c= connection.GetComponent<connec>();
        for(int i = 0; i < 7; i++)
        {
foreach(Gates g in gates)
            {
                switch (g.name.ToUpper())
                {
                    case "AND":
                        if(c.getStatus(g.in1)&& c.getStatus(g.in2))
                        {
                            c.setStatus(g.ou, true);
                        }
                        else
                        {
                            c.setStatus(g.ou, false);
                        }
                        break;
                    case "NAND":
                        if (!(c.getStatus(g.in1) && c.getStatus(g.in2)))
                        {
                            c.setStatus(g.ou, true);
                        }
                        else
                        {
                            c.setStatus(g.ou, false);
                        }
                        break;

                    case "OR":
                        if (c.getStatus(g.in1) || c.getStatus(g.in2))
                        {
                            c.setStatus(g.ou, true);
                        }
                        else
                        {
                            c.setStatus(g.ou, false);
                        }
                        break;
                    case "NOR":
                        if (!(c.getStatus(g.in1) || c.getStatus(g.in2)))
                        {
                            c.setStatus(g.ou, true);
                        }
                        else
                        {
                            c.setStatus(g.ou, false);
                        }
                        break;

                    case "XOR":
                        if ((!c.getStatus(g.in1) && c.getStatus(g.in2))|| (c.getStatus(g.in1) && !c.getStatus(g.in2)))
                        {
                            c.setStatus(g.ou, true);
                        }
                        else
                        {
                            c.setStatus(g.ou, false);
                        }
                        break;
                    case "XNOR":
                        if (!((!c.getStatus(g.in1) && c.getStatus(g.in2)) || (c.getStatus(g.in1) && !c.getStatus(g.in2))))
                        {
                            c.setStatus(g.ou, true);
                        }
                        else
                        {
                            c.setStatus(g.ou, false);
                        }
                        break;
                    default:
                        Debug.Log("check your gate input");
                        Time.timeScale = 0;
                        break;
                }
            }
        }
    }
}
