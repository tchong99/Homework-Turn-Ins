using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    //initialize variables
    public GameObject player;
    public GameObject door;
    Vector3 endPos;
    Vector3 startPos;
    public Vector3 offset = new Vector3(0,-5,0);
    public float speed = 1f;
    public float proximityDistance = 3.0f;
    
    
    public bool proximity = false;
    bool startLerp = false;
    bool closeLerp = false;


    // Start is called before the first frame update
    void Start()
    {
        endPos = door.transform.position + offset;
        startPos = transform.position;
    }



    void StartLerping(Vector3 posToLerp)
    {
        if (Vector3.Distance(door.transform.position, posToLerp) > 0.05)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, posToLerp, speed * Time.deltaTime);
            startLerp = true;
        }
        else
        {
            startLerp = false;
        }
        
    }
    void CloseLerping(Vector3 posToLerp)
    {
        if (Vector3.Distance(door.transform.position, posToLerp) > 0.05)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, posToLerp, speed * Time.deltaTime);
            closeLerp = true;
        }
        else
        {
            closeLerp = false;
        }
    }

        // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < proximityDistance)
        {
            proximity = true;
        }
        else
        {
            proximity = false;
        }

        if (proximity)
        {
            CloseLerping(endPos);
        }

        else
        {
            StartLerping(startPos);
        }

    }
}
