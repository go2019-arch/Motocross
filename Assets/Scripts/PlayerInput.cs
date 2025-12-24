using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static bool Brake;
    

    public static bool InvertHorizontal = true;
    public static bool InvertVertical = false;

    [SerializeField] private Joystick joystick;
    
    void Update()
    {
#if PLATFORM_STANDALONE
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Brake = Input.GetButton("Jump");
#elif PLATFORM_ANDROID || PLATFORN_IOS
        if (joystick != null)
        {
            Horizontal = joystick.Horizontal;
            Vertical = joystick.Vertical;
        }
#endif        
        if (InvertHorizontal)
        {
            Horizontal *= -1;
        }
        
        if (InvertVertical)
        {
            Vertical *= -1;
        }
    
        
    }

    public void BrakeOn()
    {
        if (Brake == false)
        {
            Brake = true;
        }
    }
    public void BrakeOff()
    {
        if (Brake == true)
        {
            Brake = false;
        }
    }
}
