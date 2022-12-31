using UnityEngine;

public class SoldierMoveP6 : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start() => ChangeRotationRandom();
    private void Update() => Move();
    private void Move() => transform.Translate(speed * Time.deltaTime * Vector3.forward);

    public void ChangeRotationRandom()
    {
        float j = Random.Range(0, float.MaxValue);
        transform.Rotate(j * Vector3.up);
    }
}
