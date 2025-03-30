using UnityEngine;

public class CylinderScroll : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust speed
    private Vector2 lastTouchPosition;
    private bool isDragging = false;

    void Update()
    {
        // Mouse Input (PC)
        if (Input.GetMouseButtonDown(0)) // Left-click pressed
        {
            lastTouchPosition = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging) // While dragging
        {
            float deltaX = Input.mousePosition.x - lastTouchPosition.x;
            transform.Rotate(Vector3.up, -deltaX * rotationSpeed * Time.deltaTime);
            lastTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) // Left-click released
        {
            isDragging = false;
        }

        // Touch Input (Mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                float deltaX = touch.position.x - lastTouchPosition.x;
                transform.Rotate(Vector3.up, -deltaX * rotationSpeed * Time.deltaTime);
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
