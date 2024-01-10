using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [Range(0, 1)]
    [SerializeField] private float Test;
    [SerializeField] private float speed;
    public GameObject shoot;
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;
    public Vector3 P4;

    private void Start()
    {
        Test = 0f;
        shoot = this.gameObject;
        P1 = shoot.transform.position;
        P2 = shoot.transform.position + new Vector3(0f,7f,0f);
        P3 = Fox_controller.instance.transform.position + new Vector3(0f, 7f, 0f);
        P4 = Fox_controller.instance.transform.position;
        StartCoroutine(Shooot());
    }

    private IEnumerator Shooot()
    {
        while (true)
        {
            Test += Time.deltaTime*speed;
            gameObject.transform.position = Bezier(P1, P2, P3, P4, Test);
            yield return null;
            if (Test >=1)
            {
                Destroy(gameObject);
                break;
            }
        }
    }





    public Vector3 Bezier(Vector3 P_1, Vector3 P_2, Vector3 P_3,Vector3 P_4,float Value)
    {
        Vector3 A = Vector3.Lerp(P_1, P_2, Value);
        Vector3 B = Vector3.Lerp(P_2, P_3, Value);
        Vector3 C = Vector3.Lerp(P_3, P_4, Value);

        Vector3 D = Vector3.Lerp(A, B, Value);
        Vector3 E = Vector3.Lerp(B, C, Value);

        Vector3 F = Vector3.Lerp(D, E, Value);

        return F;

    }
}
