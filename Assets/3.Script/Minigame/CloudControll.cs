using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControll : MonoBehaviour
{
    [SerializeField] private GameObject[] Platform;
    public float spawn;


    public void Reset()
    {
        for (int i = 0; i < Platform.Length; i++)
        {
            Platform[i].SetActive(false);
        }
    }
    public void MinigameHeaven()
    {
        int plat;

        plat = Random.Range(0, Platform.Length);
        Platform[plat].SetActive(true);

    }

}