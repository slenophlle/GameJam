using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamAnimationController : MonoBehaviour
{
    public Animator animator;  // Buhar animasyonunun oldu�u Animator
    [SerializeField] private GameObject[] Sprites;  // Buhar sprite'lar�n�n oldu�u GameObject dizisi

    public float minDelay = 1f;  // Minimum bekleme s�resi
    public float maxDelay = 5f;  // Maksimum bekleme s�resi

    private List<GameObject> spriteList;  // Kar��t�r�lm�� sprite'lar� tutacak liste

    private void Start()
    {
        // Animator atanmam��sa, mevcut Animator bile�enini al
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Sprites dizisini bir listeye �evir ve kar��t�r
        spriteList = new List<GameObject>(Sprites);
        ShuffleList(spriteList);  // Listeyi kar��t�r

        // Rastgele zaman aral�klar� ile animasyonu ba�latan Coroutine �a�r�l�r
        StartCoroutine(PlaySteamAnimationRandomly());
    }

    IEnumerator PlaySteamAnimationRandomly()
    {
        while (true)
        {
            // T�m Sprite'lar� devre d��� b�rak
            foreach (GameObject sprite in Sprites)
            {
                sprite.SetActive(false);
            }

            // E�er t�m sprite'lar oynat�ld�ysa, listeyi tekrar kar��t�r
            if (spriteList.Count == 0)
            {
                spriteList = new List<GameObject>(Sprites);
                ShuffleList(spriteList);
            }

            // Kar��t�r�lm�� listedeki ilk Sprite'� se� ve aktif hale getir
            GameObject selectedSprite = spriteList[0];
            selectedSprite.SetActive(true);

            // Listeyi g�ncelle: Kullan�lan sprite'� listeden ��kar
            spriteList.RemoveAt(0);

            // Rastgele bir gecikme s�resi se�
            float randomDelay = Random.Range(minDelay, maxDelay);

            // Rastgele belirlenen s�re kadar bekle
            yield return new WaitForSeconds(randomDelay);
        }
    }

    // Listeyi kar��t�ran fonksiyon
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
