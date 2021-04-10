using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sphere_script : MonoBehaviour
{
    bool isCalledOnce = true;
    public float speed = 0;
    GameObject score;
    GameObject sphere;

    GameObject sphere1;
    GameObject text1;
    private AudioSource sound01;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("score");
        sphere = GameObject.Find("Sphere");
        sphere1 = GameObject.Find("Sphere 1");
        text1 = GameObject.Find("Text1");
        sound01 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected  void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        speed = rigidbody.velocity.magnitude;
        if(Input.GetMouseButtonDown(0))
        {
            if(isCalledOnce)
            {
                rigidbody.AddForce(new Vector3(150f,-150f,0));
                text1.SetActive(false);
            }
            
            isCalledOnce = false;
        }
        if(sphere.transform.position.y < -9)
        {
            Destroy(gameObject);
            sphere1.transform.position = new Vector3(0,-1.5f,-15);
            isCalledOnce = true;
        }
        if(speed > 8f)
        {
            rigidbody.velocity *= 0.8f; 
        }

        //　ボールが水平（垂直）移動になったときの処理
        Vector3 velocityNormalized = rigidbody.velocity.normalized;

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
        GameObject sphere = GameObject.Find("Sphere");
        Rigidbody rigidbody = sphere.GetComponent<Rigidbody>();
        if(collision.gameObject == GameObject.FindWithTag("wall"))
        {   
            speed *= 1.25f; 
        }
            
        if(collision.gameObject == GameObject.Find("wall (1)"))
        {
            rigidbody.AddForce(new Vector3(-50f,-20f,0));
        }
        if(collision.gameObject == GameObject.Find("wall (2)"))
        {
            rigidbody.AddForce(new Vector3(50f,-20f,0));
        }
        sound01.PlayOneShot(sound01.clip);

        

        

        /*if(collision.gameObject == GameObject.FindWithTag("wall"))
        {   
            GameObject sphere = GameObject.Find("Sphere");
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity *= -1.25f; 
        }*/
    } 
    
}
