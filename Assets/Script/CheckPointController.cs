using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Animator animator;
    bool aktif;
    private void OnTriggerEnter(Collider other)
    {
        if (!aktif)
        {
            if (other.CompareTag("Player"))
            {
                aktif = true;
                animator.SetTrigger("Aktif");
                GameManager.instance.savePosisiPlayer = new Vector3(transform.position.x, transform.position.y, GameManager.instance.savePosisiPlayer.z);
                NotifikasiManager.instance.SpawnNotifkasi("Berhasil buka Check Point");
            }
        }

    }
}
