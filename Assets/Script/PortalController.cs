using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalController : MonoBehaviour
{
    public float nextLevel, delayPortal;
    public CameraController cameraController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalCoroutine());
            IEnumerator PortalCoroutine()
            {
                AudioManager.instance.SfxPortal();
                cameraController.CameraOut();
                
                yield return new WaitForSeconds(delayPortal);
                GameManager.instance.SceneLevel(GameManager.instance.iniSceneBerapa);
            }
        }
    }
}
