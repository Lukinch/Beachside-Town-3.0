using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinsSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject dolphinsPrefab;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private int spawnSize = 10;
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 5f;

    private List<GameObject> dolphinsList;
    private float delay;

    private void Awake()
    {
        dolphinsList = new List<GameObject>();
        FillPool();
    }

    private void Start() {
        StartCoroutine(nameof(SpawnDolphins));
    }

    private void Update() {
        if (transform.position.x != 0 && transform.position.z != 0) {
            transform.Translate(0,transform.position.y,0);
        }
    }

    private void FillPool()
    {
        for (int i = 0; i < spawnSize; i++)
        {
            var dolphin = Instantiate(
                dolphinsPrefab,
                gameObject.transform
            );
            dolphin.SetActive(false);
            dolphinsList.Add(dolphin);
        }
    }

    IEnumerator SpawnDolphins() {
        while (true) {
            delay = Random.Range(minSpawnTime, maxSpawnTime);

            EnableObjectInPool();
            yield return new WaitForSecondsRealtime(delay);
        }
    }

    private void EnableObjectInPool() {
        for (int i = 0; i < dolphinsList.Count; i++)
        {
            if(dolphinsList[i].activeInHierarchy == false) {
                SetSpawnPoint(dolphinsList[i]);
                
                dolphinsList[i].SetActive(true);
                return;
            }
        }
    }

    private void SetSpawnPoint(GameObject dolphin) {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 position = spawnPoints[spawnIndex].transform.position;

        Vector3 spawnPosition = new Vector3(position.x, dolphin.transform.position.y, position.z);
        Quaternion spawnRotation = spawnPoints[spawnIndex].transform.rotation;

        dolphin.transform.position = spawnPosition;
        dolphin.transform.rotation = spawnRotation;
    }
}
