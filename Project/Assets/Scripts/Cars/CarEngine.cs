using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour {

    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFL; //wheel front left
    public WheelCollider wheelFR; //wheel front right
    public WheelCollider wheelRL; 
    public WheelCollider wheelRR; 
    public float maxMotorTorque = 300f;
    public float maxBrakeTorque = 150f;
    public float currentSpeed;
    public float maxSpeed = 100f;
    public Vector3 centerOfMass;
    public Light[] lights;

    private List<Transform> nodes;
    private int currentNode = 0;
    public bool isBraking;
    // Use this for initialization
    private void Start () {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
    }
    
    // Update is called once per frame
    private void FixedUpdate () {
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
    }

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed && !isBraking)
        {
            wheelFR.motorTorque = maxMotorTorque;
            wheelFL.motorTorque = maxMotorTorque;
        }
        else
        {
            wheelFR.motorTorque = 0f;
            wheelFL.motorTorque = 0f;
        }
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 7f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }

    private void Braking()
    {
        foreach (Light light in lights)
        {
            if (isBraking)
            {
                light.enabled = true;
                wheelRL.brakeTorque = maxBrakeTorque;
                wheelRR.brakeTorque = maxBrakeTorque;
            }
            else
            {
                light.enabled = false;
                wheelRL.brakeTorque = 0f;
                wheelRR.brakeTorque = 0f;
            }

        }
    }
}
