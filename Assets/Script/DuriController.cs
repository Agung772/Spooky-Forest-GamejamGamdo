using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuriController : MonoBehaviour
{
    public float timeUp;
    public Animator animator;

    public void Down()
    {
        animator.SetTrigger("Down");
        AudioManager.instance.SfxDuri();
        StartCoroutine(UpCoroutine());
        IEnumerator UpCoroutine()
        {
            yield return new WaitForSeconds(timeUp);
            animator.SetTrigger("Up");
        }
    }
}
