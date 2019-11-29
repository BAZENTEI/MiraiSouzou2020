using UnityEngine;
using System.Collections;

public class counter : MonoBehaviour
{
	public TextMesh txt;
	LPManager lpman;

    //1129
    public GameObject gameDirector;
	// Use this for initialization
	void Start ()
	{
		lpman = FindObjectOfType<LPManager>();
		StartCoroutine("howmany");

	}
	
	
	IEnumerator howmany()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.5f);
			
			int count = 0;



			if (lpman.ParticleSystems.Length == 1)
			{
				count = lpman.ParticleSystems[0].Particles.Length;

				int countin = 0;

				float r = 0.0f;
				float g = 0.0f;
				float b = 0.0f;

				for(int i = 1;i < count; i++)
				{
					

					Vector2 x = new Vector2 (lpman.ParticleSystems[0].Particles[i].Position.x,lpman.ParticleSystems[0].Particles[i].Position.y);

					if ((x.x > -3.6f && x.x < 4.6f) && (x.y > -4.2f && x.y < 2.95f)) {

						countin++;
						//Debug.Log (countin);

					
						r += lpman.ParticleSystems [0].Particles [i]._Color.r;
						g += lpman.ParticleSystems [0].Particles [i]._Color.g;
						b += lpman.ParticleSystems [0].Particles [i]._Color.b;

						//Debug.Log ("r"+r);
						//Debug.Log ("b"+b);

						//Debug.Log ("ca"+_Color.r);

						//if(lpman.ParticleSystems[0].Particles[i]._Color.r > 0.0f && lpman.ParticleSystems[0].Particles[i]._Color.r < 1.0f){

							//countin++;
							//Debug.Log (countin);

							//Debug.Log ("r"+lpman.ParticleSystems[0].Particles[i]._Color.r);
						//Debug.Log ("g"+lpman.ParticleSystems[0].Particles[i]._Color.g);
							//Debug.Log ("b"+lpman.ParticleSystems[0].Particles[i]._Color.b);
					//	}

						
						float r1 = r / (float)countin;
						float g1 = g / (float)countin;
						float b1 = b / (float)countin;

					    //Debug.Log ("r"+r1);
					    //Debug.Log ("b"+b1);
						
						if(Mathf.Abs(0.5f - r1) < 0.3f  && Mathf.Abs(0.5f - b1) < 0.3f ){
								
                            if (countin > 150)
                            {
                                //Debug.Log("countin ");
                                //Debug.Log("goal");

                                gameDirector.GetComponent<GameDirector>().SetGameState();
                            }
					    }						
					}
						
				}

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
