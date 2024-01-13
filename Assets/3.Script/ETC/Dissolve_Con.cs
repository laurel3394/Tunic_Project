using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve_Con : MonoBehaviour
{
    public float dissolveDuration = 2;
    public float dissolveStrength;


    public void startDissolver()
    {
        StartCoroutine(Dissolver());
    }
    public IEnumerator Dissolver()
    {
        float elapsedTime = 0;
        Material mymaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        MeshRenderer[] mr_arr = GetComponentsInChildren<MeshRenderer>();
       //Material mymaterial2 = GetComponentInChildren<MeshRenderer>().material;
        
        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveStrength = Mathf.Lerp(0, 1, elapsedTime / dissolveDuration);
            mymaterial.SetFloat("_Disslove_Float", dissolveStrength);
           
            for (int i = 0; i < mr_arr.Length; i++)
            {
                mr_arr[i].material.SetFloat("_Disslove_Float", dissolveStrength);
            }

            


            yield return null;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            startDissolver();
        }
    }
}