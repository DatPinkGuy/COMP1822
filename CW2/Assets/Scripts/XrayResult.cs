﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XrayResult : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxFov;
    [SerializeField] private RawImage image;
    [SerializeField] private Text textResult;
    [SerializeField] private String goodResult;
    [SerializeField] private String handPositionBad;
    [SerializeField] private String cameraTooFar;
    private ResultArea _resultArea;
    private XrayCamera _xRayCamera;
    //private bool _isResultFine;
    // Start is called before the first frame update
    void Start()
    {
        textResult.enabled = false;
        image.enabled = false;
        _xRayCamera = FindObjectOfType<XrayCamera>();
        _resultArea = FindObjectOfType<ResultArea>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var currentRT = RenderTexture.active;
        RenderTexture.active = _xRayCamera.xrayCamera.targetTexture;
        _xRayCamera.xrayCamera.Render();
        Texture2D image2D = new Texture2D( _xRayCamera.xrayCamera.targetTexture.width,  _xRayCamera.xrayCamera.targetTexture.height);
        image2D.ReadPixels(new Rect(0, 0,  _xRayCamera.xrayCamera.targetTexture.width,  _xRayCamera.xrayCamera.targetTexture.height), 0, 0);
        image2D.Apply();
        image.texture = image2D;
        //////
        textResult.text = null;
        textResult.enabled = true;
        image.enabled = true;
        var fov = _xRayCamera.xrayCamera.fieldOfView;
        if (fov > minMaxFov.x && fov < minMaxFov.y)
        {
            if (_resultArea.colliderInArea.Count >= 2)
            {
                //_isResultFine = true;
                textResult.text = goodResult;
            }
            else
            {
                textResult.text += handPositionBad;
            }
        }
        else
        {
            textResult.text += cameraTooFar;
            if (_resultArea.colliderInArea.Count < 2) textResult.text += handPositionBad;
        }
    }
}
