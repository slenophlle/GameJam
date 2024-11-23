using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLighFollower : MonoBehaviour
{
    public Camera cam;
    private bool isFollowing = true; // Fare takibi aktif mi

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        // ESC tuþuna basýldýðýnda takip durumu deðiþtir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isFollowing = !isFollowing;
        }

        // Eðer fareyi takip ediyorsa hareket ettir
        if (isFollowing)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 45;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            transform.up = direction;
        }
    }
}
