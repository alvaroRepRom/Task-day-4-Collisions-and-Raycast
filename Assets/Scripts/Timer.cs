using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float eventTime = 1f;
    private float timer = 0f;

    public UnityEvent onTimeUp;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= eventTime)
        {
            onTimeUp?.Invoke();
            timer = 0f;
        }
    }    
}
