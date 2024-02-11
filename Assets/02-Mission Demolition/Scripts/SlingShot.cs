using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    static private Slingshot S;
    Behaviour halo;

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    [Header("Set in Dynamically")]
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public GameObject launchPoint;
    private Rigidbody projectileRigidbody;
    // Start is called before the first frame update

    static public Vector3 LAUNCH_POS
    {
        get
        {
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }
    }
    void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.FindChild("LaunchPoint");
        halo = (Behaviour)launchPoint.GetComponent("Halo");
        halo.enabled = false;

        launchPos = launchPoint.transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode) return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
        }
    }

    private void OnMouseEnter()
    {
        //print("OnMouseEnter");
        halo.enabled = true;
    }

    private void OnMouseExit()
    {
        //print("OnMouseExit");
        halo.enabled = false;
    }

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
    }
}
