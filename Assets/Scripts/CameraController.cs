using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;
   
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
