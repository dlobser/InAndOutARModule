using UnityEngine;

public class ExampleRaycast : MonoBehaviour
{
    public GameObject thing;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log(hit.point);
            Debug.Log(hit.transform.name);

            if(Input.GetMouseButtonDown(0)){
                GameObject g = Instantiate(thing);
                g.transform.position = hit.point;
                g.transform.LookAt(hit.point + hit.normal);
            }

        }
    }
}