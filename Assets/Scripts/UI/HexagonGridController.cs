using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexagonGridController : MonoBehaviour {

    public Color startColor = new Color(1.0f, 1.0f, 1.0f);
    public Color targetColor = new Color(0.75f, 1.0f, 1.0f);

    private Image[] hexagons;
    private float[] speeds;

    private float time;

	// Use this for initialization
	void Start () {
        time = 0;
        hexagons = GetComponentsInChildren<Image>();
        speeds = new float[hexagons.Length];
        for(int i = 0; i < speeds.Length; ++i)
        {
            speeds[i] = Random.Range(0.0f, Mathf.PI / 4);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < speeds.Length; ++i)
        {
            float r = Mathf.Cos(time * speeds[i]) / 2.0f + 0.5f;

            hexagons[i].color = Color.Lerp(targetColor, startColor, r);

        }

        time += Time.deltaTime;
    }
}
