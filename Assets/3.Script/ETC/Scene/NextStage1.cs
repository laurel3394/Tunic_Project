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
            PlayerInfo.instance.Fade(1f);
            StartCoroutine(NextGate());
        }
    }
    private IEnumerator NextGate()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Ending");
    }
}