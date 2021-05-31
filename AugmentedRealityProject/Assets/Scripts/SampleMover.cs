using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMover : MonoBehaviour
{
    private Transform core;
    private Vector3 originalLocation;
    public Vector3 testLocation =  new Vector3(0,1,0);
    public float speed = 2.0f;
    public float turnRate = 5.0f;
    private bool reachedLocation = false;
    public float magnitude = 0.0f;
    public bool rotator = false;
    public float rotationSpeed = 1f;
    void Start()
    {
        core = GetComponent<Transform>();
        originalLocation = core.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        if(!rotator)
        {
            if (!reachedLocation)
            {
                Vector3 targetDirection = testLocation - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, testLocation, step);
                Vector3 newDirection = Vector3.RotateTowards(transform.position, targetDirection, turnRate * Time.deltaTime, magnitude);
                // Draw a ray pointing at our target in
                Debug.DrawRay(transform.position, newDirection, Color.red);
                Debug.DrawRay(transform.position, targetDirection, Color.yellow);

                Vector3 targetDirection1 = (testLocation - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection1);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate * Time.deltaTime);

                if (Vector3.Distance(transform.position, testLocation) < 0.5f)
                {
                    reachedLocation = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, originalLocation, step);
                Vector3 targetDirection1 = (originalLocation - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection1);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnRate * Time.deltaTime);
                if (Vector3.Distance(transform.position, originalLocation) < 0.5f)
                {
                    reachedLocation = false;
                }
            }
        }
        else
        {
            transform.Rotate(new Vector3(0,rotationSpeed,0)*Time.deltaTime);
        }



    }
}
