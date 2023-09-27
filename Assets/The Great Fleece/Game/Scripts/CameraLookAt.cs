using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        transform.position = new Vector3(13,20,32);
        transform.rotation = Quaternion.Euler(45,-90,0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
