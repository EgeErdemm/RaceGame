using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static Movement Instance;

    private Rigidbody rb;

    [SerializeField] private float accelerationPower;
    private float initialAccelerationPower;

    [SerializeField] private float carTopSpeed;
    private Vector3 maxVelocity;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialAccelerationPower = accelerationPower;
        maxVelocity = new Vector3(0f, 0f, carTopSpeed);
    }


    void Update()
    {
        Debug.Log("Current Speed: " + rb.velocity.magnitude);
        if (rb.velocity.magnitude > maxVelocity.magnitude)
        {
            rb.velocity = maxVelocity;
        }
    }



    public void Gas()
    {
        Vector3 forwardForce = transform.forward * accelerationPower;
        rb.AddForce(forwardForce, ForceMode.Acceleration);
    }


    public void SetAccelerationPower(int shift)
    {
        accelerationPower = initialAccelerationPower / shift;
    }

    public void VelocityReward(int border)
    {
        if(border < 3)
        {
            Vector3 velocity = rb.velocity;
            velocity.z = velocity.z + 10 * border;
            rb.velocity = velocity; 

        }
    }

    public void StopAcceleration()
    {
        accelerationPower = 0f;
    }


}
