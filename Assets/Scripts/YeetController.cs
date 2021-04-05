using UnityEngine;

public class YeetController : MonoBehaviour
{
    public Camera mainCamera;
    public Kid kid;
    public GameObject arrow;
    public Renderer arrowRenderer;
    public float arrowGap = 1;
    public float minDirectionVelocity = 32;
    public float maxDirectionVelocity = 64;
    public float minHeightVelocity = 32;
    public float maxHeightVelocity = 64;
    public float maxDragRatio = 0.4f;

    private float maxIdleVelocity = 0.5f;
    private Vector3 _dragStartPosition;
    private bool _isDragging;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && kid.spine.velocity.magnitude < maxIdleVelocity)
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
            var directionVelocity = (maxDirectionVelocity - minDirectionVelocity) * dragScale;
            var velocity = (minDirectionVelocity + directionVelocity) * dragVector.normalized;
            velocity.y = minHeightVelocity + (maxHeightVelocity - minHeightVelocity) * dragScale;
            if (Input.GetMouseButtonUp(0))
            {
                kid.spine.velocity = velocity;
                _isDragging = false;
            }

            arrowRenderer.material.color = new Color(1, 1 - dragScale, 1 - dragScale);
            arrow.transform.position = kid.spine.position + velocity.normalized * arrowGap;
            arrow.transform.rotation = Quaternion.FromToRotation(Vector3.forward, velocity);
            arrow.SetActive(_isDragging);
        }
    }
}