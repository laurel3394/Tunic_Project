using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPool : MonoBehaviour
{
    public static StickPool instance = null;

    public Queue<GameObject> stickpool = new Queue<GameObject>();
    public GameObject stick;
    [SerializeField] private int stickcount =20;

    private void Awake()
    {
        if (instance ==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        MakePool();
    }

    private void MakePool()
    {
        for (int i = 0; i < stickcount; i++)
        {
            GameObject gameObject = Instantiate(stick);
            gameObject.SetActive(false);
            stickpool.Enqueue(gameObject);
        }
    }


}
