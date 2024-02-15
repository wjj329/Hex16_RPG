using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";
    private HealthSystem playerHealthSystem;
    

    [SerializeField] private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnPosCount = 0;

    public float spawnInterval = .5f;
    public List<GameObject> MonstersPrefabs = new List<GameObject>();

    [SerializeField] private Slider hpGaugeSlider;
    [SerializeField] private Transform spawnPositionsRoot;
    private List<Transform> spawnPositions = new List<Transform>();
    public List<GameObject> rewards = new List<GameObject>();



    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        for (int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            spawnPositions.Add(spawnPositionsRoot.GetChild(i));
        }
    }



    private void Start()
    {

        StartCoroutine("StartNextWave");
    }

    //private void Update()
    //{

    //}



    private bool Startloof = true;

    IEnumerator StartNextWave()
    {


        while (Startloof)
        {

 
                yield return new WaitForSeconds(2f);

                if (currentWaveIndex % 10 == 0)
                {
                    waveSpawnPosCount = waveSpawnPosCount + 1 > spawnPositions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
                    waveSpawnCount = 0;
                }

                if (currentWaveIndex % 5 == 0)
                {
                    CreateReward();
                }

                if (currentWaveIndex % 3 == 0)
                {
                    waveSpawnCount += 1;
                }

                for (int i = 0; i < waveSpawnPosCount; i++)
                {
                    int posIdx = Random.Range(0, spawnPositions.Count);
                    for (int j = 0; j < waveSpawnCount; j++)
                    {
                        int prefabIdx = Random.Range(0, MonstersPrefabs.Count);
                        GameObject monster = Instantiate(MonstersPrefabs[prefabIdx], spawnPositions[posIdx].position, Quaternion.identity);
                        monster.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;
                        //monster.GetComponent<CharacterStatsHandler>
                        currentSpawnCount++;
                        yield return new WaitForSeconds(spawnInterval);
                    }
                }

            
             currentWaveIndex++;


            yield return null;

        }


    }
    private void OnEnemyDeath()
    {
        currentSpawnCount--;
    }


    private void UpdateWaveUI()
    {
        //waveText.text = (currentWaveIndex + 1).ToString();
    }







    void CreateReward()
    {
        int idx = Random.Range(0, rewards.Count);
        int posIdx = Random.Range(0, spawnPositions.Count);

        GameObject obj = rewards[idx];
        Instantiate(obj, spawnPositions[posIdx].position, Quaternion.identity);
    }

}
