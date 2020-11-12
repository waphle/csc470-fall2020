using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenGameManager : MonoBehaviour
{
    GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ShowInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void GoBackPage()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}