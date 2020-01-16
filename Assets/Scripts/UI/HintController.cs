using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour {
    public GameDirector gameDirector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameDirector.performance)
        {
            this.gameObject.SetActive(false);
        }
	}
}
