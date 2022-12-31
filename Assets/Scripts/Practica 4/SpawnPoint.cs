using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawntime;

    private float timer = 0f;

    private void Update() => SpawnTimer();

    private void SpawnTimer()
    {
        timer += Time.deltaTime;
        if (timer >= spawntime)
        {
            Spawn();
            timer = 0f;
        }
    }

    private void Spawn()
    {
        Instantiate(spawnPrefab, transform.position, transform.rotation);
    }
}
