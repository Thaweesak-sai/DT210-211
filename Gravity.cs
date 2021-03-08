using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject sun;
    private Vector3 sunPosition;
    public GameObject planet;
    private Vector3 planetPosition;
    public Rigidbody sunRigidBody; 
    public Rigidbody planetRigidBody;
   // private readonly float planetMass = 10000.0f;
    //private readonly float sunMass = 100000000000.0f;
    Vector3 startVelocity = new Vector3(0f, 10f, 0f);

    Vector3 originalPosition;
    Vector3 newPosition;
    Vector3 velocity;
    Vector3 acceleration;

    public Vector3 calculateForce()
    {
        Debug.Log("KAPPA");
        return (forceWithDirection);
    }

    // Start is called before the first frame update
    void Start()
    {
        planetRigidBody.AddForce(startVelocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
                Debug.Log("DO IT DO IT");

        
    }
}
