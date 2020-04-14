using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchAndRotate : MonoBehaviour
{
    public GameObject globe;
    GameObject aimer;

    void Start()
    {
        aimer = new GameObject();
    }

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {

            if (Input.GetMouseButtonDown(0))
            {
                aimer.transform.LookAt(hit.point);
                globe.transform.parent = aimer.transform;
            }
            if (Input.GetMouseButton(0))
            {
                aimer.transform.LookAt(hit.point);
            }
            if (Input.GetMouseButtonUp(0))
            {
                globe.transform.parent = null;
            }

        }
    }
}
