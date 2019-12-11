using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    public GameObject Image;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックしたとき、オブジェクト表示
        if (Input.GetMouseButtonDown(0))
        {
            Image.SetActive(true);
        }

        // 右クリックしたとき、オブジェクト非表示
        if (Input.GetMouseButtonDown(1))
        {
            Image.SetActive(false);
        }
    }
}