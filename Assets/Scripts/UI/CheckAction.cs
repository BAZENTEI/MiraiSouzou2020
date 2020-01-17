using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAction : MonoBehaviour {

    public player player;
    public PlayerBoxMove playerHand;

    public enum CheckType
    {
        All,
        Drop,
        Pick,
    }
    public CheckType type;

    static Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    Color color;
    Image image;

	void Start () {
        image = GetComponent<Image>();
        color = image.color;
	}

    void SetOpacity(bool isOpacity)
    {
        image.color = isOpacity ? color : transparent;
    }
	
	// Update is called once per frame
	void Update () {
        switch(type)
        {
            case CheckType.All:
                SetOpacity(player.controlEnabled && player.IsGrounded);
                break;
            case CheckType.Drop:
                SetOpacity(player.controlEnabled && player.IsGrounded && playerHand.catch_box);
                break;
            case CheckType.Pick:
                SetOpacity(player.controlEnabled && player.IsGrounded && !playerHand.catch_box);
                break;
        }
	}
}
