using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public UnityEvent OnFinished;
    public bool RiderCheck = false;
    public bool BikeCheck = false;
    [SerializeField] private int bikeLayer;
    [SerializeField] private int riderLayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == riderLayer&&RiderCheck == false)
        {
            BikeCheck = true;
            OnFinished.Invoke();
        }
    }


}

