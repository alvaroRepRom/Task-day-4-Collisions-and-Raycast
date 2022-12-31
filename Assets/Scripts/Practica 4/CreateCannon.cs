using UnityEngine;

public class CreateCannon : MonoBehaviour
{
    [SerializeField] private GameObject cannonPrefab;

    private bool isCreated;

    private void OnMouseUp()
    {
        if (isCreated) return;
        Instantiate(cannonPrefab, transform.position, transform.rotation);
        isCreated = true;
    }
}
