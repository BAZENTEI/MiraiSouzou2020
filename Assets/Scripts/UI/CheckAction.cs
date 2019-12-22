using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAction : MonoBehaviour {

    public player player;

    public PlayerBoxMove playerHand;

    Color color;
    static Color transparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    public enum CheckType
    {
        All,
        Drop,
        Pick,
    }
    public CheckType type;
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
                SetOpacity(player.controlEnabled);
                break;
            case CheckType.Drop:
                SetOpacity(player.controlEnabled && playerHand.catch_box);
                break;
            case CheckType.Pick:
                SetOpacity(player.controlEnabled && !playerHand.catch_box);
                break;
        }
	}
}
