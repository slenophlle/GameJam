using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HandleTexts : MonoBehaviour
{
    public string[] lines;
    public TextMeshProUGUI[] textFields; // Metin alanlarını içeren dizi
    public RectTransform textContainer;  // Metin alanlarını içeren RectTransform
    public CanvasGroup canvasGroup;      // Şeffaflık kontrolü için CanvasGroup

    [SerializeField] float textSpeed = 0.05f;
    private static int index;
    private static int currentTextFieldIndex;
    private bool isTyping;
    private float scrollSpeed = 50f; // Kaydırma hızı
    private float fadeSpeed = 1f;    // Şeffaflık hızını belirler

    private void Start()
    {
        index = 0;
        foreach (var textField in textFields)
        {
            textField.text = string.Empty; // Başlangıçta tüm metin alanlarını temizle
        }
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = 0;
        currentTextFieldIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;

        // Yeni metin eklenmeden önce var olan metinleri yukarı kaydır
        if (currentTextFieldIndex > 0)
        {
            StartCoroutine(ScrollTextUp());
            //StartCoroutine(Delay());
        }

        foreach (char c in lines[index].ToCharArray())
        {
            textFields[currentTextFieldIndex].text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1 && currentTextFieldIndex < textFields.Length - 1)
        {
            index++;
            currentTextFieldIndex++;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Diyalog sona erdi veya başka metin alanı kalmadı.");
            StartCoroutine(FadeOut());
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator ScrollTextUp()
    {
        float targetY = textContainer.anchoredPosition.y + textFields[0].rectTransform.rect.height * 2.5f;
        while (textContainer.anchoredPosition.y < targetY)
        {
            textContainer.anchoredPosition += new Vector2(0, scrollSpeed) * Time.deltaTime;
            yield return null;
        }
        textContainer.anchoredPosition = new Vector2(textContainer.anchoredPosition.x, targetY);
    }

    IEnumerator FadeOut()
    {
        float startAlpha = canvasGroup.alpha;
        float timeElapsed = 0f;

        while (timeElapsed < fadeSpeed)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, timeElapsed / fadeSpeed);
            yield return null;
        }

        canvasGroup.alpha = 0f; // Tamamen şeffaf olmasını sağlar
    }
    IEnumerator Delay() 
    {
        yield return new WaitForSeconds(48);
        SceneManager.LoadScene(2);
    }
}
