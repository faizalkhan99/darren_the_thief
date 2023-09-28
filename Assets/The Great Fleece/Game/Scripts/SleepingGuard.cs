using UnityEngine;

public class SleepingGuard : MonoBehaviour
{
    [SerializeField] private GameObject _sleepingGuardCutscene;
    private void OnTriggerEnter(Collider other)
    {
        _sleepingGuardCutscene.SetActive(true);
        GameManager.Instance.HasCard = true;
        
    }
}
