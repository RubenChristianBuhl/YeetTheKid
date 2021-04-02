using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetController : MonoBehaviour
{
    public Rigidbody yeetBody;
    public Vector3 minYeetVelocity = new Vector3(16, 32, 16);
    public Vector3 maxYeetVelocity = new Vector3(48, 96, 48);
    public float maxDragRatio = 0.4f;

    private Vector3 dragStartPosition;
    private bool isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPosition = Input.mousePosition;
            isDragging = true;
        }

        if (isDragging)
        {
            var dragVector = dragStartPosition - Input.mousePosition;
            var maxDragVector = maxDragRatio * new Vector2(Screen.width, Screen.height);
            var dragScale = new Vector3(
                Mathf.Clamp(dragVector.x / maxDragVector.x, -1, 1),
                Mathf.Clamp01(dragVector.magnitude / maxDragVector.magnitude),
                Mathf.Clamp(dragVector.y / maxDragVector.y, -1, 1));
            if (Input.GetMouseButtonUp(0))
            {
                var dragVelocity = Vector3.Scale(maxYeetVelocity - minYeetVelocity, dragScale);
                var yeetVelocity = minYeetVelocity + dragVelocity;
                isDragging = false;
                yeetBody.velocity = yeetVelocity;
            }
            else
            {
                
            }
        }
    }
}