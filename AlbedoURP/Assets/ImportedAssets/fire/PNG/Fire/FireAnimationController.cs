using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class FireAnimationController : MonoBehaviour
{
    public Animator animator;  // Buhar animasyonunun olduðu Animator
    [SerializeField] private GameObject[] Sprites;  // Buhar sprite'larýnýn olduðu GameObject dizisi

    private void Start()
    {
        // Animator atanmamýþsa, mevcut Animator bileþenini al
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Tüm Sprite'larý devre dýþý býrak
        foreach (GameObject sprite in Sprites)
        {
            sprite.SetActive(false);
        }

         void OnCollisionEnter2D()
         {
            foreach(GameObject sprite in Sprites)
            {
                sprite.SetActive(true);
            }
            // Animasyonu döngüsel þekilde çalýþtýr
            animator.SetBool("isLooping", true); // Animator'da döngü anahtarý ayarla
        }
       
       foreach(GameObject sprite in Sprites)
       {
            sprite.SetActive(true);
       }
        

        
    }
}
