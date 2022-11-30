using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Vector3 initialShipPos;
    private Vector3 limitShipPos;
    // Start is called before the first frame update
    void Start()
    {

        initialShipPos = this.gameObject.transform.localPosition;
        limitShipPos = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y - 2f, this.gameObject.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.z, Mathf.PingPong(Time.time * 3, initialShipPos.y - limitShipPos.y) + limitShipPos.y, this.gameObject.transform.localPosition.z);
    }
}
