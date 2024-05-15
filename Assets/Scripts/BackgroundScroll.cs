using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material material;
    [SerializeField] Vector2 scrollSpeed;
    Vector2 offset;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

   
    void Update()
    {
        offset =  scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
