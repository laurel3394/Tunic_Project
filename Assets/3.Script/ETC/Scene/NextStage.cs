using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInfo.instance.Fade(1f);
            AudioManager.instance.StopPlay(AudioManager.Bgm.Lobby);
            Fox_controller.instance.mat = Fox_controller.instance.NightMat;
            Fox_controller.instance.FoxNight();
            StartCoroutine(NextGate());
        }
    }
    private IEnumerator NextGate()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("BossRoom");
        Fox_controller.instance.transform.position = new Vector3(-0.76f, 0, -0.94f);
        AudioManager.instance.PlayBGM(AudioManager.Bgm.Scavenger);
    }
}
