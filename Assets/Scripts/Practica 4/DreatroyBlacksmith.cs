using UnityEngine;

public class DreatroyBlacksmith : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == enemyTag)
            Destroy(gameObject);
    }
}
