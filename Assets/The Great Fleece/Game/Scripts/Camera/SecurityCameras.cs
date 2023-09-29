using UnityEngine;

public class SecurityCameras : MonoBehaviour
{

    [SerializeField] private float _timer;
    [SerializeField] private float _redDuration;
    [SerializeField] private float _yellowDuration;
    
    [SerializeField] private bool _isCaught = false;

    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] private AudioClip _bgm;

    [SerializeField] private GameObject _gameOverCutscene;

    [SerializeField] private Animator _parentAnim;
    private void Start()
    {
        _parentAnim = GetComponentInParent<Animator>(); 
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _timer += Time.deltaTime;
            if (_timer >= _yellowDuration && _timer < _redDuration)
            {
                meshRenderer.material.SetColor("_TintColor", new Color(1f, 1f, 0, 10 / 255f));
                _parentAnim.speed = 0f;
            }
            else if (_timer > _redDuration)
            {
                meshRenderer.material.SetColor("_TintColor", new Color(1f, 0, 0, 10 / 255f));
                _parentAnim.speed = 0f;
                if (_timer > _redDuration + 0.1f)
                {
                    AudioManager.Instance.PauseBGM(_bgm);
                    _gameOverCutscene.SetActive(true);
                    _parentAnim.speed = 1f;
                    SecurityCameras[] array = FindObjectsOfType<SecurityCameras>();
                    foreach (SecurityCameras c in array)
                    {
                        c.Caught();
                    }
                    
                }
            }


        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (!_isCaught)
        {
            meshRenderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 137 / 255f, 10 / 255f));
            _parentAnim.speed = 1.0f;
            _timer = 0f;
        }

    }

    private void Caught()
    {
        _isCaught = true;
        meshRenderer.material.SetColor("_TintColor", new Color(1f, 0, 0, 10 / 255f));
    }
}