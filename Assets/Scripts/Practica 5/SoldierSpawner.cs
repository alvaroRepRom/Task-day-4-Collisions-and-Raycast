using UnityEngine;
using ARR;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject soldierPrefab;
    [SerializeField] private int numOfSoldiers;
    [SerializeField] private float spawnRadius;
    
    private float soldierRadius;
    private float maxDimension;
    private string groundTag = "Ground";

    private void Start()
    {
        GetColliderMaxDimension();
        GetSoldierColliderRadius();
    }

    private void GetColliderMaxDimension()
    {
        Vector3 bounds = GetComponent<Collider>().bounds.max;
        maxDimension = bounds.x > bounds.z ? bounds.x : bounds.z;
    }
    private void GetSoldierColliderRadius() => soldierRadius = soldierPrefab.GetComponent<CapsuleCollider>().radius;

    private void OnMouseUp() => SpawnSoldiers();
    private void SpawnSoldiers()
    {
        for (int i = 0; i < numOfSoldiers; i++)
        {
            Vector3 spawnPos = transform.position + MyMath.RandomConcentricXZ(maxDimension, spawnRadius);
            if (!CanInstantiate(spawnPos)) continue;
            GameObject clone = Instantiate(soldierPrefab, spawnPos, Quaternion.identity);
            // Turn soldier to show the back to the blacksmith
            clone.transform.LookAt(transform);
            clone.transform.Rotate(Vector3.up * 180);
        }
    }

    private bool CanInstantiate(Vector3 spawnPos)
    {
        Collider[] collisions = Physics.OverlapSphere(spawnPos, soldierRadius);
        
        foreach (Collider collision in collisions)
        {
            if (collision.tag == groundTag) continue; // if is the ground ignore
            return false; // if is other object then it cannot instantiate
        }
        return true; // else can instantiate
    }
}
