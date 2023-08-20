using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private GameObject Camera;
    public Transform target;
    public float offset;
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offset, target.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offset, target.transform.position.z);
    }
}
