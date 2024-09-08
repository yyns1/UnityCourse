using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin transform'u
    public float smoothSpeed = 0.125f; // Kameran�n takip h�z�n� belirler
    public Vector3 offset; // Kameran�n karaktere g�re konumunu belirleyen ofset
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