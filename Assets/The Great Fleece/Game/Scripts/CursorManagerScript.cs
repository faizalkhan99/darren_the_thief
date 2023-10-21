using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManagerScript : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorTexture;
    [SerializeField] private Vector2 _hotSpot;
    void Start()
    {
        //_hotSpot = new Vector2(_cursorTexture.width/2, _cursorTexture.height);
        Cursor.SetCursor(_cursorTexture, _hotSpot, CursorMode.Auto);
    }

    void Update()
    {
        
    }
}
