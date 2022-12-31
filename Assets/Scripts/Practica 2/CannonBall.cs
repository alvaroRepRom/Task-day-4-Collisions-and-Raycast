using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string enemyTag = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
        {
            other.GetComponent<IDamagable>()?.Damage();
            //Destroy(other.gameObject);
            DestroyBall();
        }
    }

    private void Update() => MoveBall();
    private void MoveBall() => transform.Translate(speed * Time.deltaTime * Vector3.forward);
    public void DestroyBall() => Destroy(gameObject);
}
