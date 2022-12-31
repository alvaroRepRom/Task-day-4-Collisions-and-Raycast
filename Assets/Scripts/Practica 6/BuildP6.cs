using UnityEngine;

public class BuildP6 : MonoBehaviour
{

    [SerializeField] private GameObject blacksmithPrefab;
    [SerializeField] private float minTryBuildTime;
    [SerializeField] private float maxTryBuildTime;
    [SerializeField] private Vector3 blacksmithExtents;

    private Collider coll;
    private float tryBuildTime;
    private float timer = 0f;
    private string groundTag = "Ground";

    private void Awake() => coll = gameObject.GetComponent<Collider>();
    private void Start() => GenerateTryBuildTime();
    private void Update()
    {
        if (!IsTimeUp()) 
            return;
        Build();
        GenerateTryBuildTime();
    }

    private bool IsTimeUp()
    {
        timer += Time.deltaTime;
        if (timer >= tryBuildTime)
        {
            timer = 0f;
            return true;
        }
        return false;
    }

    private void GenerateTryBuildTime() => tryBuildTime = Random.Range(minTryBuildTime, maxTryBuildTime);

    private void Build()
    {
        if (!CanBuild()) return;
        Instantiate(blacksmithPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private bool CanBuild()
    {
        Collider[] collisions = Physics.OverlapBox(transform.position, blacksmithExtents, transform.rotation);

        foreach (Collider collision in collisions)
        {
            if (collision == coll) // if is this gameObject ignore
                continue;
            if (collision.tag == groundTag) // if is the ground ignore
                continue;
            return false; // if is other object then it cannot build
        }
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, blacksmithExtents);
    }
}
