using UnityEngine;

public class GunViewModel : MonoBehaviour
{
    public Transform cam;
    void LateUpdate()
    {
        // Only match rotation to the camera
        transform.rotation = cam.rotation;
    }
}