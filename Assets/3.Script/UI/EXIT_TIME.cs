using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXIT_TIME : MonoBehaviour
{
    [SerializeField] GameObject Text;
    [SerializeField] GameObject EXIT;

    private void Start()
    {
        Invoke("EXIT_TIMMER", 2f);
    }
    private void EXIT_TIMMER()
    {
        Text.SetActive(true);
        EXIT.SetActive(true);
    }

}
