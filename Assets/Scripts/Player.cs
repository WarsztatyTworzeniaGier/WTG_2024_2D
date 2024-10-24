using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Data")]
    private int startHearts = 3;

    [Header("Components")]
    [SerializeField]
    private PlayerMovement movement;

    [SerializeField]
    private HealthUI healthUI;

    [Header("Stats")]
    private int currentHearts;

    private void Start()
    {
        healthUI.SetHearts(startHearts);
        currentHearts = startHearts;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Damagable"))
        {
            healthUI.RemoveHearth();
            currentHearts--;
        }
    }
}

