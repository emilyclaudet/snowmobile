using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("Main");
        Debug.Log("Game is starting");
    }


}
