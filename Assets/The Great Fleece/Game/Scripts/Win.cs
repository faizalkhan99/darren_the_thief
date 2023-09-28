using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _winCutscene;
    [SerializeField] private AudioClip _bgm;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.HasCard)
        {
            _winCutscene.SetActive(true);
            AudioManager.Instance.PauseBGM(_bgm);
        }
    }
}
