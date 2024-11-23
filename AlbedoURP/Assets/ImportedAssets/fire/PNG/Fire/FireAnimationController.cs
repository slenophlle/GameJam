using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class FireAnimationController : MonoBehaviour
{
    public Animator animator;  // Buhar animasyonunun oldu�u Animator
    [SerializeField] private GameObject[] Sprites;  // Buhar sprite'lar�n�n oldu�u GameObject dizisi

    private void Start()
    {
        // Animator atanmam��sa, mevcut Animator bile�enini al
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // T�m Sprite'lar� devre d��� b�rak
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
            // Animasyonu d�ng�sel �ekilde �al��t�r
            animator.SetBool("isLooping", true); // Animator'da d�ng� anahtar� ayarla
        }
       
       foreach(GameObject sprite in Sprites)
       {
            sprite.SetActive(true);
       }
        

        
    }
}
