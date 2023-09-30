using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _mm;
    [SerializeField] private Image _loadingBar;
    [SerializeField] private GameObject _loadingScreenPanel;
    
    private void Start()
    {
        Time.timeScale = 1.0f;
        if(_mm != null)
        {
        _mm.Play();            
            Awake();
            Debug.Log(_mm.state);
        }
    }
    private void Awake()
    {
        if (_loadingBar == null) Debug.Log("Loading Bar is null");
    }
    public void LoadScene(string SceneName)
    {
        _loadingScreenPanel.SetActive(true);
        StartCoroutine(Load(SceneName));
    }

    IEnumerator Load(string SceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        while (!operation.isDone)
        {
            _loadingBar.fillAmount = operation.progress / 0.9f;
            yield return new WaitForEndOfFrame();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
