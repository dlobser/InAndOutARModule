using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Test : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits;

    // Start is called before the first frame update
    void Start()
    {
        hits = new List<ARRaycastHit>();


    }

    // Update is called once per frame
    void Update()
    {
        aRRaycastManager.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), hits);
        for (int i = 0; i < hits.Count; i++)
        {
            Debug.Log(hits[i]);
        }
    }
}
