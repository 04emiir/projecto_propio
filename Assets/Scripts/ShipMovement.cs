using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Vector3 initialShipPos;
    private Vector3 limitShipPos;
    public SpriteRenderer nave;
    // Start is called before the first frame update
    void Start()
    {

        initialShipPos = nave.transform.localPosition;
        limitShipPos = new Vector3(nave.transform.localPosition.x, nave.transform.localPosition.y - 2f, nave.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        nave.transform.localPosition = new Vector3(nave.transform.localPosition.z, Mathf.PingPong(Time.time * 3, initialShipPos.y - limitShipPos.y) + limitShipPos.y, nave.transform.localPosition.z);
    }
}
