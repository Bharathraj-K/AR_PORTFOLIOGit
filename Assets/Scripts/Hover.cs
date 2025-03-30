using UnityEngine;

public class GazePulseButton : MonoBehaviour
{
    private Transform raycastOrigin; // Automatically assigned AR Camera
    public float maxScale = 1.5f; // Maximum pulsing scale
    public float minScale = 1f; // Minimum scale (default size)
    public float pulseSpeed = 2f; // Speed of pulsing
    public float maxDetectionDistance = 5f; // Raycast range

    private bool isLooking = false;
    private float pulseTimer = 0f;

    void Start()
    {
        // Automatically find and assign the AR Camera
        if (Camera.main != null)
        {
            raycastOrigin = Camera.main.transform;
        }
        else
        {
            Debug.LogError("No Main Camera found! Ensure your AR Camera is tagged as 'MainCamera'.");
        }
    }

    void Update()
    {
        if (raycastOrigin == null) return; // Avoid running if no camera

        isLooking = IsLookingAtButton();

        if (isLooking)
        {
            // Pulse effect (sinusoidal expansion and shrink)
            pulseTimer += Time.deltaTime * pulseSpeed;
            float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(pulseTimer) + 1) / 2);
            transform.localScale = Vector3.one * scale;
        }
        else
        {
            // Smoothly return to normal scale
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * minScale, Time.deltaTime * 5f);
            pulseTimer = 0; // Reset timer when not looking
        }
    }

    bool IsLookingAtButton()
    {
        Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, maxDetectionDistance) && hit.transform == transform;
    }
}
