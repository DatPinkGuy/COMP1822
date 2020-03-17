using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultArea : MonoBehaviour
{
    [HideInInspector] public List<ResultColliders> colliderForXray;
    [HideInInspector] public List<Collider> colliderList;
    public List<Collider> colliderInArea;
    // Start is called before the first frame update
    void Start()
    {
        colliderForXray.AddRange(FindObjectsOfType<ResultColliders>());
        foreach (var col in colliderForXray)
        {
            colliderList.Add(col.GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var col in colliderList)
        {
            if (col == other) colliderInArea.Add(col);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var col in colliderList)
        {
            if (col == other) colliderInArea.Remove(col);
        } 
    }
}


