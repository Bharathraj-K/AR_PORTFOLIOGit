using UnityEngine;

public class FaceCameraDetails : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Automatically find and assign the AR Camera
        cameraTransform = Camera.main?.transform;
    }

    void Update()
    {
        if (cameraTransform == null) return;

        // Get direction to the camera
        Vector3 direction = cameraTransform.position - transform.position;

        // Calculate the rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Flip the X-axis rotation to correct the inversion
        targetRotation = Quaternion.Euler(-targetRotation.eulerAngles.x, 0, 0); 

        // Apply the fixed rotation
        transform.rotation = targetRotation;
    }
}
