using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Access the PlayerHealth instance and call TakeHit
            Playerhealth.Instance.TakeHit();
        }
    }
}
