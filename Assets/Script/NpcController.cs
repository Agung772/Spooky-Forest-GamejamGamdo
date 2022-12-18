using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public Transform playerTarget, npcDesign;
    public float speedNpc;
    public Vector3 offset;
    public ParticleSystem particleAwal, particleAwal2, particleTrail, particleTrail2;
    public GameObject trailPlayer;
    public GameObject[] trail;
    public GameObject animasiPuter;

    
    IEnumerator Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        particleAwal.Play();
        yield return new WaitForSeconds(0.8f);
        particleAwal2.Play();
        yield return new WaitForSeconds(0.1f);
        npcDesign.GetComponent<Animator>().SetBool("Spawn", true);
        yield return new WaitForSeconds(0.5f);
        animasiPuter.SetActive(true);
        particleTrail.Play();
        particleTrail2.Play();
        trailPlayer.SetActive(true);
    }

    public void UnSpawn()
    {
        StartCoroutine(UnSpawnCoroutine());
    }
    IEnumerator UnSpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        npcDesign.GetComponent<Animator>().SetBool("Spawn", false);
        trailPlayer.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        particleAwal2.Play();
        animasiPuter.SetActive(false);
        particleTrail.Stop();
        particleTrail2.Stop();
        yield return new WaitForSeconds(0.5f);
        playerController.PlayerOperation = true;
        Destroy(gameObject);
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, playerTarget.position + offset, speedNpc * Time.deltaTime);
    }

    public void FlipNPCRight()
    {
        npcDesign.localEulerAngles = Vector3.up * 180;
    }
    public void FlipNPCLeft()
    {
        npcDesign.localEulerAngles = Vector3.zero;
    }

    public void TrailOn()
    {
        for (int i = 0; i < trail.Length; i++)
        {
            trail[i].SetActive(true);
        }
    }

    public void TrailOff()
    {
        for (int i = 0; i < trail.Length; i++)
        {
            trail[i].SetActive(false);
        }
    }
    PlayerController playerController;
    private void OnEnable()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.PlayerOperation = false;
        playerController.animator.SetBool("Idle", true);
        playerController.animator.SetBool("Walking", false);
    }
}
