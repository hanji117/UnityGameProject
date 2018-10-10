using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
	public float timer;
    public AudioClip deathClip;
	public GameObject blood;
	public AudioClip[] damageClips;
	public EnemyManager enemyManager;
    Animator anim;
    AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
	QuestManager questManager;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
		questManager = GameObject.FindGameObjectWithTag ("QuestManager").GetComponent<QuestManager> ();
		enemyManager = GameObject.FindGameObjectWithTag ("Enemy Manager").GetComponent<EnemyManager> ();
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        //hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
		timer += Time.deltaTime;

		if (timer >= 0.5f) {
			blood.SetActive (false);
		}

        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount)
    {
        if(isDead)
            return;
		blood.SetActive (true);
		timer = 0;
		enemyAudio.PlayOneShot (damageClips [0], 0.3f);
		enemyAudio.PlayOneShot (damageClips [1], 0.8f);
        //enemyAudio.Play ();

        currentHealth -= amount;
           
        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
		questManager.numEnemiesKilled += 1;
		enemyManager.NumberOfEnemies -= 1;
        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");
		enemyAudio.PlayOneShot (damageClips [2], 0.6f);
		enemyAudio.PlayOneShot (damageClips [3], 0.4f);
        //enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
