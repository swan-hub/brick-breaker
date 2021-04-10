using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Button>().onClick.AddListener(Pause);
    }

    // Update is called once per frame
    public void Pause()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        //SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }
}
