using UnityEngine;

public class FaceARCamera : MonoBehaviour
{

    void Update()
    {
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
    }

}
