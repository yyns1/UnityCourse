using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin transform'u
    public float smoothSpeed = 0.125f; // Kameranýn takip hýzýný belirler
    public Vector3 offset; // Kameranýn karaktere göre konumunu belirleyen ofset
    public Rigidbody2D rb;
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}