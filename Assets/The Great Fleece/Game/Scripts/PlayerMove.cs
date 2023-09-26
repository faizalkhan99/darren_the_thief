using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
	[SerializeField] private GameObject _coin;
	[SerializeField] public static bool _hasCoin = true;
	
	private NavMeshAgent _agent;
	
	private Animator _animator;
	
	private Vector3 _target;

	[SerializeField] private AudioClip _coinFlip;
    void Start () 
	{
		_animator = GetComponentInChildren<Animator>();
		_animator.SetBool("walk", false);
		_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				_agent.destination = hit.point;
				_target = hit.point;
				_animator.SetBool("walk", true);
			}
		}
			if (Vector3.Distance(transform.position, _target) < 1.5f)
			{
				_animator.SetBool("walk", false);
			}
		if(Input.GetKeyDown(KeyCode.Mouse1) && _hasCoin) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
				_hasCoin = false;
				//_animator.SetTrigger("throw");
                Instantiate(_coin, hit.point,Quaternion.identity);
				AudioSource.PlayClipAtPoint(_coinFlip, hit.point);
            }
        }
	
	
	}


}
