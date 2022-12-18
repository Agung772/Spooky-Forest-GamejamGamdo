using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderuwoController : MonoBehaviour
{
    public Animator animator;
    bool cooldownAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Nongol", true);
            if (!cooldownAudio)
            {
                cooldownAudio = true;
                AudioManager.instance.SfxGundoruwo();
                StartCoroutine(cooldownCoroutine());
                IEnumerator cooldownCoroutine()
                {
                    yield return new WaitForSeconds(3f);
                    cooldownAudio = false;

                }
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Nongol", false);
        }
    }
}
