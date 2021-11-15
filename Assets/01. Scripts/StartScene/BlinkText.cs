using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BlinkText : MonoBehaviour
{
    public Text flashingText;

    private void Start()
    {
        StartCoroutine(BlinkTexts());
    }

    public IEnumerator BlinkTexts()
    {
        while(true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(0.5f);
            flashingText.text = "Touch To Start";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
