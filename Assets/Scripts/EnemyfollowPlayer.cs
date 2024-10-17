using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyfollowPlayer : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform player;

    void Update()
    {
        Enemy.SetDestination(player.position);
    }
}
