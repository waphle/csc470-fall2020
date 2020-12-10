using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSelectionManager : MonoBehaviour
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
        SceneManager.LoadScene("GameScene");
    }

    public void ShowInstructions()
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    public void GoBackPage()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            SceneManager.LoadScene("CompletionScreen");
        }
    }
}