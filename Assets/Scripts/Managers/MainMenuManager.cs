using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public float startDelay = 2f;
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.GetComponent<Animator>().SetBool("canFadeIn", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        StartCoroutine(StartTimer());
        print("starting game");
    }

    public void Tutorial()
    {
        //show tutorial
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartTimer()
    {
        while (startDelay > 0)
        {
            yield return new WaitForSeconds(startDelay);
            startDelay--;
        }
        fade.GetComponent<Animator>().SetBool("canFadeIn", false);
        SceneManager.LoadScene("Game");
        Debug.Log("fade");
    }
}
