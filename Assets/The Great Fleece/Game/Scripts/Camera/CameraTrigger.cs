using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	[SerializeField] private GameObject _player;
	[SerializeField] private Transform _cameraSwitch;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            Camera.main.transform.position = _cameraSwitch.transform.position;
            Camera.main.transform.rotation = _cameraSwitch.transform.rotation;
        }
	}
	
}
