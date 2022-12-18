using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public ParticleSystem efectSentuhan, projectile;

    private void Start()
    {
        AudioManager.instance.SfxProjectile();
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        efectSentuhan.Play();
        projectile.Stop();
        Destroy(gameObject, 1f);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        StartCoroutine(stopCoroutine());
        IEnumerator stopCoroutine()
        {
            yield return new WaitForSeconds(0.3f);
            efectSentuhan.Stop();
        }

    }
}
