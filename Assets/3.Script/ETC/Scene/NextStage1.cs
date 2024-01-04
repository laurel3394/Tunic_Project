using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage1 : MonoBehaviour
{
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;
    [SerializeField] GameObject Light3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("씬 넘기기 추가");
            SceneManager.LoadScene("Ending");
            Fox_controller.instance.transform.position = new Vector3(-0.76f,0, -0.94f);
            Light1.SetActive(true);
            Light2.SetActive(true);
            Light3.SetActive(true);
        }
    }
}
