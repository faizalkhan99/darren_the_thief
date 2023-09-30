using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _winCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.HasCard)
        {
            _winCutscene.SetActive(true);
            AudioManager.Instance.PauseBGM();
        }
    }
}
