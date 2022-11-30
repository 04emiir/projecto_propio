using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotControl : MonoBehaviour
{
    public TextMeshPro botText;
    public Vector3 newSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.J)) {
            GameController.currentSpawnPoint = newSpawn;
            botText.text = "NEW SPAWN ON";
            
        }
    }
}
