using UnityEngine;
using UnityEngine.Events;

public class Rider : MonoBehaviour
{
    public UnityEvent OnCrash;


    public bool IsCrashed
    {
        get
        {
            return crashed;
        }
        private set
        {
            crashed = false;
        }

    }
    private bool crashed;

    [SerializeField] private FixedJoint2D[] BodyRetainers;

    public void Crash()
    {
        if(IsCrashed == false)
        {
            for (int i = 0; i < BodyRetainers.Length; i++)
            {
                if(BodyRetainers[i] != null)
                {
                    Destroy(BodyRetainers[i]);
                }
            }
            IsCrashed = true;
            OnCrash.Invoke();
        }
    }
}
