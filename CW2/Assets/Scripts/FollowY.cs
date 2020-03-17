using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowY : MonoBehaviour
{
    private float _thisY => transform.position.y;
    [SerializeField] private GameObject xRay;
    private float XrayY => xRay.transform.position.y;
    private float _difference;

    private Vector3 _thisPosition;
    // Start is called before the first frame update
    void Start()
    {
        _difference = XrayY - _thisY;
    }

    void Update()
    {
        ChangeY();
    }

    private void ChangeY()
    {
        _thisPosition = transform.position;
        _thisPosition.y = xRay.transform.position.y - _difference;
        transform.position = _thisPosition;
    }
}
