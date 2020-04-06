using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{

    public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.DrawRay(ray.origin, ray.direction);
            target.transform.position = hit.point;
            target.transform.LookAt(hit.point + hit.normal);
            print(hit.transform.name);
            if(Input.GetMouseButtonDown(0)){
                Instantiate(target);
            }
        }

    }
}
