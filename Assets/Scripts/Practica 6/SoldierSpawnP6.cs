using UnityEngine;

public class SoldierSpawnP6 : MonoBehaviour
{
    [SerializeField] private GameObject soldierPrefab;
    [SerializeField] private int numOfSoldiers;
    [SerializeField] private float spawnRadius;

    private float maxDimension;

    private void Start() => GetColliderMaxDimension();
    private void GetColliderMaxDimension()
    {
        Vector3 bounds = GetComponent<Collider>().bounds.max;
        maxDimension = bounds.x > bounds.z ? bounds.x : bounds.z;
    }

    public void SpawnSoldiers()
    {
        for (int i = 0; i < numOfSoldiers; i++)
        {
            Vector3 spawnPos = transform.position + RandomPosition();
            Instantiate(soldierPrefab, spawnPos, Quaternion.identity);
        }
    }

    private Vector3 RandomPosition()
    {
        float r1 = Random.Range(maxDimension, spawnRadius);
        float r2 = Random.Range(maxDimension, spawnRadius);

        int seedX = Random.Range(0, 13);
        int seedY = Random.Range(0, 13);
        r1 *= seedX % 2 == 0 ? -1 : 1;
        r2 *= seedY % 3 == 0 ? -1 : 1;

        return new Vector3(r1, 0, r2);
    }
}
