using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public static CameraControll instance = null;
    
    private float shakeTime;
    private float shakeIntensity;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }

    public void OnShakeCamera(float shakeTime = 1.0f,float shakeIntensity = 0.1f)
    {
        if (OnoffButton.onoff)
        {
            this.shakeTime = shakeTime;
            this.shakeIntensity = shakeIntensity;
            StartCoroutine(ShakeByRotation());
        }
    }

    private IEnumerator ShakeByRotation()
    {
        Vector3 startRotation = transform.eulerAngles;

        float power = 10f;
        while (shakeTime > 0.0f)
        {
            float x = 0;
            float y = 0;
            float z = Random.Range(-1f, 1f);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * shakeIntensity * power);

            shakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.rotation = Quaternion.Euler(startRotation);
    }
}