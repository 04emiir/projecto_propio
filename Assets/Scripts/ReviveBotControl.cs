using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviveBotControl : MonoBehaviour
{
    private string[] engText = { "INACTIVE... (J)", "NEW SPAWN ON"};
    private string[] espText = { "INACTIVO... (J)", "RESPAWN ACTIVADO"};

    public TextMeshPro botText;
    public Vector3 newSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if (MenuController.selectedLang == "eng") {
            botText.text = engText[0];
        }

        if (MenuController.selectedLang == "esp") {
            botText.text = espText[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.J)) {
            GameController.currentSpawnPoint = newSpawn;
            if (MenuController.selectedLang == "eng") {
                botText.text = engText[1];
            }

            if (MenuController.selectedLang == "esp") {
                botText.text = espText[1];
            }

        }
    }
}
