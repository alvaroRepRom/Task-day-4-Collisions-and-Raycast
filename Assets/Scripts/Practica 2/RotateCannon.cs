using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    [Header("Rotation Keys")]
    [SerializeField] private KeyCode leftKey  = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    [Header("Physics")]
    [SerializeField] private float turnSpeed = 200f;

    private void Update() => Rotation();
    private void Rotation() => transform.Rotate(turnSpeed * Time.deltaTime * RotationInput());
    private Vector3 RotationInput()
    {
        if (Input.GetKey(leftKey))
            return Vector3.down;
        else
        if (Input.GetKey(rightKey))
            return Vector3.up;

        return Vector3.zero;
    }
}
