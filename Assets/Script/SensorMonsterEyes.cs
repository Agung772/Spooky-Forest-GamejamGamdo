using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorMonsterEyes : MonoBehaviour
{
    public MonsterEyesController EyesController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EyesController.patrol = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EyesController.OperationMonsterAyes();
        }
    }
}
