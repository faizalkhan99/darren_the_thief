using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _voiceOver;
    private int _counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(_counter == 0)
        {
            AudioManager.Instance.PlayVooiceOver(_voiceOver);
            _counter += 1;
        }
        
    }
}
