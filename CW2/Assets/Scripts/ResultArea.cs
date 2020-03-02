using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultArea : MonoBehaviour
{
    public List<ResultColliders> _colliderForXray;
    public List<Collider> _colliderList;
    public List<Collider> colliderInArea;
    // Start is called before the first frame update
    void Start()
    {
        _colliderForXray.AddRange(FindObjectsOfType<ResultColliders>());
        foreach (var col in _colliderForXray)
        {
            _colliderList.Add(col.GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var col in _colliderList)
        {
            if (col == other) colliderInArea.Add(col);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var col in _colliderList)
        {
            if (col == other) colliderInArea.Remove(col);
        } 
    }
}


