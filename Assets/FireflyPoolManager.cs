using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPoolManager : MonoBehaviour
{
    public GameObject fireflyPrefab;
    public int poolSize = 20;
    public float spawnInterval = 1.0f;
    public Vector2 groupSize = new Vector2(2, 2);
    public float movementSpeed = 1.0f;
    public Vector2 movementRange = new Vector2(1, 1);
    public float fireflyLifetime = 10.0f;

    private List<GameObject> fireflyPool;
    private int currentFireflyIndex = 0;

    void Start()
    {
        if (fireflyPrefab == null)
        {
            Debug.LogError("Firefly Prefab is not assigned.");
            return;
        }

        // Create the firefly pool
        fireflyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject firefly = Instantiate(fireflyPrefab);
            firefly.SetActive(false); // Initially inactive
            fireflyPool.Add(firefly);
        }

        // Start spawning fireflies
        StartCoroutine(SpawnFireflies());
    }

    IEnumerator SpawnFireflies()
    {
        while (true)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(-groupSize.x / 2, groupSize.x / 2),
                Random.Range(-groupSize.y / 2, groupSize.y / 2)
            );

            // Get a firefly from the pool
            GameObject firefly = fireflyPool[currentFireflyIndex];
            firefly.transform.position = (Vector2)transform.position + randomPosition;
            firefly.SetActive(true);

            // Start moving and deactivating the firefly
            FireflyMovement fireflyMovement = firefly.GetComponent<FireflyMovement>();
            if (fireflyMovement != null)
            {
                fireflyMovement.StartMovement(movementSpeed, movementRange);
            }

            StartCoroutine(DeactivateFireflyAfterTime(firefly, fireflyLifetime));

            // Move to the next firefly in the pool
            currentFireflyIndex = (currentFireflyIndex + 1) % poolSize;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator DeactivateFireflyAfterTime(GameObject firefly, float time)
    {
        yield return new WaitForSeconds(time);
        firefly.SetActive(false);
    }
}