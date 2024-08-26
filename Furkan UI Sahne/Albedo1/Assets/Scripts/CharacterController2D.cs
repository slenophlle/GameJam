using UnityEngine;

public class Simple2DCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin yatay hareket hýzý

    private Rigidbody2D rb; // Karakterin Rigidbody2D bileþeni

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al
    }

    private void Update()
    {
        // Yatay hareket giriþi al
        float moveInput = Input.GetAxis("Horizontal");

        // Yatay hýz vektörünü oluþtur
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Rigidbody2D'nin hýzýný güncelle
        rb.velocity = moveVelocity;
    }
}
