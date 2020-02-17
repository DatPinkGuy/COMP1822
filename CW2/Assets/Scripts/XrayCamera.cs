using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrayCamera : MonoBehaviour
{
    [SerializeField] private Camera xrayCamera;
    [SerializeField] private OVRGrabber handGrabber;
    [SerializeField] private Transform snapPoint => GetComponentInChildren<Transform>();
    private Rigidbody rb => GetComponent<Rigidbody>();
    public bool handSnap;
    private Vector3 _oldDirection;
    private float _angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!handSnap) return;
        CameraFunctionality();
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (var volumes in handGrabber.grabVolumes)
        {
            if (other == volumes)
            {
                if(OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
                {
                    handSnap = true;
                }
            }
        }
    }

    private void CameraFunctionality()
    {
        handGrabber.transform.position = snapPoint.position;
        Vector3 rotation = new Vector3(0,handGrabber.transform.rotation.y*-360,0);
        transform.rotation = Quaternion.Euler(rotation);
        _oldDirection = handGrabber.transform.InverseTransformDirection(handGrabber.transform.up);
        xrayCamera.fieldOfView = handGrabber.transform.rotation.y * -90;
        if (!OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            handSnap = false;
            //handGrabber.transform.position = new Vector3(0,0,0);
        }
    }
}
