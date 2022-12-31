using UnityEngine;
using ARR;

public class LichSacrifice : MonoBehaviour
{
    [SerializeField] private GameObject orcPrefab;
    [SerializeField] private int numOfOrcs;
    [SerializeField] private Transform blacksmithTrans;
    [Header("Radius respect the Blacksmith Transform")]
    [SerializeField] private float minSpawnRadius;
    [SerializeField] private float maxSpawnRadius;

    public void Sacrifice()
    {
        Spawn();
        Destroy(gameObject);
    }

    private void Spawn()
    {
        for (int i = 0; i < numOfOrcs; i++)
        {
            Vector3 spawnPos = blacksmithTrans.position + MyMath.RandomConcentricXZ(minSpawnRadius, maxSpawnRadius);
            GameObject clone = Instantiate(orcPrefab, spawnPos, Quaternion.identity);
            clone.GetComponent<OrcFinalMove>().Target = blacksmithTrans;
        }
    }
}
