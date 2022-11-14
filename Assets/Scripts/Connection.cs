using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connection : MonoBehaviourPunCallbacks // poner esto  para utilizar los metodos de photon
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Conexion con el servidor
        PhotonNetwork.AutomaticallySyncScene = true;
        
    }
    
    
    override
    public void OnConnectedToMaster()
    {
        print("Conectado al servidor"); // Comprobando que estoy conectado
    }
    
    public void ButtonConnect() // metodo que acabamos de crear
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 6; // maximo 6 jugadores en la sala
    

        PhotonNetwork.JoinOrCreateRoom("Room01", options, TypedLobby.Default);
    }

    override
    public void OnJoinedRoom()
    {
        Debug.Log("Conectado a la sala" + PhotonNetwork.CurrentRoom.Name);
    }
        
    

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            PhotonNetwork.LoadLevel(1);
            Debug.Log("hola");
            Destroy(this); // esta en el update y lo revisa de forma continua por lo que lo destruimos
        }    
    }
}
