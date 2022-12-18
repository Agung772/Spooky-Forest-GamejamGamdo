using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public PlayerController playerController;

    private void Start()
    {
        playerController.nonGravityDanPergerakan = true;
    }
    private void OnDisable()
    {
        playerController.nonGravityDanPergerakan = false;
    }


}
