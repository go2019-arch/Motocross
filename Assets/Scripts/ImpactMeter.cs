using UnityEngine;
using UnityEngine.Events;
public class ImpactMeter : MonoBehaviour
{
    public UnityEvent OnEmptyBlow;
    public UnityEvent OnStrongBlow;

    [SerializeField] private float hightImpactPower = 1f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude >= hightImpactPower)
        {
            OnStrongBlow.Invoke();
        }
        else
        {
            OnEmptyBlow.Invoke();
        }
    }
}
