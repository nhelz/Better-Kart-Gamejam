using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public int maxClones;

    [SerializeField]
    private GameObject[] SpawnedItems;
    [SerializeField]
    private int activeClones = 0;
    private bool canSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnedItems = new GameObject[maxClones];
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn && activeClones < SpawnedItems.Length)
        {
            canSpawn = false;
            spawnItem();
        }
    }

    private void Initialize()
    {
        for(int i = 0; i < SpawnedItems.Length; i++)
        {
            SpawnedItems[i] = Instantiate(ItemPrefab, transform);
            SpawnedItems[i].transform.localPosition = new Vector3(0f, 0f, 0f);
            SpawnedItems[i].SetActive(false);
        }
        canSpawn = true;
    }

    private void spawnItem()
    {
        int nextItem = GetNextItem();
        if(nextItem >= 0)
        {
            SpawnedItems[nextItem].SetActive(true);
            SpawnedItems[nextItem].GetComponent<CollectibleMechanics>().SetSpawned(true);
            //SpawnedItems[activeClones].GetComponent<CollectibleMechanics>().Throw(transform.position, transform.position + Vector3.forward * 3, new Quaternion(0f, Random.Range(0f, 360f), 0f, 0f));
            SpawnedItems[nextItem].GetComponent<CollectibleMechanics>().Throw(transform.position, Quaternion.Euler(new Vector3(0f, Random.Range(-360f, 360f), 0f)), 3f, Random.Range(3f, 5f));
            activeClones++;
        }
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.4f);
        canSpawn = true;
    }

    private int GetNextItem()
    {
        for(int i = 0; i < SpawnedItems.Length; i++)
        {
            if (!SpawnedItems[i].activeInHierarchy && !SpawnedItems[i].GetComponent<CollectibleMechanics>().Spawned())
            {
                return i;
            }
        }
        return -1;
    }

    public void CaughtItem()
    {
        activeClones--;
    }
}
