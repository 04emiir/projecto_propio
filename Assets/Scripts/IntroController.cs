using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public AudioSource soundEffect;
    public TextMeshProUGUI introText;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("loadGame");
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (introText.color.a <= 0.9f)
            introText.color = new Color(1f, 1f, 1f, introText.color.a + (0.5f * Time.deltaTime));
        else
            StartCoroutine("LoadGame");
    }

    IEnumerator LoadGame() { 
        yield return new WaitForSeconds(3f);
=======
        if (introText.color.a != 1f)
            introText.color = new Color(1f, 1f, 1f, introText.color.a + (0.5f * Time.deltaTime));
        else
            soundEffect.Play();
            StartCoroutine("loadGame");
    }

    IEnumerator loadGame() { 
        yield return new WaitForSeconds(2f);
>>>>>>> f00ade70ef5ba4871d14d57e8e8bc49b76750823
        SceneManager.LoadScene("MenuScene");
    }

}
