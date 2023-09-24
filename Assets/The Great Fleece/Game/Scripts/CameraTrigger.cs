using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	[SerializeField] private GameObject _player;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Debug.Log("Trigger was triggered");
		}
	}
}
