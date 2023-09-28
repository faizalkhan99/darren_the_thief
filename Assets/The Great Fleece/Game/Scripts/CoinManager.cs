using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private AudioClip _coinpickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove._hasCoin = true;
            AudioSource.PlayClipAtPoint(_coinpickup,Camera.main.transform.position);
            Destroy(gameObject, 0.5f);
        }
    }
}
