using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class press_any_key : MonoBehaviour
{
    private Text text;
    private float num = 0f;
    private float num2 = 1f;



    private float time;
    public float FadeTime = 2f;
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(Press());
    }
    private IEnumerator Press()
    {
        while (true)
        {
            num += Time.deltaTime*num2;  //러프 방법
            if (1f <= num || 0f >= num)
                num2 *= -1f;
            float blink = Mathf.Lerp(1f, 0f, num);
            text.color = new Color(1f, 1f, 1f, blink);
            yield return null;
        }
    }
}