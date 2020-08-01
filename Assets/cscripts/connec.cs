using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class connec : MonoBehaviour
{
    bool[] connections;
    public Transform[] cons;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] cons = gameObject.GetComponentsInChildren<Transform>();
        connections = new bool[cons.Length];
        for(int i=0;i<connections.Length;i++)
        {
            connections[i] = false;
        }
    }
    public bool getStatus(int index)
    {
        return connections[index];
    }
    public void setStatus(int index,bool value)
    {
        connections[index] = value;
    }
    // Update is called once per frame
    void Update()
    {
//Transform[] cons = gameObject.GetComponentsInChildren<Transform>();
        for(int i = 0; i < cons.Length; i++)
        {
            Transform[] go = cons[i].GetComponentsInChildren<Transform>();
            if (connections[i])
            {
                Image[] img = go[0].GetComponentsInChildren<Image>();
                foreach(Image image in img)
                {
                    image.color = Color.green;
                }
            }
            else
            {
                Image[] img = go[0].GetComponentsInChildren<Image>();
                foreach (Image image in img)
                {
                    image.color = Color.red;
                }
            }
        }
    }
   
}
