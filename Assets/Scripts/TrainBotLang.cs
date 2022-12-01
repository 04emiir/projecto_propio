using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainBotLang : MonoBehaviour
{
    [TextArea] public string espText;
    [TextArea] public string engText;
    public TextMeshPro trainBotText;
    // Start is called before the first frame update
    void Start()
    {
        switch (MenuController.selectedLang) {
            case "eng":
                trainBotText.text = engText;
                break;
            case "esp":
                trainBotText.text = espText;
                break;
            default:
                Debug.Log("error on lang");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
