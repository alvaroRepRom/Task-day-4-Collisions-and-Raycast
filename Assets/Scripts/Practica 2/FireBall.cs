using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private GameObject cannonBallPrefab;
    [SerializeField] private float timeToFire;

    private bool canFire = true;
    private float timer = 0f;

    private void Update()
    {
        CoolDown();
        Launch();
    }

    private void Launch() 
    {
        if (!canFire) return;

        if (Input.GetMouseButton(0))
        {
            Instantiate(cannonBallPrefab, transform.position, transform.rotation);
            canFire = false;
            timer = 0f;
        }
    }

    private void CoolDown()
    {
        if (canFire) return;

        timer += Time.deltaTime;
        if (timer >= timeToFire)
            canFire = true;
    }
}
