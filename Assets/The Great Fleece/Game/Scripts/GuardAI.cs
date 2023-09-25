using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private int _currentWaypoint;
    private NavMeshAgent _agent;
    private bool _reversePath;
    private bool _paused;
    private bool _iswalking;
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null) Debug.Log("Agent was NULL");
    }


    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        if ( ( wayPoints.Count > 0) && (wayPoints[_currentWaypoint] != null) )
        {
            _agent.destination = wayPoints[_currentWaypoint].position;
            float dist = Vector3.Distance(transform.position, wayPoints[_currentWaypoint].position);
            
            if (dist < 1
                && (_currentWaypoint == 0 || _currentWaypoint == wayPoints.Count - 1)) _animator.SetBool("walk", false);
            else _animator.SetBool("walk", true);
            
            if (dist < 1.0f && !_paused)
            {
                if ( (_currentWaypoint == 0) || (_currentWaypoint == wayPoints.Count - 1) )
                {
                    _paused = true;
                    StartCoroutine(PauseGuard());
                }
                else
                {
                    if (_reversePath)
                    {
                        _currentWaypoint--;
                        if (_currentWaypoint <= 0)
                        {
                            _reversePath = false;
                            _currentWaypoint = 0;
                        }
                    }
                    else
                    {
                        _currentWaypoint++;
                    }
                }
            }
        }
        else Debug.Log("NULL");
       
    }

    IEnumerator PauseGuard()
    {
        if (_currentWaypoint == 0)
        {
            Debug.Log("Start");
            yield return new WaitForSeconds(2.0f);
        }
        else if (_currentWaypoint == wayPoints.Count - 1)
        {
            Debug.Log("End");
            yield return new WaitForSeconds(2.0f);
        }
        else yield return null;

     
            if (_reversePath)
            {
                _currentWaypoint--;
                if(_currentWaypoint == 0)
                {
                    _reversePath = false;
                    _currentWaypoint = 0;
                }
            }
            else if(!_reversePath)
            {
                _currentWaypoint++;
                if( _currentWaypoint == wayPoints.Count)
                {
                    _reversePath = true;
                    _currentWaypoint--;
                }
            }
        _paused = false;
    }
}