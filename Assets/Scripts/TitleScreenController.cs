using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour {
    public SceneSelectionController sceneSelection;

    // Use this for initialization
    private void Awake()
    {
            //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, true);
#endif
    }

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            // Go to scene selection
            sceneSelection.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
	}
}
