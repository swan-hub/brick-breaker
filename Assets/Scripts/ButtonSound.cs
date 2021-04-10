using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour
{
		
	private AudioSource sound02;

	void Start () 
    {
		//AudioSourceコンポーネントを取得し、変数に格納
		sound02 = GetComponent<AudioSource>();
	}
	
	public void Onclick () 
    {
		sound02.PlayOneShot(sound02.clip);
	}
}