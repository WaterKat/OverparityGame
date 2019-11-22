using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WaterKat.Audio;

public class TemporaryBossScript : MonoBehaviour
{
    public enum BossStates
    {
        Idle = 0,
        Walking = 1,
        AttackTransition = 2,
        SpawningUnder = 3,
        SpawningRow = 4,
        Spitting = 5,
        SpawningDefense = 6,
        Resting = 7,
        AttackTransitionOut = 8,
        Dead = 9,
    }

    [System.Serializable]
    class Ticker
    {
        float currentTick = 0;
        public float MaxTick = 1;

        public bool TryTick()
        {
            if (currentTick > MaxTick) { currentTick = 0; }
            currentTick += Time.deltaTime;
            return currentTick >= MaxTick;
        }
    }

    [SerializeField]
    Ticker Idle = new Ticker();

    [SerializeField]
    Ticker AttackTransition = new Ticker();
    [SerializeField]
    Ticker AttackTransitionOut = new Ticker();

    [SerializeField]
    Ticker SpawningUnderState = new Ticker();
    [SerializeField]
    Ticker SpawningUnderRate = new Ticker();

    [SerializeField]
    Ticker SpawningRowState = new Ticker();
    [SerializeField]
    Ticker SpawningRowRate = new Ticker();

    [SerializeField]
    Ticker SpittingState = new Ticker();
    [SerializeField]
    Ticker SpittingRate = new Ticker();

    [SerializeField]
    Ticker SpawningDefenseState = new Ticker();
    [SerializeField]
    Ticker SpawningDefenseRate = new Ticker();


    [SerializeField]
    Ticker BetweenRestingCooldown = new Ticker();
    [SerializeField]
    Ticker Resting = new Ticker();

    public float DesiredRange = 10;
    public float WalkSpeed = 5;


    public Animator BossAnimator;
    public BossStates CurrentBossState = BossStates.Idle;
    
    public GameObject Tentacle;
    public GameObject Spit;

    public float spitLifeTime = 3;

    public float TentacleRowLength = 30;
    public int TentacleRowCount = 20;

    public EnemyDamaged enemyDamagedScript;

    void SpawnTentacle(Vector3 position)
    {
        GameObject spawnedTentacle = Instantiate(Tentacle);
        spawnedTentacle.SetActive(true);
        spawnedTentacle.transform.position = position;
        Destroy(spawnedTentacle, (110f / 60f));
    }

    void SpawnTentacleUnderPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            SpawnTentacle(player.transform.position);
        }
        AudioManager.PlaySound("TentacleSquish");
    }

    void SpawnTentacleRowTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 direction = -1f*(transform.position-player.transform.position).normalized;

            for (int i = 1; i <= TentacleRowCount; i++)
            {
                SpawnTentacle(transform.position+(direction*(i/(float)TentacleRowCount)*TentacleRowLength));
            }
        }
        AudioManager.PlaySound("TentacleSquish");

    }

    void SpawnTentacleCircle()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 direction = -1f * (transform.position - player.transform.position).normalized;

            for (int i = 1; i <= TentacleRowCount; i++)
            {
                Vector3 tempPos = new Vector3(Mathf.Cos(i/(float)TentacleRowCount * Mathf.PI * 2), Mathf.Sin(i / (float)TentacleRowCount * Mathf.PI * 2), 0);
            
                SpawnTentacle(transform.position + (tempPos*3));
            }
        }
        AudioManager.PlaySound("TentacleSquish");

    }

    void SpawnSpit()
    {
        GameObject newSpit = Instantiate(Spit);
        newSpit.SetActive(true);
        newSpit.transform.position = transform.position;
        Destroy(newSpit, spitLifeTime);
        AudioManager.PlaySound("Spit");

    }


    bool PlayerWithinRange(GameObject player, float distance)
    {
        //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        return (Vector3.Distance(player.transform.position, transform.position) <= distance);
    }

    private void Start()
    {
        enemyDamagedScript = GetComponent<EnemyDamaged>();
        BossAnimator = GetComponent<Animator>();
    }

    public string TargetScene = "";
    public void LoadNextScene()
    {
        SceneManager.LoadScene(TargetScene);
    }

    private void Update()
    {
        BossAnimator.SetInteger("CurrentBossState", (int)CurrentBossState);

        if (enemyDamagedScript.HEALTH == 0)
        {
            WaterKat.Time.TimerManager.AddTask(LoadNextScene, 3);
            this.enabled = false;
            return;
        }


        GameObject player = GameObject.FindGameObjectWithTag("Player");

        switch (CurrentBossState)
        {
            case BossStates.Idle:
                if (Random.Range(0, 100) > 20)
                {
                    if (PlayerWithinRange(player, DesiredRange))
                    {
                        CurrentBossState = BossStates.AttackTransition;
                    }
                    else
                    {
                        CurrentBossState = BossStates.Walking;
                        AudioManager.PlaySound("BossResting");

                    }
                }
                else
                {
                    //if (BetweenRestingCooldown.TryTick())
                    {
                        CurrentBossState = BossStates.Resting;
                        AudioManager.PlaySound("BossResting");
                    }
                }
                break;
            case BossStates.Walking:
                if (player == null) { Debug.Log("PlayerIsNull"); break; }

                

                transform.position += WalkSpeed * (player.transform.position - transform.position).normalized * Time.deltaTime;
                BossAnimator.SetFloat("HorizontalSpeed",(WalkSpeed * (player.transform.position - transform.position).normalized).x);

                if (PlayerWithinRange(player, DesiredRange))
                {
                    CurrentBossState = BossStates.Idle;
                }
                break;
            case BossStates.AttackTransition:
                if (AttackTransition.TryTick())
                {
                    int randomNumber = Random.Range(0, 100);
                    if ((0 < randomNumber) && (randomNumber <= 33))
                    {
                        CurrentBossState = BossStates.SpawningUnder;
                    }
                    if ((33 < randomNumber) && (randomNumber <= 66))
                    {
                        CurrentBossState = BossStates.SpawningRow;
                    }
                    if ((66 < randomNumber) && (randomNumber <= 100))
                    {
                        CurrentBossState = BossStates.Spitting;
                    }
                }
                break;
            case BossStates.SpawningUnder:
                if (SpawningUnderState.TryTick())
                {
                    CurrentBossState = BossStates.AttackTransitionOut;
                }
                if (SpawningUnderRate.TryTick())
                {
                    SpawnTentacleUnderPlayer();
                }
                break;
            case BossStates.SpawningRow:
                if (SpawningRowState.TryTick())
                {
                    CurrentBossState = BossStates.AttackTransitionOut;
                }
                if (SpawningRowRate.TryTick())
                {
                    SpawnTentacleRowTowardsPlayer();
                }
                break;
            case BossStates.Spitting:
                if (SpittingState.TryTick())
                {
                    CurrentBossState = BossStates.SpawningDefense;
                }
                if (SpawningRowRate.TryTick())
                {
                    SpawnSpit();
                }
                break;
            case BossStates.SpawningDefense:
                if (SpawningDefenseState.TryTick())
                {
                    CurrentBossState = BossStates.AttackTransitionOut;
                }
                if (SpawningDefenseRate.TryTick())
                {
                    SpawnTentacleCircle();
                }
                break;
            case BossStates.AttackTransitionOut:
                if (AttackTransitionOut.TryTick())
                {
                    CurrentBossState = BossStates.Idle;
                }
                break;
            case BossStates.Resting:
                if (Resting.TryTick())
                {
                    CurrentBossState = BossStates.Idle;
                }
                break;
            default:
                break;
        }
    }
}
