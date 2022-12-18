using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform pointTransform;
    public float speedForce;

    public void Projectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, pointTransform.position, pointTransform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(pointTransform.transform.forward * -speedForce, ForceMode.Impulse);
    }
}
