using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallarinaManager : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer BallerinaLeft;
    private MeshRenderer BallerinaRight;
    void Start()
    {
        BallerinaLeft = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>();
        BallerinaRight = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    public void flipBallerina(int ID)
    {
        if (ID == 1)
        {
            if (BallerinaLeft.enabled == true)
            {
                BallerinaLeft.enabled = false;
            }
            else
            {
                BallerinaLeft.enabled = true;
            }
        }
        if (ID == 2)
        {
            if (BallerinaRight.enabled == true)
            {
                BallerinaRight.enabled = false;
            }
            else
            {
                BallerinaRight.enabled = true;
            }
        }
    }
}
