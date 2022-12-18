using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerController : MonoBehaviour
{
    int limitNotif = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && limitNotif > 0)
        {
            limitNotif--;
            NotifikasiManager.instance.SpawnNotifkasi("Tekan F untuk mengisi ulang Baterai Senter");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            other.GetComponent<PlayerController>().flashLightRegen = other.GetComponent<PlayerController>().flashLight;
            NotifikasiManager.instance.SpawnNotifkasi("Baterai kamu sudah full");
        }
    }
}
