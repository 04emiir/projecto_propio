using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.Instantiate(("Player"), new Vector3(0, 0, 0), Quaternion.identity, 0);
        } else {
            PhotonNetwork.Instantiate(("NeoPlayer"), new Vector3(0, 0, 0), Quaternion.identity, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
