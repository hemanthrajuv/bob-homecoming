    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class samp : MonoBehaviour
{
    private AsyncOperation operation;
    // Start is called before the first frame update
    void start()
    {
        StartCoroutine(AsynchronousLoad());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator AsynchronousLoad()
    {
        operation = SceneManager.LoadSceneAsync(1);

        while (!operation.isDone)
        {

            Debug.Log(operation.progress);
            yield return null;
        }
        Debug.Log(operation.progress);
    }
}

