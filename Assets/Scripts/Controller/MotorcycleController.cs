using UnityEngine;

public class MotorcycleController : MonoBehaviour
{
    [SerializeField] private float acceleration = 1000f;
    [SerializeField] private float rotationPower = 300f;


    [SerializeField] private Rigidbody2D motorcycleRB;


    [SerializeField] private WheelJoint2D rearWheel;
    [SerializeField] private WheelJoint2D frontWheel;


    private JointMotor2D motor;
    
    private void Awake()
    {
        motor = rearWheel.motor;
    }

    void Update()
    {
        if(PlayerInput.Brake == true)
        {
            Brake(frontWheel);
            Brake(rearWheel);
        }
        else if(PlayerInput.Horizontal != 0)
        {
            if (frontWheel != null) frontWheel.useMotor = false;
        
            if(rearWheel != null)
            {
                rearWheel.useMotor = true;

                float direction = PlayerInput.Horizontal;
                float speed = acceleration * direction;
                speed = PlayerInput.InvertHorizontal ? speed * -1 : speed;

                motor.motorSpeed = rearWheel.jointSpeed;
                motor.motorSpeed += speed * Time.fixedDeltaTime;

                rearWheel.motor = motor;
            }
        }
        else
        {
            if (frontWheel != null) frontWheel.useMotor = false;
            if (rearWheel != null) rearWheel.useMotor = false;
        }
        if (PlayerInput.Vertical != 0)
        {
            float vertical = Input.GetAxis("Vertical");


            motorcycleRB.MoveRotation(motorcycleRB.rotation += vertical * rotationPower * Time.fixedDeltaTime);
        }
    
        
    }
    private void Brake(WheelJoint2D wheel)
    {
        if (wheel == null) return;

        wheel.useMotor = true;

        motor.motorSpeed = 0;

        wheel.motor = motor;
    }

    
}
