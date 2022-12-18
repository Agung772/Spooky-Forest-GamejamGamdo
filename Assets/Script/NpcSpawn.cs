using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawn : MonoBehaviour
{
    public GameObject npcPrefab;
    public NpcController npcController;
    public PlayerController playerController;
    int changeButton;
    bool cooldown;
    public void SpawnNpc()
    {
        if (!cooldown)
        {
            cooldown = true;
            StartCoroutine(cooldownCoroutine());
            IEnumerator cooldownCoroutine()
            {
                yield return new WaitForSeconds(2);
                cooldown = false;
            }
            if (changeButton == 0)
            {
                Instantiate(npcPrefab, transform.position, transform.rotation);
                npcController = GameObject.FindGameObjectWithTag("NPC").GetComponent<NpcController>();
                playerController.RefrensNpcController();

                changeButton = 1;
            }
            else if (changeButton == 1)
            {
                UnSpawnNpc();
                changeButton = 0;
            }
        }


    }

    public void SpawnNpcDialog()
    {
        Instantiate(npcPrefab, transform.position, transform.rotation);
        npcController = GameObject.FindGameObjectWithTag("NPC").GetComponent<NpcController>();
        playerController.RefrensNpcController();
    }
    public void UnSpawnNpc()
    {
        npcController.UnSpawn();
    }
}
