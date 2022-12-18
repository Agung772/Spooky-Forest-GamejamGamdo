using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombolManager : MonoBehaviour
{
    public TombolController[] tombolControllers;
    bool[] aktif;
    public int condition;
    public PintuController pintuController;
    private void Start()
    {
        aktif = new bool[tombolControllers.Length];
    }
    public void TombolAktif()
    {
        if (tombolControllers[0].tombolAktif && !aktif[0])
        {
            aktif[0] = true;
            condition = 0;
        }
        if (tombolControllers[1].tombolAktif && !aktif[1])
        {
            aktif[1] = true;
            condition = 1;
        }
        if (tombolControllers[2].tombolAktif && !aktif[2])
        {
            aktif[2] = true;
            condition = 2;
        }

        if (tombolControllers[0].tombolAktif && tombolControllers[1].tombolAktif && tombolControllers[2].tombolAktif)
        {
            StartCoroutine(DelayCoroutine());
            IEnumerator DelayCoroutine()
            {
                yield return new WaitForSeconds(0.5f);
                if (condition == 2)
                {
                    NotifikasiManager.instance.SpawnNotifkasi("Pintu terbuka");
                    for (int i = 0; i < tombolControllers.Length; i++)
                    {
                        tombolControllers[i].TombolSukses();
                        pintuController.OpenPintu();
                    }
                }
                else
                {
                    for (int i = 0; i < aktif.Length; i++)
                    {
                        aktif[i] = false;
                    }
                    for (int i = 0; i < tombolControllers.Length; i++)
                    {
                        tombolControllers[i].tombolAktif = false;
                        tombolControllers[i].TombolNonAktif();
                    }
                }

            }
        }
    }
}
