using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleArahController : MonoBehaviour
{
    public bool aktifkanTutor;
    public string tutor, tutor2;
    public Animator animatorPlayer;
    public PlayerController playerController;
    public Animator animator1b, animator2b;
    bool satuB, duaB, triggerSatuB, triggerDuaB;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && triggerSatuB)
        {
            if (!satuB)
            {
                satuB = true;
                animator1b.SetTrigger("Kanan");
                Condition();
            }
            else if (satuB)
            {
                satuB = false;
                animator1b.SetTrigger("Kiri");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && triggerDuaB)
        {
            if (!duaB)
            {
                duaB = true;
                animator2b.SetTrigger("Kanan");
                Condition();
            }
            else if (duaB)
            {
                duaB = false;
                animator2b.SetTrigger("Kiri");
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && aktifkanTutor)
        {
            aktifkanTutor = false;
            NotifikasiManager.instance.SpawnNotifikasiDialog(tutor, tutor2);
        }
        if (other.CompareTag("Player"))
        {
            triggerSatuB = true;

        }

        if (other.CompareTag("Player"))
        {
            triggerDuaB = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        animatorPlayer.SetBool("IdleLadder", false);

        if (other.CompareTag("Player"))
        {
            triggerSatuB = false;
        }

        if (other.CompareTag("Player"))
        {
            triggerDuaB = false;
        }
    }

    bool hasAktif;
    void Condition()
    {
        if (satuB && duaB && !hasAktif)
        {
            hasAktif = true;
            playerController.flashLightRegen = playerController.flashLight;
        }
    }
}
