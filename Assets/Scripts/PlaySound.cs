using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
		
	private AudioSource sound01;

	void Start () {
		//AudioSourceコンポーネントを取得し、変数に格納
		sound01 = GetComponent<AudioSource>();
	}
	
	void OnCollisionEnter (Collision collision) 
    {
        if(collision.gameObject == GameObject.FindWithTag("Player"))
        {
            sound01.PlayOneShot(sound01.clip);
        }
	
	}
}