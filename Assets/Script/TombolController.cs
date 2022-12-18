using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombolController : MonoBehaviour
{
    public bool tombolAktif;
    public TombolManager tombolManager;
    public new ParticleSystem particleSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !tombolAktif)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            particleSystem.Play();
            tombolAktif = true;
            tombolManager.TombolAktif();

            AudioManager.instance.SfxButtonP();
        }
    }
    public void TombolNonAktif()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        particleSystem.Stop();
    }
    public void TombolSukses()
    {
        particleSystem.Stop();
    }
}
