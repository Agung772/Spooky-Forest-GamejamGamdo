using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuasManager : MonoBehaviour
{
    public TuasController[] tuasController;
    public bool tuas1, tuas5, tangga, tanggaNonNotif;
    public Rigidbody rbKotak;
    public void TuasCondition()
    {
        if (tuas1)
        {
            if (tuasController[0].tuasAktif)
            {
                rbKotak.useGravity = true;
                NotifikasiManager.instance.SpawnNotifkasi("Kotaknya sudah jatuh");
            }
        }
        else if (tuas5)
        {
            if (tuasController[1].tuasAktif && tuasController[3].tuasAktif && !tuasController[0].tuasAktif && !tuasController[2].tuasAktif)
            {
                rbKotak.useGravity = true;
                NotifikasiManager.instance.SpawnNotifkasi("Kotaknya sudah jatuh");
            }
        }
        else if (tangga)
        {
            if (tuasController[0].tuasAktif)
            {
                rbKotak.useGravity = true;
                NotifikasiManager.instance.SpawnNotifkasi("Ada tangga jatuh");
            }
        }
        else if (tanggaNonNotif)
        {
            if (tuasController[0].tuasAktif)
            {
                rbKotak.useGravity = true;
            }
        }
    }
}
