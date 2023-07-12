using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public GameObject platform;
    public Transform start;
    public Transform end;
    public float velocity;
    private Vector3 direction;

    void Start()
    {
        direction = end.position; 
    }

    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, direction, velocity * Time.deltaTime);

        if(platform.transform.position == end.position)
        {
            direction = start.position;
        }

        if (platform.transform.position == start.position)
        {
            direction = end.position;
        }
    }
}
