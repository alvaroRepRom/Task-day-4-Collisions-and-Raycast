using UnityEngine;

public class AutoCannon : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform firetPos;
    [SerializeField] private float fireCoolDown;

    private Transform target;
    private float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        target = other.transform;
    }

    private void Update()
    {
        Aim();
        Fire();
    }

    private void Aim() => transform.LookAt(target);
    private void Fire()
    {
        timer += Time.deltaTime;
        if (timer >= fireCoolDown)
        {
            Instantiate(ballPrefab, firetPos.position, firetPos.rotation);
            timer = 0f;
        }
    }
}
