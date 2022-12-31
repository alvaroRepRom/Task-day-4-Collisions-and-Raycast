using UnityEngine;

public class ChangeOrcDirection : MonoBehaviour
{
    [SerializeField] private Transform newDirectionToLook;

    private void OnTriggerEnter(Collider collision)
    {
        collision.GetComponent<OrcController>()?.ChangeDirection(newDirectionToLook);
    }
}
