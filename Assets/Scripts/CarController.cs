using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 5f;  // Arabanın hareket hızı
    public float turnSpeed = 200f; // Arabanın dönüş hızı
    public bool IsDriving { get; private set; } // Arabanın sürülüp sürülmediğini kontrol eder

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Yerçekimini etkisiz hale getir
        rb.freezeRotation = true; // Arabanın kendi etrafında dönmesini önle
    }

    void Update()
    {
        if (IsDriving)
        {
            float moveInput = Input.GetAxis("Vertical");  // İleri-geri hareket
            float turnInput = Input.GetAxis("Horizontal"); // Sağa-sola dönüş

            // Arabanın hareketi
            Vector2 moveDirection = transform.right * moveInput * speed * Time.deltaTime;
            rb.MovePosition(rb.position + moveDirection);

            // Arabanın dönüşü
            float turn = -turnInput * turnSpeed * Time.deltaTime;
            rb.MoveRotation(rb.rotation + turn);
        }
    }

    public void EnterCar()
    {
        IsDriving = true;  // Arabayı sürmeye başla
    }

    public void ExitCar()
    {
        IsDriving = false;  // Arabayı sürmeyi bırak
    }
}