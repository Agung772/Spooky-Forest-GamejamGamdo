using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotifikasiDialog : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI notifikasiText, buttonText;
    public NpcSpawn npcSpawn;
    public float DestroyDelay, timeDestroy;
    string Text2;

    private void Awake()
    {
        npcSpawn = GameObject.FindGameObjectWithTag("NpcSpawn").GetComponent<NpcSpawn>();



        timeDestroy = DestroyDelay;
    }

    private IEnumerator Start()
    {
        if (Text2 != "")
        {
            timeDestroy += 5;
            DestroyDelay += 5;
        }
        StartCoroutine(DestroyCoroutine());
        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(DestroyDelay);
            DestroyDialog();
        }
        yield return new WaitForSeconds(5);
        if (Text2 != "")
        {
            notifikasiText.text = Text2;

        }


    }
    private void Update()
    {
        timeDestroy -= Time.deltaTime;
        buttonText.text = "Enter " + "(" + (int)timeDestroy +")";
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            DestroyDialog();

            AudioManager.instance.SfxBuutonUI();
        }

    }
    public void SpawnDialog(string text, string text2)
    {
        notifikasiText.text = text;
        Text2 = text2;
        npcSpawn.SpawnNpcDialog();

    }
    public void DestroyDialog()
    {
        animator.SetTrigger("Keluar");
        Destroy(gameObject, 1);
        npcSpawn.UnSpawnNpc();

    }

}
