using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if( _instance == null)
            {
                Debug.LogError("UIManager is NULL!");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_pauseCanvas == null) Debug.Log("pause canvas is null");
        _instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0); //0 = MainMenuScene
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play(string SceneName)
    {

        SceneManager.LoadScene(SceneName); //To Loading Screen
    }

    [SerializeField] private bool _isPaused = false;
    [SerializeField] private GameObject _pauseCanvas;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                _isPaused = true;
                _pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
                AudioManager.Instance.PauseBGM();
            }
            else
            {
                _isPaused = false;
                _pauseCanvas.SetActive(false);
                Time.timeScale = 1f;
                AudioManager.Instance.PlayBGM();
            }
        }
    }




}