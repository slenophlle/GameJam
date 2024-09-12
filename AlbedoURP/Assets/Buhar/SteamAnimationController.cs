using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamAnimationController : MonoBehaviour
{
    public Animator animator;  // Buhar animasyonunun olduðu Animator
    [SerializeField] private GameObject[] Sprites;  // Buhar sprite'larýnýn olduðu GameObject dizisi

    public float minDelay = 1f;  // Minimum bekleme süresi
    public float maxDelay = 5f;  // Maksimum bekleme süresi

    private List<GameObject> spriteList;  // Karýþtýrýlmýþ sprite'larý tutacak liste

    private void Start()
    {
        // Animator atanmamýþsa, mevcut Animator bileþenini al
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Sprites dizisini bir listeye çevir ve karýþtýr
        spriteList = new List<GameObject>(Sprites);
        ShuffleList(spriteList);  // Listeyi karýþtýr

        // Rastgele zaman aralýklarý ile animasyonu baþlatan Coroutine çaðrýlýr
        StartCoroutine(PlaySteamAnimationRandomly());
    }

    IEnumerator PlaySteamAnimationRandomly()
    {
        while (true)
        {
            // Tüm Sprite'larý devre dýþý býrak
            foreach (GameObject sprite in Sprites)
            {
                sprite.SetActive(false);
            }

            // Eðer tüm sprite'lar oynatýldýysa, listeyi tekrar karýþtýr
            if (spriteList.Count == 0)
            {
                spriteList = new List<GameObject>(Sprites);
                ShuffleList(spriteList);
            }

            // Karýþtýrýlmýþ listedeki ilk Sprite'ý seç ve aktif hale getir
            GameObject selectedSprite = spriteList[0];
            selectedSprite.SetActive(true);

            // Listeyi güncelle: Kullanýlan sprite'ý listeden çýkar
            spriteList.RemoveAt(0);

            // Rastgele bir gecikme süresi seç
            float randomDelay = Random.Range(minDelay, maxDelay);

            // Rastgele belirlenen süre kadar bekle
            yield return new WaitForSeconds(randomDelay);
        }
    }

    // Listeyi karýþtýran fonksiyon
    void ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
