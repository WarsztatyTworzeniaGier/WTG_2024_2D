using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerData data;
   
    [Header("Components")]
    [SerializeField]
    private PlayerMovement movement;

    [SerializeField]
    private HealthUI healthUI;

    [Header("Stats")]
    private int currentHearts;


    private Vector3 spawnPosition;

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        transform.DOScale(Vector3.zero, 0.2f).SetUpdate(true);
        transform.DOMove(spawnPosition, data.RespawnTime).SetUpdate(true);
        transform.DORotate(Vector3.zero, data.RespawnTime).SetUpdate(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(data.RespawnTime);
        transform.DOScale(Vector3.one, 0.2f).SetUpdate(true);
        yield return new WaitForSecondsRealtime(0.2f);
        movement.ResetVelocity();
        Time.timeScale = 1f;
        currentHearts = data.StartHearts;
        healthUI.SetHearts(currentHearts);
    }

    private void Start()
    {
        spawnPosition = transform.position;
        healthUI.SetHearts(data.StartHearts);
        currentHearts = data.StartHearts;
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Damagable"))
        {
            healthUI.RemoveHeart();
            currentHearts--;
            GameManager.Instance.IncreaseDeathCount();

            if(currentHearts <= 0)
            {
                StartRespawn();
            }
        }
    }
}

