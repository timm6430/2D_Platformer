using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
       //buttonStart = GetComponent<Button>("Start");
    }

    public void OnButtonPressPlay()
    {
      Debug.Log("play pressed");
      SceneManager.LoadScene("IntroAreaScene1");
    }

    public void OnButtonPressHowToPlay()
    {
      Debug.Log("how to play pressed");
    }

    public void OnButtonPressQuit()
    {
      Debug.Log("quit pressed");
      Application.Quit();
    }
    
}
