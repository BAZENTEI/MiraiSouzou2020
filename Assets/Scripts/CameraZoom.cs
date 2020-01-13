using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    Camera cam;
    public Vector3 startPos;
    public Vector3 endPos;
    public  float endSize;
    public  float startSize;

    float frame;         //フレームをカウントする
    public float frameDest = 50.0f;     //目標のフレーム数

    public GameObject gameDirector;

    // Use this for initialization
    void Start () {
        cam = this.GetComponent<Camera>();//Main CameraのCameraを取得する。
        startPos = this.transform.position;//Main Cameraの最初の所
        endPos = new Vector3(-1.078974f, -5.08f, -54.3001f);
        startSize = cam.orthographicSize;// the start of viewport　size
        endSize = 4.15f;
        frame = 0.0f;
        frameDest = 50.0f;

        
    }
	
	// Update is called once per frame
	void Update () {
      
        if(gameDirector.GetComponent<GameDirector>().performance == true)
        {
            cam.transform.position = EaseOutCubicVector(frame / frameDest, startPos, endPos);
            cam.orthographicSize = EaseOutCubicVector(frame / frameDest, startSize, endSize);
            frame++;
        }
        
        /*if(frame == frameDest)
            gameDirector.GetComponent<GameDirector>().SetGameState();*/
    }


    Vector3 EaseOutCubicVector(float time, Vector3 start, Vector3 goal)
    {
        if (time > 1.0f)
            time = 1.0f;

        if (time < 0.0f)
            time = 0.0f;

        return -(goal - start) * time * (time - 2.0f) + start;
    }

    //オーバーロード
    float EaseOutCubicVector(float time, float start, float goal)
    {
        if (time > 1.0f)
            time = 1.0f;

        if (time < 0.0f)
            time = 0.0f;

        return -(goal - start) * time * (time - 2.0f) + start;
    }

  
}
