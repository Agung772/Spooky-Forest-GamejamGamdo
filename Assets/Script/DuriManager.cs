using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuriManager : MonoBehaviour
{
    public DuriController[] DuriControllers;
    bool cooldown;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !cooldown)
        {
            cooldown = true;
            StartCoroutine(OperationDuriCoroutine());
            IEnumerator OperationDuriCoroutine()
            {
                yield return new WaitForSeconds(1f);
                DuriControllers[0].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[1].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[2].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[3].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[4].Down();
                yield return new WaitForSeconds(3f);
                DuriControllers[4].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[3].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[2].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[1].Down();
                yield return new WaitForSeconds(1f);
                DuriControllers[0].Down();
                yield return new WaitForSeconds(3f);
                cooldown = false;
            }
        }
    }
}
