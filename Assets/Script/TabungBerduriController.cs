using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabungBerduriController : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Aktif", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Aktif", false);
        }
    }
}
