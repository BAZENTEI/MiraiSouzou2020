using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    public GameObject gameDirector;

    public GameObject Image;
    GameObject Player;

    // Use this for initialization
    void Start () {

        // Player(ロボット)を取得
        this.Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (gameDirector.GetComponent<GameDirector>().performance == true)
        {
            Image.SetActive(true);
        }
    }
}
