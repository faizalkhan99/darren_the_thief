using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _voiceOver;
    private int _counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(_counter == 0)
        {
            AudioSource.PlayClipAtPoint(_voiceOver, transform.position);
            _counter += 1;
        }
        
    }
}
