using UnityEngine;

public class OrcFinalMove : MonoBehaviour
{
    private Transform target;
    private float speed = 3f;

    public Transform Target { set { target = value; } }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        transform.LookAt(target);
    }
}
