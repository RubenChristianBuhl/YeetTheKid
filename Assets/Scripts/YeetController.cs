using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetController : MonoBehaviour
{
    public Camera mainCamera;
    public Kid kid;
    public float minDirectionVelocity = 32;
    public float maxDirectionVelocity = 64;
    public float minHeightVelocity = 32;
    public float maxHeightVelocity = 64;
    public float maxDragRatio = 0.4f;

    private Vector3 _dragStartPosition;
    private bool _isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragStartPosition = Input.mousePosition;
            _isDragging = true;
        }
        else if (_isDragging)
        {
            var maxDragVector = maxDragRatio * new Vector2(Screen.width, Screen.height);
            var dragVector = _dragStartPosition - Input.mousePosition;
            var dragScale = Mathf.Clamp01(dragVector.magnitude / maxDragVector.magnitude);
            dragVector = new Vector3(dragVector.x, 0, dragVector.y);
            dragVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * dragVector;
            if (Input.GetMouseButtonUp(0))
            {
                var directionVelocity = (maxDirectionVelocity - minDirectionVelocity) * dragScale;
                var velocity = (minDirectionVelocity + directionVelocity) * dragVector.normalized;
                velocity.y = minHeightVelocity + (maxHeightVelocity - minHeightVelocity) * dragScale;
                kid.spine.velocity = velocity;
                _isDragging = false;
            }
            else
            {
                
            }
        }
    }
}