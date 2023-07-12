using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] private Vector2 velocity;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D playerRB;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        //playerRB= GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        offset = velocity * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
