using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class def : MonoBehaviour
{
    public GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        LoadingScreenBarSystem lss = loadingScreen.GetComponent<LoadingScreenBarSystem>();
        lss.loadingScreen(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
