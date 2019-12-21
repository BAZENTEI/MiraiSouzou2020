using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Percent : MonoBehaviour {

    public TextMesh txt;
    public GameDirector gameDirector;
    // Use this for initialization
    void Start () {
        gameDirector = gameDirector.GetComponent<GameDirector>();
        txt = GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = gameDirector.gage.ToString() + "%";
    }
}
