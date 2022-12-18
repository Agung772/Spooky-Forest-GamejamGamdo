using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuController : MonoBehaviour
{
    public Animator animator;

    public void OpenPintu()
    {
        animator.SetTrigger("Open");

        AudioManager.instance.SfxPintu();
    }
    public void ClosePintu()
    {
        animator.SetTrigger("Close");
    }
}
