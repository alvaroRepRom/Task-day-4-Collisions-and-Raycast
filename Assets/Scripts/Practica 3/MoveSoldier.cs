using UnityEngine;

public class MoveSoldier : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distanceToStop;

    private float originalSpeed;
    private bool canMove = true;
    private string blacksmithTag = "Blacksmith";

    private void Start() => SaveSpeed();

    private void Update()
    {
        CheckWallHit();
        Move();
    }

    private void Move()
    {
        if (canMove)
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void CheckWallHit()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distanceToStop)) return;
        if (hit.collider.tag == blacksmithTag)
            canMove = false;
        else
            transform.Rotate(Vector3.up * 90);
    }

    private void SaveSpeed() => originalSpeed = speed;
    public void UpdateSpeed(float newSpeed) => speed = newSpeed;
    public void ResetSpeed() => speed = originalSpeed;
}
