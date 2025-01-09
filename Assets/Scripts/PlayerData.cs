using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Data")]
    [SerializeField]
    private string playerName = "Mario";

    [SerializeField]
    private int startHearts = 3;

    [SerializeField]
    private float respawnTime = 1.0f;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float raycastDistance = 0.6f;

    public int StartHearts => startHearts; 
    public float RespawnTime => respawnTime;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public float RaycastDistance { get => raycastDistance; set => raycastDistance = value; }
    public string PlayerName { get => playerName; set => playerName = value; }

}
