using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] private Image _loadingBar;   
    void Start()
    {
        StartCoroutine(Load());    
    }

    IEnumerator Load()
    {
        Debug.Log("Loading...");
        AsyncOperation operation = SceneManager.LoadSceneAsync(2); // To Game Scene

        while (!operation.isDone)
        {
            _loadingBar.fillAmount = operation.progress;
        }
        yield return new WaitForEndOfFrame();
    }

}
