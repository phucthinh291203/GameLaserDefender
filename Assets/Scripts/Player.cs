using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 moveInput;
    Vector2 minBound,maxBound;
    [SerializeField] float paddingLeft, paddingRight, paddingTop, paddingBottom;
    [SerializeField] float projectileSpeed = 5f;
    Shooting shooting;
    void Awake()
    {
        shooting = GetComponent<Shooting>();
    }
    void Start()
    {
        InitBound();
       
    }

    void InitBound()
    {
        Camera camera = Camera.main;
        minBound = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = camera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }

    void OnFire(InputValue value)
    {
        if(shooting != null)
        {
            shooting.isFiring = value.isPressed;
        }
    }
    void Move()
    {
        Vector2 rawInput = moveInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + rawInput.x , minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + rawInput.y, minBound.y + paddingBottom, maxBound.y - paddingTop);
        transform.position = newPos;
    }


}
