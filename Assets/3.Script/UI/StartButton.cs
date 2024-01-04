using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Map_one_Start()
    {
        SceneManager.LoadScene("Map1");
    }
}