using UnityEngine;
using System.Collections;

public class enemyspawner : MonoBehaviour {

    float spawnCD = 0.25f;
    float spawnCDRemaining = 0;

    float nextWaveCD = 1.00f;
    float nextWaveCDRemaining = 1.00f;

    [System.Serializable]
    public class WaveComponent
    {
        public GameObject enemyPrefab;
        public int num;

        [System.NonSerialized]
        public int spawned = 0;
    }

    public WaveComponent[] waveComps;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        spawnCDRemaining -= Time.deltaTime;
        if (spawnCDRemaining < 0)
        {
            spawnCDRemaining = spawnCD;
            bool didSpawn = false;

            // Go through the wave comps until we find something to spawn.
            foreach (WaveComponent wc in waveComps)
            {
                if (wc.spawned < wc.num)
                {
                    wc.spawned++;

                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

                    didSpawn = true;
                    break;
                }

            }

            if (didSpawn == false)
            {
                // Wave must be complete
                nextWaveCDRemaining -= Time.deltaTime;
                Debug.Log(string.Format("Time Before Next Wave Spawn: {0}", nextWaveCDRemaining.ToString()));
                    
                if (nextWaveCDRemaining < 0)
                {
                    // Reset wave counter.
                    nextWaveCDRemaining = nextWaveCD;

                    // Instantiate next wave object!
                    if (transform.parent.childCount > 1)
                    {
                        transform.parent.GetChild(1).gameObject.SetActive(true);
                        Destroy(gameObject);
                    }
                    else
                    {
                        // Last Wave.
                    }
                }



            }

        }
	}
}
