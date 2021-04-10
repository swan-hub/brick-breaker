using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar1_script : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        GameObject wall1 = GameObject.Find("wall (1)");
        GameObject wall2 = GameObject.Find("wall (2)");

        //PC用
        /*if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(transform.right * -0.15f);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * 0.15f);
        }*/
        //スマホ用
        if(Input.GetMouseButton(0))
        { 
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -15.08f;
            pos.y = 4.5f;
            transform.position = pos;
        }
        if(transform.position.x > wall1.transform.position.x)
        {
            transform.position = new Vector3(wall1.transform.position.x - 1 ,4.5f,-15.08f);
        }
        if(transform.position.x < wall2.transform.position.x)
        {
            transform.position = new Vector3(wall2.transform.position.x + 1 ,4.5f,-15.08f);
        }
    }
}
