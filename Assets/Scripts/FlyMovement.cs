using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyMovement : MonoBehaviour
{
    private Vector3 initialPos;
    private Vector3 limitPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.gameObject.transform.localPosition;
        limitPos = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y -9f, this.gameObject.transform.localPosition.z);

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, 
            Mathf.PingPong(Time.time * 10, initialPos.y - limitPos.y) + limitPos.y, this.gameObject.transform.localPosition.z);
    }
}
