using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrayCamera : MonoBehaviour
{
    public Camera xrayCamera;
    [SerializeField] private OVRGrabber handGrabber;
    [SerializeField] private Transform snapPoint => GetComponentInChildren<Transform>();
    private Rigidbody rb => GetComponent<Rigidbody>();
    public bool handSnap;
    private Vector3 _oldRotation;
    private Vector3 _currentRotation;
    private Vector3 _rotationDifference; 
    private float _angle;
    private Quaternion _rotationQuaternion;
    private Transform HandTransform => handGrabber.transform;
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
        Vector3 rotation = new Vector3(0, handGrabber.transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(rotation);
        xrayCamera.fieldOfView = transform.rotation.y * 180;
        HandTransform.position = snapPoint.position;
        if (!OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            handSnap = false;
        }
    }
}
