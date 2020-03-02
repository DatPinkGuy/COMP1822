using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultColliders : MonoBehaviour
{
    public Collider boneCollider;
    // Start is called before the first frame update
    void Start()
    {
       boneCollider = GetComponent<Collider>();
    }
}
