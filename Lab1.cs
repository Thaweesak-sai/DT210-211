using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lab1 : MonoBehaviour
{
    [Range(-10.0f, 10.0f)] public float G = 6.67f;

    public GameObject sun;
    public GameObject earth;

    private Rigidbody sunRB;
    private Rigidbody earthRB;
    [SerializeField] float sunMass = 50000;
    [SerializeField] float earthMass = 150;

    [SerializeField] private Vector3 initialVelocity = new Vector3(0.0f, 15.0f, 0.0f);//Vector3.right;

    private Vector3 originalPos, prevPosition, newPosition;
    private Vector3 velocity;
    private Vector3 acceleration;
    Vector3 movingDir;
    [SerializeField] private float distance_e2s;

    private float force;
    private Vector3 dir;
    //[Range(0, 10.0f)] [SerializeField] float timeScale;

    // Start is called before the first frame update
    void Start()
    {
        sunRB = sun.GetComponent<Rigidbody>();
        earthRB = earth.GetComponent<Rigidbody>();

        earthRB.mass = earthMass;
        sunRB.mass = sunMass;

        originalPos = earth.transform.position;
        earthRB.AddForce(initialVelocity, ForceMode.VelocityChange);
    }

    private Vector3 calForce()
    {

        //distance between Earth and the Sun 
        distance_e2s = Vector3.Distance(sun.transform.position, earth.transform.position);
        force = (G * sunRB.mass * earthRB.mass) / (distance_e2s * distance_e2s);

        Vector3 sPos = sun.GetComponent<Transform>().position;
        Vector3 ePos = earth.GetComponent<Transform>().position;
        movingDir = (sPos - ePos);
        dir = (force * (movingDir / movingDir.magnitude));

        return dir;
    }

    /*
         private void FixedUpdate()
    {
        float time = 0.001f;
        originalPosition = earth.transform.position;
        acceleration = (Force() / earthRigid.mass);
        earth.transform.position += (velocity * time + 0.5f * acceleration * time * time);
        newPosition = earth.transform.position;
        velocity = (newPosition - originalPosition) / time;
        Debug.Log(velocity);
    }*/
    void FixedUpdate()
    {
        float time = 0.001f;
        //Time.timeScale = timeScale;
        prevPosition = earth.transform.position;
        acceleration = (calForce() / earthRB.mass);
        earth.transform.position += (velocity * time + 0.5f * acceleration * time * time);

        newPosition = earth.transform.position;
        velocity = (newPosition - prevPosition) / time;
        Debug.Log("Velocity: " + velocity);
        //acceleration = -(earthRB.velocity.magnitude * earthRB.velocity.magnitude) / distance_e2s;
    }
}
