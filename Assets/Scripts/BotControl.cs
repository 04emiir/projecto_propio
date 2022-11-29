using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotControl : MonoBehaviour
{
    public TextMeshPro botText;
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
            Debug.Log("new spawn");
            GameController.currentSpawnPoint = new Vector3(60f, 46.9f, 0f);
            botText.text = "NEW SPAWN ON";
            
        }
    }
}
