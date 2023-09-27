using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
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
    }
}
