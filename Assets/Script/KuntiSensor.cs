using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuntiSensor : MonoBehaviour
{
    public Transform kunti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.SfxKunti();
        }

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            kunti.GetComponent<KuntiController>().KejarPlayer();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) BackSpawn();
    }

    public void BackSpawn()
    {
        StartCoroutine(KuntiCoroutine());
        IEnumerator KuntiCoroutine()
        {
            yield return new WaitForSeconds(2);
            kunti.localPosition = kunti.GetComponent<KuntiController>().savePosisi;
            kunti.GetComponent<KuntiController>().flashlightPlayer = false;
            kunti.GetComponent<KuntiController>().kuntiPulang = false;
        }

    }
}
