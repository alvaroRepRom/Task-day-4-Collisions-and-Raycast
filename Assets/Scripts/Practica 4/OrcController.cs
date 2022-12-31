using UnityEngine;

public class OrcController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * transform.forward, Space.World);
    }

    public void ChangeDirection(Transform lookAt)
    {
        transform.LookAt(lookAt);
    }
}
