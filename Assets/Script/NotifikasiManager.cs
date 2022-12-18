using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotifikasiManager : MonoBehaviour
{
    public static NotifikasiManager instance;
    public GameObject notifkasiText, notifikasiDialog, notifikasiDeath;
    public float timeDestroy;
    public GameObject pauseUI;
    private void Awake()
    {
        instance = this;
    }
    bool cooldown;
    public void SpawnNotifkasi(string text)
    {
        if (!cooldown)
        {
            cooldown = true;
            GameObject notifikasiGameObject = Instantiate(notifkasiText, gameObject.transform);
            notifikasiGameObject.GetComponent<TextMeshProUGUI>().text = text;
            Destroy(notifikasiGameObject, timeDestroy);
            StartCoroutine(CooldownCoroutine());
            IEnumerator CooldownCoroutine()
            {
                yield return new WaitForSeconds(1f);
                cooldown = false;
            }
        }

    }

    public void SpawnNotifikasiDialog(string text, string text2)
    {
        GameObject notifikasiGameObject = Instantiate(notifikasiDialog, gameObject.transform);
        notifikasiGameObject.GetComponent<NotifikasiDialog>().SpawnDialog(text, text2);
    }

    public void SpawnDeath()
    {
        if (!cooldown)
        {
            cooldown = true;
            GameObject notifikasiGameObject = Instantiate(notifikasiDeath, gameObject.transform);
            Destroy(notifikasiGameObject, 7);
            StartCoroutine(CooldownCoroutine());
            IEnumerator CooldownCoroutine()
            {
                yield return new WaitForSeconds(1f);
                cooldown = false;
            }
        }

    }
}
