using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] enemy;
	//public GameObject player;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	public int NumberOfEnemies = 0;
	public int MaxNumEnemies = 0;
    void Start ()
    {
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

		if (NumberOfEnemies >= MaxNumEnemies) {
			return;
		}

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		int spawnType = Random.Range (0, 2);
		DisableSpawnPoint spawner_point = spawnPoints [spawnPointIndex].gameObject.GetComponent<DisableSpawnPoint> ();
		if (spawner_point.Spawnable == true) {
			//spawnPoints [spawnPointIndex].position.y = 0f;
			Instantiate (enemy[spawnType], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			NumberOfEnemies++;
		}
		else
			return;
    }
}