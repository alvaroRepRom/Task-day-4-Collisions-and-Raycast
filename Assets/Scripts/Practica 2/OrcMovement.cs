using UnityEngine;

public class OrcMovement : MonoBehaviour, IDamagable
{
    [Header("Target Transform")]
    [SerializeField] private Transform target;
    [Header("Physics")]
    [SerializeField] private float speed;

    public Transform Target { set { target = value; } }

    private void Update() => Movement();
    private void Movement()
    {
        transform.LookAt(target);
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public void Damage()
    {
        Destroy(gameObject);
    }
}
