using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public bool useFollow;
    public void Follow()
    {
        if (useFollow)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, 50 * Time.deltaTime);
        }
    }
}
