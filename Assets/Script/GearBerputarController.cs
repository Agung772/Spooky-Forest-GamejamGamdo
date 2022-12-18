using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBerputarController : MonoBehaviour
{
    public Animator animator, animatorRotate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Aktif", true);
            animatorRotate.SetBool("Aktif", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Aktif", false);
            animatorRotate.SetBool("Aktif", false);
        }
    }
}
