using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;

public class MachinePopUp : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private OVRGrabber handGrabber;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (var volumes in handGrabber.grabVolumes)
        {
            if (other == volumes)
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                   canvas.SetActive(true);
                }
            }
        }
    }
}
