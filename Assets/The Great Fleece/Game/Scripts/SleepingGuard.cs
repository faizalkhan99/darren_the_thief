using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGuard : MonoBehaviour
{
    public static bool _hasKeyCard = false;
    [SerializeField] private GameObject _sleepingGuardCutscene;
    private void OnTriggerEnter(Collider other)
    {
        _sleepingGuardCutscene.SetActive(true);
        _hasKeyCard = true;
        //StartCoroutine(FinalShot());
    }
    /*IEnumerator FinalShot()
    {
        yield return new WaitForSeconds(5.990f);
        Camera.main.transform.position = new Vector3(-12,14,-100);
        Camera.main.transform.rotation = Quaternion.Euler(35,-216,0);
    }*/
}
