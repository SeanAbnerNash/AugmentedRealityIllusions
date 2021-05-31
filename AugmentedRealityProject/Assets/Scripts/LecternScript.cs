using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecternScript : MonoBehaviour
{
    private bool playerInRange = false;
    private AudioSource audioSource;
    public AudioClip narration;
    public bool action = false;
    public GameObject ballarinaManager;
    public int ID;
    public MeshRenderer ESign;
    public bool quitAction = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && playerInRange)
        {
            if (action)
            {
                ballarinaManager.GetComponent<BallarinaManager>().flipBallerina(ID);
            }
            else if (quitAction)
            {

                Application.Quit();
            }
            else
            {
                audioSource.PlayOneShot(narration, 0.7F);
            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
        ESign.enabled = true;

    }

    public void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        ESign.enabled = false;
    }
}
