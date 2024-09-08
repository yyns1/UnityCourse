using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public CarController carController;  // Arabayı kontrol eden script
    public float interactionDistance = 1.5f;  // Arabaya ne kadar yaklaşırsa etkileşime geçilecek mesafe

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Karakter arabaya yakın mı?
        if (Vector3.Distance(transform.position, carController.transform.position) < interactionDistance)
        {
            // "E" tuşuna basıldı mı?
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (carController.IsDriving)
                {
                    // Arabadan çık
                    carController.ExitCar();
                    gameObject.SetActive(true); // Oyuncuyu tekrar aktif et
                }
                else
                {
                    // Arabaya bin
                    carController.EnterCar();
                    gameObject.SetActive(false); // Oyuncuyu gizle
                }
            }
        }

        if (!carController.IsDriving)
        {
            // Player hareketi
            if (movementInput != Vector2.zero)
            {
                TryMove(movementInput);
            }
        }
    }

    void FixedUpdate()
    {
        if (movementInput != Vector2.zero && !carController.IsDriving)
        {
            TryMove(movementInput);
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
            direction,
            movementFilter,
            new List<RaycastHit2D>(),
            moveSpeed * Time.fixedDeltaTime
        );

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }
}