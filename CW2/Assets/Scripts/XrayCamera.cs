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
    public bool _handSnap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_handSnap) return;
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
                    _handSnap = true;
                }
            }
        }
    }

    private void CameraFunctionality()
    {
        handGrabber.transform.position = snapPoint.position;
        Vector3 rotation = new Vector3(0,handGrabber.transform.rotation.y*-50,0);
        transform.rotation = Quaternion.Euler(rotation);
        if (!OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            _handSnap = false;
            //handGrabber.transform.position = new Vector3(0,0,0);
        }
    }
}
