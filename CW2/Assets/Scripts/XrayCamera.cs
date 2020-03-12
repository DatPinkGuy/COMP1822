using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
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
    private bool _reset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!handSnap)
        {
            if (_reset) return;
            StartCoroutine(ResetHand()); //doesnt work because Oculus are a failure
            return;
        }
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
            _reset = false;
        }
    }

    IEnumerator ResetHand()
    {
        _reset = true;
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(1f, 1f);
        OVRInput.RecenterController();
        Debug.Log(OVRInput.GetControllerWasRecentered());
        
    }
}
