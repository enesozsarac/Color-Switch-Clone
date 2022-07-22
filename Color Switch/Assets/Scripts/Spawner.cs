using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform circle;
    public Transform star;
    public Transform Ch;
    public float lenght;
    private bool create = true;

    void Update()
    {
        if(create)
        {
            StartCoroutine("CreatePrefab");
        }
    }

    IEnumerator CreatePrefab()
    {
        create = false;
        lenght += 10;
        Instantiate(circle,new Vector3(0,lenght,0),Quaternion.identity);
        Instantiate(star,new Vector3(0,lenght),Quaternion.identity);
        Instantiate(Ch,new Vector3(0,lenght+5,0),Quaternion.identity);
        yield return new WaitForSeconds(1);
        create = true;
    }

}
