using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _introCutsceneDirector;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL!");
            }


            return _instance;
        }
    }

    public bool HasCard { get; set; } //auto property
    private void Awake()
    {
        _instance = this;
        HasCard = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _introCutsceneDirector.time = 62.20f;

        }
    }
}
