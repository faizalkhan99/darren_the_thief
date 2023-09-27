using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SecurityCameras : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _redDuration;
    [SerializeField] private float _yellowDuration;

    [SerializeField] private Animator animator;
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] private GameObject _gameOverCutscene;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerStay(Collider other)
    {
            if (other.CompareTag("Player"))
                {
                _timer += Time.deltaTime;
                if (_timer >= _yellowDuration && _timer < _redDuration)
                {
                    Debug.Log("yellow if statement");
                    meshRenderer.material.SetColor("_TintColor", Color.yellow);
                    animator.speed = 0f;
                }
                else if (_timer > _redDuration)
                {
                    Debug.Log("red if statement");
                    meshRenderer.material.SetColor("_TintColor", Color.red);
                    animator.speed = 0f;
                    if(_timer > _redDuration + 0.5f) _gameOverCutscene.SetActive(true);
                }
                else
                {
                    //_timer = 0.0f;
                    Debug.Log("white else statement");
                    //meshRenderer.material.color = Color.white;
                    animator.speed = 1.0f;
                }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        meshRenderer.material.SetColor("_TintColor", Color.white);
        animator.speed = 1.0f;
        _timer = 0f;
    }
}
