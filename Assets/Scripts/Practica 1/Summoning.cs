using UnityEngine;

public class Summoning : MonoBehaviour
{
    [Header("Creature to Summon Prefab")]
    [SerializeField] private GameObject orcPrefab;

    [Header("Summoning Area Trigger Collider")]
    [SerializeField] private Collider summonArea;
    [SerializeField] private string   summonAreaTag = "Summon Area";

    [Header("Summon Spawn Distance")]
    [SerializeField] private float minSummonDistance;
    [SerializeField] private float maxSummonDistance;

    private bool canSummon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == summonAreaTag)
            canSummon = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == summonAreaTag)
            canSummon = false;
    }

    private void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.Space)) 
            Summon();
    }

    private void Summon()
    {
        if (!canSummon) return;

        float   distance = Random.Range(minSummonDistance, maxSummonDistance);
        Vector3 spawnPos = transform.forward * distance + transform.position;
        GameObject clone = Instantiate(orcPrefab, spawnPos, Quaternion.identity);
        clone.transform.LookAt(transform);
    }
}
