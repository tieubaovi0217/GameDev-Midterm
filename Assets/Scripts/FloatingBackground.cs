using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    private float minX, maxX, minY, maxY;
    private float speedX, speedY;
    private int directionX, directionY;
    private double maxScaleX;
    private double minScaleX;
    private double minScaleY;
    private double maxScaleY;
    private Vector3 deltaTransform;
    private float minScale, maxScale;
    private float scaleSpeedX;
    private float scaleSpeedY;

    void Start()
    {
        minX = - 0.5f;
        maxX = 0.5f;
        minY = - 0.25f;
        maxY = 0.25f;
        speedX = 0.0003f;
        speedY = 0.00015f;
        directionX = 1;
        directionY = 1;
        float scaleRangeX = 2.5f, scaleRangeY = 1.5f;
        maxScaleX = 19f + scaleRangeX;
        minScaleX = 19f - scaleRangeX;
        minScaleY = 10.35 - scaleRangeY;
        maxScaleY = 10.35 + scaleRangeY;
        deltaTransform = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
        transform.position += new Vector3(speedX * directionX, speedY * directionY, 0);
        deltaTransform += new Vector3(speedX * directionX, speedY * directionY, 0);
        transform.localScale += new Vector3(scaleSpeedX, scaleSpeedY, 0);
        checkTransform();
        checkScale();
    }

    private void checkScale()
    {
        if (transform.localScale.x < minX || transform.localScale.x > maxX)
            scaleSpeedX = -scaleSpeedX;
        if (transform.localScale.y < minY || transform.localScale.y > maxY)
            scaleSpeedY = -scaleSpeedY;
    }

    private void checkTransform()
    {
        if (deltaTransform.x < minX)
            directionX = 1;
        if (deltaTransform.x > maxX)
            directionX = -1;
        if (deltaTransform.y < minY)
            directionY = 1;
        if (deltaTransform.y > maxY)
            directionY = -1;
    }
}
