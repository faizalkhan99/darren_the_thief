using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCutscene;
    [SerializeField] private AudioClip _bgm;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ice pice bitch");
            _gameOverCutscene.SetActive(true);
            AudioManager.Instance.PauseBGM(_bgm);
        }
    }
}
