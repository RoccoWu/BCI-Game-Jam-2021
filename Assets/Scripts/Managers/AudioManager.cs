using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioManager instance;
    public AudioClip mainTheme, mainmenuTheme;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainmenuFadeIn();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            mainthemeFadeIn();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void mainmenuFadeIn()
    {
        gameObject.GetComponent<AudioSource>().clip = mainmenuTheme;
        gameObject.GetComponent<Animator>().SetBool("canFade", true);
    }

    private void mainmenuFadeOut()
    {
        gameObject.GetComponent<AudioSource>().clip = mainmenuTheme;
        gameObject.GetComponent<Animator>().SetBool("canFade", false);
    }
    private void mainthemeFadeIn()
    {
        gameObject.GetComponent<AudioSource>().clip = mainTheme;
        gameObject.GetComponent<Animator>().SetBool("canFade", true);
    }

    private void mainthemeFadeOut()
    {
        gameObject.GetComponent<AudioSource>().clip = mainTheme;
        gameObject.GetComponent<Animator>().SetBool("canFade", false);
    }
}
