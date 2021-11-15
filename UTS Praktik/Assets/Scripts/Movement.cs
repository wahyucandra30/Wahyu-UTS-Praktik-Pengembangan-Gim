// ================================================================================================================
// UTS Praktik - Movement.cs
// 
// Author: Wahyu Candra
// Date:   11/11/2021
// ================================================================================================================
using System;
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(0f, 16f)]
    [SerializeField] private float moveSpeed;
    [Range(0f, 1f)]
    [SerializeField] private float flipSpeed;
    [SerializeField] private float xPadding;
    [SerializeField] private Direction startDirection;
    private Vector2 dir;
    private Camera cam;
    private float xScale;
    private event Action OnBoundReached;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        switch (startDirection)
        {
            case (Direction.Right):
                dir = Vector2.right;
                xScale = transform.localScale.x;
                break;
            case (Direction.Left):
                dir = Vector2.left;
                xScale = -transform.localScale.x;
                break;
        }
    }

    private void OnEnable()
    {
        OnBoundReached += FlipDirection;
    }

    private void OnDisable()
    {
        OnBoundReached -= FlipDirection;
    }

    private void Update()
    {
        ClampMovement();
        ApplyMovement();
        HandleVisualOrientation();
    }

    private void ApplyMovement()
    {   
        Vector3 displacement = moveSpeed * Time.deltaTime * dir.normalized;
        transform.position += displacement;
    }

    private void ClampMovement()
    {
        Vector2 screenPoint = cam.WorldToScreenPoint(transform.position);
        if(screenPoint.x <= xPadding || screenPoint.x >= Screen.width - xPadding)
        {
            FlipDirection();
        }
    }

    private void FlipDirection()
    {
        dir.x *= -1;
        StartCoroutine(FlipVisual());
    }

    private IEnumerator FlipVisual()
    {
        xScale = transform.localScale.x;
        float targetXScale = -xScale;
        float t = 0;
        yield return new WaitForEndOfFrame();
        while(!Mathf.Approximately(xScale, targetXScale))
        {
            t += Time.deltaTime;
            xScale = Mathf.Lerp(xScale, targetXScale, t * flipSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    private void HandleVisualOrientation()
    {
        transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
    }

    private enum Direction
    {
        Right, 
        Left
    }
}
