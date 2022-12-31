using UnityEngine;

public class LichMovement : MonoBehaviour
{
    [Header("Movement Keys")]
    [SerializeField] private KeyCode upKey    = KeyCode.W;
    [SerializeField] private KeyCode downKey  = KeyCode.S;
    [SerializeField] private KeyCode leftKey  = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    [Header("Physics")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 200f;

    private void Update()
    {
        Vector3 moveAxis = MotionInput();
        Vector3 rotAxis  = RotationInput();
        Movement(moveAxis, rotAxis);
    }

    private Vector3 MotionInput()
    {
        if (Input.GetKey(upKey))
            return Vector3.forward;
        else
        if (Input.GetKey(downKey))
            return Vector3.back;

        return Vector3.zero;
    }

    private Vector3 RotationInput()
    {
        if (Input.GetKey(leftKey))
            return Vector3.down;
        else
        if (Input.GetKey(rightKey))
            return Vector3.up;

        return Vector3.zero;
    }

    private void Movement(Vector3 moveAxis, Vector3 rotAxis)
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveAxis);
        transform.Rotate(turnSpeed * Time.deltaTime * rotAxis);
    }
}
