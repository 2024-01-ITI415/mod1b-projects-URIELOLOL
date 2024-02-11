using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update

    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.03f;
    public Vector2 minXY = Vector2.zero;


    [Header("Set Dynamically")]
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {

        //if (POI == null) return;
        //Vector3 destination = POI.transform.position;
        Vector3 destination;

        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;

            // If poi is a Projectile, check to see if it's at rest

            if (POI.tag == "Projectile")
            {

                // if it is sleeping (that is, not moving)

                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    // return to default view
                    POI = null;

                    // in the next update
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
