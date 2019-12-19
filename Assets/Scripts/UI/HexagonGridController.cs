using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexagonGridController : MonoBehaviour {

    public Color startColor = new Color(1.0f, 1.0f, 1.0f);
    public Color targetColor = new Color(0.75f, 1.0f, 1.0f);

    private static float[] colorOffsets = new float[0];
    private static float time = 0;

    private Image[] hexagons;

    private void Awake()
    {
        if(colorOffsets.Length == 0)
        {
            colorOffsets = new float[GetComponentsInChildren<Image>().Length];
            for (int i = 0; i < colorOffsets.Length; ++i)
            {
                colorOffsets[i] = Random.Range(0.0f, Mathf.PI / 4);
            }
        }
    }
    // Use this for initialization
    void Start ()
    {
        hexagons = GetComponentsInChildren<Image>();

        if (colorOffsets.Length == 0)
        {
            colorOffsets = new float[hexagons.Length];
            for (int i = 0; i < colorOffsets.Length; ++i)
            {
                colorOffsets[i] = Random.Range(0.0f, Mathf.PI / 4);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < colorOffsets.Length; ++i)
        {
            float r = Mathf.Cos(time * colorOffsets[i]) / 2.0f + 0.5f;

            hexagons[i].color = Color.Lerp(targetColor, startColor, r);
        }

        time += Time.deltaTime;
    }
}
