using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _winCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && SleepingGuard._hasKeyCard)
        {
            _winCutscene.SetActive(true);
        }
    }
}
