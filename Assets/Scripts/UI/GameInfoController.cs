using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoController : MonoBehaviour {
    public SceneSelectionController sceneSelection;
    
    public GameObject credits;
    public RectTransform rectTransform;
    Vector3 startPosition;

    // Use this for initialization
    void Start ()
    {
        startPosition = new Vector3(rectTransform.position.x, rectTransform.position.y, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        rectTransform.position = rectTransform.position + new Vector3(0f, 120f * Time.deltaTime, 0f);
        if (rectTransform.offsetMax.y - rectTransform.rect.height > 0f || Input.GetButtonDown("Cancel"))
        {
            gameObject.SetActive(false);
            sceneSelection.gameObject.SetActive(true);
            rectTransform.position = startPosition;
        }
	}

}
