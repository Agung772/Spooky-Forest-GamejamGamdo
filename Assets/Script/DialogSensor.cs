using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSensor : MonoBehaviour
{
    public string isiDialog, isiDialog2;
    bool aktif;
    public bool aktifkanCutScene;
    public GameObject cutScene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !aktif)
        {
            aktif = true;
            NotifikasiManager.instance.SpawnNotifikasiDialog(isiDialog, isiDialog2);

            CutScene();
        }
    }

    void CutScene()
    {
        if (aktifkanCutScene)
        {
            cutScene.SetActive(true);

        }
    }
}
