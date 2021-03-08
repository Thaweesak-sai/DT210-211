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
        //Find the positions of the objects
        sunPosition = sun.transform.position;
        planetPosition = planet.transform.position;
        // R 
        float distance = Vector3.Distance(sunPosition, planetPosition);
        Debug.Log("Distance " + distance);
        // R^2
        float distanceSquared = distance * distance;
        Debug.Log("Distance square" + distanceSquared);
        //Gravitational Constant
        float G = 6.67f;
        // F = G*m*m/ r^2
        Debug.Log("G Constant = " + G);
        float force = G * sunRigidBody.mass * planetRigidBody.mass / distanceSquared;
        // Get the heading
        Debug.Log("Force " + force);
        Vector3 heading = (sunPosition - planetPosition);
        Debug.Log("What is Heading" + heading);
        // Turn the force from just a value into a 3D vector with direction
        Vector3 forceWithDirection = (force * (heading/ heading.magnitude));
        // Force
        Debug.Log("forceWithDirection = "+forceWithDirection);
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
        float time = 0.001f;
        originalPosition = planet.transform.position;
        acceleration = (calculateForce() / planetRigidBody.mass);
        planet.transform.position += (velocity * time + 0.5f * acceleration * time * time);
        newPosition = planet.transform.position;
        velocity = (newPosition - originalPosition) / time;
        print(velocity);
        
    }
}
