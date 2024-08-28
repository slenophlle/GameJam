using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MinigameValueController : MonoBehaviour
{
    [SerializeField] Slider voltSlider;
    [SerializeField] Slider ampSlider;
    [SerializeField] Slider ohmSlider;

    [SerializeField] TextMeshProUGUI voltValueText;
    [SerializeField] TextMeshProUGUI ampValueText;
    [SerializeField] TextMeshProUGUI ohmValueText;

    public int voltValue;
    public int ampValue;
    public int ohmValue;

    private int GetRandomValues()
    {
        return Random.Range(0, 30);
    }

    private void Start()
    {
        gameObject.SetActive(false);

        //voltValue = GetRandomValues();
        //ampValue = GetRandomValues();
        //ohmValue = GetRandomValues();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(true);
        }

        ControlValues();
    }

    private void ControlValues()
    {
        int curVoltValue = Mathf.RoundToInt(voltSlider.value * 30);
        int curAmpValue = Mathf.RoundToInt(ampSlider.value * 30);
        int curOhmValue = Mathf.RoundToInt(ohmSlider.value * 30);

        voltValueText.text = "" + curVoltValue;
        ampValueText.text = "" + curAmpValue;
        ohmValueText.text = "" + curOhmValue;

        if (curVoltValue == voltValue && curAmpValue == ampValue && curOhmValue == ohmValue)
        {
            StartCoroutine(DelayActiveTime());
            SceneManager.LoadScene(3);

        }
    }
    IEnumerator DelayActiveTime()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);

    }
}
