using UnityEngine;

public class DestroyCannon : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == enemyTag) 
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
