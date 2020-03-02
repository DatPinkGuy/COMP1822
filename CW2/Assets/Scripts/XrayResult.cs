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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var fov = _xRayCamera.xrayCamera.fieldOfView;
        Debug.Log(fov);
        Debug.Log(fov > minMaxFov.x && fov < minMaxFov.y);
        Debug.Log(_resultArea.colliderInArea.Count >= 2);
        if (fov > minMaxFov.x && fov < minMaxFov.y)
        {
            if (_resultArea.colliderInArea.Count >= 2) _isResultFine = true;
        }
        Debug.Log(_isResultFine);
        
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = _xRayCamera.xrayCamera.targetTexture;
 
        _xRayCamera.xrayCamera.Render();

        image.texture = activeRenderTexture;
//        Texture2D image = new Texture2D(_xRayCamera.xrayCamera.targetTexture.width,_xRayCamera.xrayCamera.targetTexture.height);
//        image.ReadPixels(new Rect(0, 0, _xRayCamera.xrayCamera.targetTexture.width, _xRayCamera.xrayCamera.targetTexture.height), 0, 0);
//        image.Apply();
//        RenderTexture.active = activeRenderTexture;
    }
}
