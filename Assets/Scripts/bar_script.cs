using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_script : MonoBehaviour
{
    GameObject wall1;

    GameObject wall2;

    // Start is called before the first frame update
    void Start()
    {
        wall1 = GameObject.Find("wall (1)");
        wall2 = GameObject.Find("wall (2)");

    }

    // Update is called once per frame
    void FixedUpdate()
    {   

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
            if(pos.y < 4)
            {
                pos.y = -3.94f;
                transform.position = pos;
            }
        }
        if(transform.position.x > wall1.transform.position.x)
        {
            transform.position = new Vector3(wall1.transform.position.x - 1 ,-3.94f,-15.08f);
        }
        if(transform.position.x < wall2.transform.position.x)
        {
            transform.position = new Vector3(wall2.transform.position.x + 1 ,-3.94f,-15.08f);
        }
    }
}
