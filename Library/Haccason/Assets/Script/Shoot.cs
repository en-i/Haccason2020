using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public int shotX;

    public int shotY;

    public int shotZ;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)){
            arow(new Vector3(shotX, shotY, shotZ));
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        Rotate.decide = true;
    }
    public void arow (Vector3 ar) {
        GetComponent<Rigidbody> ().AddForce (ar);
    }
}