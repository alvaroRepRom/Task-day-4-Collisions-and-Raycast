using UnityEngine;

public class GroundChange : MonoBehaviour
{
    [SerializeField] private float groundSpeed;
    [SerializeField] private string colTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == colTag)
            other.GetComponent<MoveSoldier>().UpdateSpeed(groundSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == colTag)
            other.GetComponent<MoveSoldier>().ResetSpeed();
    }
}
