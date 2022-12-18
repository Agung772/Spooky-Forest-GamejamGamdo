using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukuManager : MonoBehaviour
{
    public GameObject keris, bunga;
    public GameObject[] Pusaka;
    public int[] kondisiPusaka;
    public bool reset, resetSemua;
    int intReset;
    void Start()
    {
        if (resetSemua)
        {
            PlayerPrefs.DeleteAll();
        }
        /*
        //Reset
        intReset = PlayerPrefs.GetInt("reset");
        if (intReset == 0) reset = true; 
        else if (intReset == 1) reset = false;

        if (reset)
        {
            PlayerPrefs.SetInt("reset", 1);
            PlayerPrefs.DeleteAll();
        }
        */
        // ------------
        kondisiPusaka[0] = PlayerPrefs.GetInt("kondisi0");
        kondisiPusaka[1] = PlayerPrefs.GetInt("kondisi1");
        if (kondisiPusaka[0] == 0)
        {
            Destroy(Pusaka[0]);
        }
        if (kondisiPusaka[1] == 0)
        {
            Destroy(Pusaka[1]);
        }
        keris.SetActive(false);
        bunga.SetActive(false);


        if (Pusaka[0] == null && kondisiPusaka[0] == 0)
        {
            keris.SetActive(true);
            kondisiPusaka[0] = 1;
            PlayerPrefs.SetInt("kondisi0", kondisiPusaka[0]);
        }

        if (Pusaka[1] == null && kondisiPusaka[1] == 0)
        {
            bunga.SetActive(true);
            kondisiPusaka[1] = 1;
            PlayerPrefs.SetInt("kondisi0", kondisiPusaka[1]);
        }
    }
}
