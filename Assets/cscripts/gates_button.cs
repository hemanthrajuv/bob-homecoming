using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gates_button : MonoBehaviour
{
    public connec connscript;
    bool[] btn;
    // Start is called before the first frame update
    void Start()
    {
        Button[] child = gameObject.GetComponentsInChildren<Button>();
        btn = new bool[child.Length];
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i] = false;
        }
    }

    public void btnClick(int a)
    {
        btn[a] = !btn[a];
        connscript.setStatus(a, btn[a]);
    }
    // Update is called once per frame
    void Update()
    {
        Image[] child = gameObject.GetComponentsInChildren<Image>();
        for (int i = 0; i < btn.Length; i++)
        {
            if (btn[i])
            {
                child[i].color = Color.yellow;
            }
            else
            {
                child[i].color = Color.gray;
            }
        }
    }
}
