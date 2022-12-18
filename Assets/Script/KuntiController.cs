using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuntiController : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 savePosisi;
    public KuntiSensor kuntiSensor;
    public float speedKunti;
    public bool flashlightPlayer, kuntiPulang;
    private void Start()
    {
        savePosisi = transform.localPosition;
        speedKunti += Random.Range(0, 3);
    }
    public void KejarPlayer()
    {
        if (kuntiPulang)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerTarget.position, -speedKunti * 1.5f * Time.deltaTime);
        }
        else if (flashlightPlayer && playerTarget != null)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerTarget.position, -speedKunti * 1.5f * Time.deltaTime);
        }
        else if (!flashlightPlayer && playerTarget != null)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerTarget.position, speedKunti * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AntiKunti"))
        {
            kuntiPulang = true;
        }

        if (other.CompareTag("SensorFlashlight") && playerTarget.GetComponent<PlayerController>().useFlashLight)
        {
            flashlightPlayer = true;
        }
        else
        {
            StartCoroutine(FlashlightPlayerCoroutine());
            IEnumerator FlashlightPlayerCoroutine()
            {
                yield return new WaitForSeconds(0.7f);
                flashlightPlayer = false;
            }

        }
    }
}
