using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEyesController : MonoBehaviour
{
    public Transform followPlayer, playerTarget;
    public float speedPatrol, min, max;
    float direction = 1;
    public bool patrol;

    public SpawnProjectile spawnProjectile;
    public void OperationMonsterAyes()
    {
        if (!patrol)
        {
            followPlayer.position = Vector3.MoveTowards(transform.position, playerTarget.position, 100 * Time.deltaTime);
        }
        else if (patrol)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            if ((int)transform.eulerAngles.y == max || (int)transform.eulerAngles.y == max + 15)
            {
                direction = -1;
            }
            if ((int)transform.eulerAngles.y == min || (int)transform.eulerAngles.y == min - 15)
            {
                direction = 1;
            }
            transform.Rotate(Vector3.up * speedPatrol * direction * Time.deltaTime);

        }
    }
    bool cooldown;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            patrol = false;
            
            if (!cooldown)
            {
                StartCoroutine(projectileCoroutine());
                IEnumerator projectileCoroutine()
                {
                    cooldown = true;
                    yield return new WaitForSeconds(0.2f);
                    spawnProjectile.Projectile();
                    yield return new WaitForSeconds(0.1f);
                    cooldown = false;
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MonsterCoroutine());
            IEnumerator MonsterCoroutine()
            {
                yield return new WaitForSeconds(0);
                patrol = true;
            }

        }
    }
}
