using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereXController : MonoBehaviour
{
    GameObject sphere1;
    GameObject sphere2;
    bool isCalledOnce = false;
    bool isCalledOnce1 = false;
    public float speed1 = 0;
    public float speed2 = 0;
    private AudioSource sound01;
    // Start is called before the first frame update
    void Start()
    {
        sphere1 = GameObject.Find("Sphere 1");
        sphere2 = GameObject.Find("Sphere 2");
        sound01 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sphere1 == null)
        {
            return;
        }
        if(sphere1.transform.position == new Vector3(0,-1.5f,-15))
        {
            isCalledOnce = true;
        }

        Rigidbody rigidbody1 = sphere1.GetComponent<Rigidbody>();
        speed1 = rigidbody1.velocity.magnitude;
        if(Input.GetMouseButtonDown(0))
        {
            if(isCalledOnce)
            {
                rigidbody1.AddForce(new Vector3(100f,-100f,0));
            }
            
            isCalledOnce = false;
        }
        if(sphere1.transform.position.y < -9)
        {
            sphere2.transform.position = new Vector3(0,-1.5f,-15);
            Destroy(sphere1);
        }
        if(speed1 > 8f)
        {
            rigidbody1.velocity *= 0.8f; 
        }

        //　ボールが水平（垂直）移動になったときの処理
        Vector3 velocityNormalized1 = rigidbody1.velocity.normalized;

        float limitVerticalDeg = 10f;   // 垂直方向は 90 ± 10 度、270 ± 10 度の範囲の角度は近いほうに寄せる。
        float limitHorizontalDeg = 45f; // 水平方向は 0 ± 45 度、 180 ± 45 度の範囲の角度は近いほうに寄せる。
        if (velocityNormalized1.x >= 0f)
        {
            velocityNormalized1.x = Mathf.Clamp(velocityNormalized1.x, Mathf.Cos(Mathf.Deg2Rad * (90 - limitVerticalDeg)), Mathf.Cos(Mathf.Deg2Rad * (0 + limitHorizontalDeg)));
        }
        else
        {
            velocityNormalized1.x = Mathf.Clamp(velocityNormalized1.x, Mathf.Cos(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Cos(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        if (velocityNormalized1.y >= 0f)
        {
            velocityNormalized1.y = Mathf.Clamp(velocityNormalized1.y, Mathf.Sin(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Sin(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        else
        {
            velocityNormalized1.y = Mathf.Clamp(velocityNormalized1.y, Mathf.Sin(Mathf.Deg2Rad * (270 - limitVerticalDeg)), Mathf.Sin(Mathf.Deg2Rad * (180 + limitHorizontalDeg)));
        }

        /*Rigidbody rigidbody2 = sphere2.GetComponent<Rigidbody>();
        speed2 = rigidbody2.velocity.magnitude;
        if(Input.GetMouseButtonDown(0))
        {
            if(isCalledOnce)
            {
                rigidbody2.AddForce(new Vector3(150f,-150f,0));
            }
            
            isCalledOnce = false;
        }
        if(sphere2.transform.position.y < -9)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(speed2 > 10f)
        {
            rigidbody2.velocity *= 0.8f; 
        }

        //　ボールが水平（垂直）移動になったときの処理
        Vector3 velocityNormalized2 = rigidbody2.velocity.normalized;

        if (velocityNormalized2.x >= 0f)
        {
            velocityNormalized2.x = Mathf.Clamp(velocityNormalized2.x, Mathf.Cos(Mathf.Deg2Rad * (90 - limitVerticalDeg)), Mathf.Cos(Mathf.Deg2Rad * (0 + limitHorizontalDeg)));
        }
        else
        {
            velocityNormalized2.x = Mathf.Clamp(velocityNormalized2.x, Mathf.Cos(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Cos(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        if (velocityNormalized2.y >= 0f)
        {
            velocityNormalized2.y = Mathf.Clamp(velocityNormalized2.y, Mathf.Sin(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Sin(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        else
        {
            velocityNormalized2.y = Mathf.Clamp(velocityNormalized2.y, Mathf.Sin(Mathf.Deg2Rad * (270 - limitVerticalDeg)), Mathf.Sin(Mathf.Deg2Rad * (180 + limitHorizontalDeg)));
        }*/
    }

    /*void Sphere1()
    {
        Rigidbody rigidbody1 = sphere1.GetComponent<Rigidbody>();
        speed1 = rigidbody1.velocity.magnitude;
        if(Input.GetMouseButtonDown(0))
        {
            if(isCalledOnce)
            {
                rigidbody1.AddForce(new Vector3(150f,-150f,0));
            }
            
            isCalledOnce = false;
        }
        if(sphere1.transform.position.y < -9)
        {
            Destroy(gameObject);
            sphere2.transform.position = new Vector3(0,0,-15);
            isCalledOnce = true;
        }
        if(speed1 > 10f)
        {
            rigidbody1.velocity *= 0.8f; 
        }

        //　ボールが水平（垂直）移動になったときの処理
        Vector3 velocityNormalized = rigidbody1.velocity.normalized;

        float limitVerticalDeg = 10f;   // 垂直方向は 90 ± 10 度、270 ± 10 度の範囲の角度は近いほうに寄せる。
        float limitHorizontalDeg = 45f; // 水平方向は 0 ± 45 度、 180 ± 45 度の範囲の角度は近いほうに寄せる。
        if (velocityNormalized.x >= 0f)
        {
            velocityNormalized.x = Mathf.Clamp(velocityNormalized.x, Mathf.Cos(Mathf.Deg2Rad * (90 - limitVerticalDeg)), Mathf.Cos(Mathf.Deg2Rad * (0 + limitHorizontalDeg)));
        }
        else
        {
            velocityNormalized.x = Mathf.Clamp(velocityNormalized.x, Mathf.Cos(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Cos(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        if (velocityNormalized.y >= 0f)
        {
            velocityNormalized.y = Mathf.Clamp(velocityNormalized.y, Mathf.Sin(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Sin(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        else
        {
            velocityNormalized.y = Mathf.Clamp(velocityNormalized.y, Mathf.Sin(Mathf.Deg2Rad * (270 - limitVerticalDeg)), Mathf.Sin(Mathf.Deg2Rad * (180 + limitHorizontalDeg)));
        }
    }*/

    void Update()
    {
        if(sphere2.transform.position == new Vector3(0,-1.5f,-15))
        {
            isCalledOnce1 = true;
        }
        Rigidbody rigidbody2 = sphere2.GetComponent<Rigidbody>();
        speed2 = rigidbody2.velocity.magnitude;
        if(Input.GetMouseButtonDown(0))
        {
            if(isCalledOnce1)
            {
                rigidbody2.AddForce(new Vector3(150f,-150f,0));
            } 
            isCalledOnce1 = false;
        }
        if(sphere2.transform.position.y < -9)
        {
            FindObjectOfType<ScoreController>().ResetScore();
            SceneManager.LoadScene("GameOver");
        }

        if(speed2 > 8f)
        {
            rigidbody2.velocity *= 0.8f; 
        }

        //　ボールが水平（垂直）移動になったときの処理
        Vector3 velocityNormalized = rigidbody2.velocity.normalized;

        float limitVerticalDeg = 10f;   // 垂直方向は 90 ± 10 度、270 ± 10 度の範囲の角度は近いほうに寄せる。
        float limitHorizontalDeg = 45f; // 水平方向は 0 ± 45 度、 180 ± 45 度の範囲の角度は近いほうに寄せる。
        if (velocityNormalized.x >= 0f)
        {
            velocityNormalized.x = Mathf.Clamp(velocityNormalized.x, Mathf.Cos(Mathf.Deg2Rad * (90 - limitVerticalDeg)), Mathf.Cos(Mathf.Deg2Rad * (0 + limitHorizontalDeg)));
        }
        else
        {
            velocityNormalized.x = Mathf.Clamp(velocityNormalized.x, Mathf.Cos(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Cos(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        if (velocityNormalized.y >= 0f)
        {
            velocityNormalized.y = Mathf.Clamp(velocityNormalized.y, Mathf.Sin(Mathf.Deg2Rad * (180 - limitHorizontalDeg)), Mathf.Sin(Mathf.Deg2Rad * (90 + limitVerticalDeg)));
        }
        else
        {
            velocityNormalized.y = Mathf.Clamp(velocityNormalized.y, Mathf.Sin(Mathf.Deg2Rad * (270 - limitVerticalDeg)), Mathf.Sin(Mathf.Deg2Rad * (180 + limitHorizontalDeg)));
        }
    }
    public void OnCollisionEnter (Collision collision)
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        if(collision.gameObject == GameObject.FindWithTag("wall"))
        {   
            rigidbody.velocity *= 1.15f; 
            
            if(collision.gameObject == GameObject.Find("wall (1)"))
            {
                rigidbody.AddForce(new Vector3(-50f,-20f,0));
            }
            if(collision.gameObject == GameObject.Find("wall (2)"))
            {
                rigidbody.AddForce(new Vector3(50f,-20f,0));
            }
        }
            sound01.PlayOneShot(sound01.clip);
    }
    
}
