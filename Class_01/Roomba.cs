using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public GameObject thing;
    GameObject dummy;

    Quaternion rotateFrom;
    Quaternion rotateTo;

    Vector3 moveFrom;
    Vector3 moveTo;

    public float speed = 1;

    void Start(){
        dummy = new GameObject("dummy");
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //g.transform.position = hit.point;
            //g.transform.LookAt(hit.point + hit.normal);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                print("get new position");
                print(moveFrom);
                print(moveTo);
                moveFrom = thing.transform.position;
                moveTo = hit.point;
                rotateFrom = thing.transform.rotation;
                dummy.transform.position = thing.transform.position;
                dummy.transform.LookAt(hit.point);
                rotateTo = dummy.transform.rotation;
            }

            StartCoroutine(rotator());
        }
    }

    IEnumerator rotator(){
        print("start rotator");
        float counter = 0;
        while(counter<1){
            counter += Time.deltaTime * speed;
            thing.transform.rotation = Quaternion.Slerp(rotateFrom, rotateTo, counter);
            yield return null;
        }
        StartCoroutine(translator());
        yield return null;
    }

    IEnumerator translator()
    {
        print("start translator");
        float counter = 0;
        while (counter < 1)
        {
            counter += Time.deltaTime * speed;
            thing.transform.position = Vector3.Lerp(moveFrom, moveTo, counter);
            yield return null;
        }
        yield return null;
    }
}
