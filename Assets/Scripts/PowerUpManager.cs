using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTempelateList;

    private List<GameObject> powerUpList;

    private float timer;
    public float despawnTime;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }
    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

            int randomIndex = Random.Range(0, powerUpTempelateList.Count);

            GameObject powerUp = Instantiate(powerUpTempelateList[randomIndex], new Vector3( position.x, position.y, powerUpTempelateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
            powerUp.SetActive(true);

            powerUpList.Add(powerUp);
            StartCoroutine(DespawnPowerUpAfterDelay(powerUp, despawnTime));
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    private IEnumerator DespawnPowerUpAfterDelay(GameObject powerUp, float delay)
    {
        float startTime = Time.time; // Code replaced to try mitigate Coroutine conflict BUT IT STILL DOESNT WORK!
        while (Time.time < startTime + delay)
        {
            yield return null;
        }

        RemovePowerUp(powerUp);
    }


    public void RemoveAllPowerUp()
    {
        while(powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
