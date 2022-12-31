using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxImpactReceive;

    private int impactReceive = 0;

    public void Damage()
    {
        impactReceive++;
        if (impactReceive >= maxImpactReceive)
            Destroy(gameObject);
    }
}
