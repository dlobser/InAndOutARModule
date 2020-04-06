using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlaceObjects : MonoBehaviour
{

    public GameObject A;
    public GameObject B;
    public GameObject placer;

    [Range(0,1)]
    public float t;

    void Start()
    {
        
    }


    void Update()
    {
        placer.transform.position = Vector3.Lerp(
            A.transform.position,
            B.transform.position, t);
        placer.transform.localScale = Vector3.Lerp(
            A.transform.localScale,
            B.transform.localScale, t);
        placer.transform.rotation = Quaternion.Slerp(
           A.transform.rotation,
           B.transform.rotation, t);
    }
}
