using UnityEngine;

public class SmoothFollowTarget : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 200f;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smoothSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * smoothSpeed);
        }
    }
}
