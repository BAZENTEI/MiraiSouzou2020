using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sindan : MonoBehaviour
{

    int key = 0;
    float nam = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        //下に移動
        transform.Translate(0, -0.01f, 0);

        if (pos.y <= -9.0f)
        {
            gameObject.SetActive(false);
        }
    }
}