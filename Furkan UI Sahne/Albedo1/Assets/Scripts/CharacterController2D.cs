using UnityEngine;

public class Simple2DCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin yatay hareket h�z�

    private Rigidbody2D rb; // Karakterin Rigidbody2D bile�eni

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
    }

    private void Update()
    {
        // Yatay hareket giri�i al
        float moveInput = Input.GetAxis("Horizontal");

        // Yatay h�z vekt�r�n� olu�tur
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Rigidbody2D'nin h�z�n� g�ncelle
        rb.velocity = moveVelocity;
    }
}
