using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SleepingGuard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _alreadyHasCard;
    [SerializeField] private GameObject _grabButton;
    [SerializeField] private GameObject _sleepingGuardCutscene;

    private bool _hasEntered = false;
    private void Start()
    {
        _alreadyHasCard.text = "";
        _grabButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.HasCard && !_hasEntered)
        {
            _grabButton.SetActive(true);
        }
        else if(GameManager.Instance.HasCard && _hasEntered)
        {
            _alreadyHasCard.text = "You have the card. Now escape!";
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        _alreadyHasCard.text = "";
        _grabButton.SetActive(false);
    }

    public void GrabKeyCard()
    {
        _sleepingGuardCutscene.SetActive(true);
        GameManager.Instance.HasCard = true;
        _hasEntered = true;
        Debug.Log("after cutscene");
        _alreadyHasCard.text = "";
        _grabButton.SetActive(false);
    }
}
