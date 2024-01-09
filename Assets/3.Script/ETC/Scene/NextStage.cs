using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;
    [SerializeField] GameObject Light3;
    [SerializeField] GameObject Light4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInfo.instance.Fade(1f);
            AudioManager.instance.StopPlay(AudioManager.Bgm.Lobby);
            StartCoroutine(NextGate());
        }
    }
    private IEnumerator NextGate()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("BossRoom");
        Fox_controller.instance.transform.position = new Vector3(-0.76f, 0, -0.94f);
        AudioManager.instance.PlayBGM(AudioManager.Bgm.Scavenger);
        Light1.SetActive(true);
        Light2.SetActive(true);
        Light3.SetActive(true);
        Light4.SetActive(true);
    }
}
