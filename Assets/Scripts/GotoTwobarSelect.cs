using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GotoTwobarSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }
    
    void StartGame()
    {
        SceneManager.LoadScene("TwobarSelect");
    }
}
