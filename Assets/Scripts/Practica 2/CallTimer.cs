using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CallTimer : MonoBehaviour
{
    [SerializeField] private float eventTime = 1f;
    private WaitForSeconds secondsToWait;

    public UnityEvent onTimeUp;

    private void Start() => secondsToWait = new WaitForSeconds(eventTime);
    public void StartTimer() => StartCoroutine(TimerLoop());

    private IEnumerator TimerLoop()
    {
        yield return secondsToWait;
        onTimeUp?.Invoke();
    }
}
