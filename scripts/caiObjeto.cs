using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caiObjeto : MonoBehaviour
{
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objeto.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
