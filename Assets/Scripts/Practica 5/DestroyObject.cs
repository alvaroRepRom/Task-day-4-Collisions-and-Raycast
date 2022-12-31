using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private string destroyByTag = "Enemy";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == destroyByTag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
