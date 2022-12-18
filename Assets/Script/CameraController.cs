using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public new Camera camera;
    public Transform playerTarget;
    public float speedCam, speedFieldCam;
    public Vector3 offset;
    public bool aktifCamIn;

    private void Start()
    {
        if (aktifCamIn) CaneraIn();
    }
    public Animator animator;
    void Update()
    {
        if (playerTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position, playerTarget.position + offset, speedCam * Time.deltaTime);
        }

    }
    bool cooldownCamOut;
    public void CameraOut()
    {
        if (!cooldownCamOut)
        {
            cooldownCamOut = true;
            animator.SetTrigger("Out");
        }


    }

    public void CaneraIn()
    {
        animator.SetTrigger("In");
    }
}
