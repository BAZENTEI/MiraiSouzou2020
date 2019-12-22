using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckJump : MonoBehaviour {

    public player player;
    Color color;
    static Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    Image image;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        color = image.color;
    }
	
	// Update is called once per frame
	void Update () {
		if(player.controlEnabled && player.jumpState == player.JumpState.Grounded)
        {
            image.color = color;
        }
        else
        {
            image.color = transparent;
        }
	}
}
