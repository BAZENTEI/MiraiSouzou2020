using UnityEngine;
using System.Collections;

public class counter : MonoBehaviour
{
    public TextMesh txt;
    LPManager lpman;


    public GameObject gameDirector;

    public Vector2 min = new Vector2(-3.0f, 0.0f);
    public Vector2 max = new Vector2(0.0f, 3.5f);
    public Vector3 error;
    public int gameClear;
    public Color targetColor;

    // Use this for initialization
    void Start()
    {
        lpman = FindObjectOfType<LPManager>();
        StartCoroutine("howmany");

    }


    IEnumerator howmany()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            int count = 0;
            int countin = 0;

            //ゲームクリア判定
            if (lpman.ParticleSystems.Length == 1)
            {
                count = lpman.ParticleSystems[0].Particles.Length;

                for (int i = 1; i < count; i++)
                {
                    Vector2 particle = new Vector2(lpman.ParticleSystems[0].Particles[i].Position.x, lpman.ParticleSystems[0].Particles[i].Position.y);

                    if ((particle.x > min.x && particle.x < max.x) && (particle.y > min.y && particle.y < max.y))
                    {
                        //Debug.Log(lpman.ParticleSystems[0].Particles[i]._Color);

                        float r = lpman.ParticleSystems[0].Particles[i]._Color.r;
                        float g = lpman.ParticleSystems[0].Particles[i]._Color.g;
                        float b = lpman.ParticleSystems[0].Particles[i]._Color.b;

                        //ゲームクリアになる
                        if (Mathf.Abs(targetColor.r - r) < error.x &&
                           Mathf.Abs(targetColor.b - b) < error.y &&
                           Mathf.Abs(targetColor.g - g) < error.z)
                        {

                            countin++;

                        }

                        //判定の量
                        // Debug.Log(countin);

                        if (countin > gameClear)
                        {
                            //監督スクリプトに伝わる
                            gameDirector.GetComponent<GameDirector>().SetGameState();
                            break;
                        }
                    }
                }

                //監督スクリプトに伝わる
                gameDirector.GetComponent<GameDirector>().SetGage(countin / (float)this.gameClear);
            }
            else if (lpman.ParticleSystems.Length > 1)
            {
                foreach (LPParticleSystem sys in lpman.ParticleSystems)
                {
                    count += sys.Particles.Length;
                }
            }
            txt.text = count.ToString();
        }
    }
}
