using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject p = Instantiate(particles);
        p.transform.position = this.transform.position;
        Destroy(p, 1);
        Destroy(this.gameObject);
    }
}
