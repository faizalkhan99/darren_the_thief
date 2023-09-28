using UnityEngine;

public class SecurityCameras : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _redDuration;
    [SerializeField] private float _yellowDuration;

    [SerializeField] private Animator animator;
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] private AudioClip _bgm;
    [SerializeField] private GameObject _gameOverCutscene;

    [SerializeField] private Transform _securityCameraParent;
    [SerializeField] private Animator _parentAnim;
    [SerializeField] private float _rotY;
    private void Start()
    {
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
                        animator.speed = 0f;
                    }
                else if (_timer > _redDuration)
                    {
                        meshRenderer.material.SetColor("_TintColor", new Color(1f, 0, 0, 10 / 255f));
                        animator.speed = 0f;
                        if (_timer > _redDuration + 0.1f) 
                        {
                            AudioManager.Instance.PauseBGM(_bgm);
                            _gameOverCutscene.SetActive(true);
                            //Caught();
                        }
                    }
                else
                {
                    animator.speed = 1.0f;
                }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        meshRenderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 137 / 255f, 10 / 255f));
        animator.speed = 1.0f;
        _timer = 0f;
    }

    private void Caught()
    {
        
        _parentAnim.gameObject.SetActive(false);
        _securityCameraParent.rotation = Quaternion.Euler(0, _rotY, 0);
        meshRenderer.material.SetColor("_TintColor", new Color(1f, 0, 0, 10 / 255f));
    }
}