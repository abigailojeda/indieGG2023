using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, 0, 80),0, transform.position.z);
    }
}
