using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XrayResult : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxFov;
    [SerializeField] private RawImage image;
    private ResultArea _resultArea;
    private XrayCamera _xRayCamera;
    private bool _isResultFine;
    // Start is called before the first frame update
    void Start()
    {
        _xRayCamera = FindObjectOfType<XrayCamera>();
        _resultArea = FindObjectOfType<ResultArea>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var fov = _xRayCamera.xrayCamera.fieldOfView;
        if (fov > minMaxFov.x && fov < minMaxFov.y)
        {
            if (_resultArea.colliderInArea.Count >= 2) _isResultFine = true;
        }
    }
}
