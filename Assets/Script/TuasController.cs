using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuasController : MonoBehaviour
{
    public bool tuasAktif;
    public Animator animator;
    public Animator animatorPlayer;
    public TuasManager tuasManager;
    public bool cooldown;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && !cooldown)
        {
            if (other.CompareTag("Player"))
            {
                cooldown = true;
                StartCoroutine(Cooldown());
                IEnumerator Cooldown()
                {
                    yield return new WaitForSeconds(0.5f);
                    cooldown = false;
                }

                if (!tuasAktif)
                {
                    tuasAktif = true;

                    animator.SetBool("Tuas", true);
                    animatorPlayer.SetBool("IdleLadder", true);
                    tuasManager.TuasCondition();

                    AudioManager.instance.SfxTuasP();

                    print("tuas jalan");
                }
                else if (tuasAktif)
                {
                    tuasAktif = false;

                    animator.SetBool("Tuas", false);
                    animatorPlayer.SetBool("IdleLadder", true);
                    tuasManager.TuasCondition();

                    AudioManager.instance.SfxTuasP();

                    print("tuas jalan");
                }
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        animatorPlayer.SetBool("IdleLadder", false);
    }
}
