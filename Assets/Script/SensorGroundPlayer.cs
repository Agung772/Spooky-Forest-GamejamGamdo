using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorGroundPlayer : MonoBehaviour
{
    public bool Ground;
    public PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        Ground = true;
        playerController.useParticleAbu = true;

        if (other.CompareTag("Ground"))
        {
            playerController.abuParticle2.Play();
        }

    }
}
