using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Transform playerTrans;
    [SerializeField] private float radius;

    private ScreenToWorld screenToWorld;

    private void Awake()
    {
        screenToWorld = GetComponent<ScreenToWorld>();
    }

    public void Spawn()
    {
        if (playerTrans == null) return; // Stop Spawning if there is no player to attack
        GameObject clone = Instantiate(spawnPrefab, screenToWorld.RandomBorderPosition(), Quaternion.identity);
        clone.GetComponent<OrcMovement>().Target = playerTrans;
    }
}
