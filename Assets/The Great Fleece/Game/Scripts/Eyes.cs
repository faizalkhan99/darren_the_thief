using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCutscene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameOverCutscene.SetActive(true);
            AudioManager.Instance.PauseBGM();
        }
    }
}
