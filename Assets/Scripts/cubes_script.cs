using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cubes_script : MonoBehaviour
{   
    private GameObject[] enemyObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<ScoreController>().AddScore(100);
        Destroy(this.gameObject);
    }

    
    void Update()
    {
		// Enemyというタグが付いているオブジェクトのデータを箱の中に入れる。
		enemyObjects = GameObject.FindGameObjectsWithTag("Player");

		// データの入った箱の数をコンソール画面に表示する。
		//print(enemyObjects.Length);

		// データの入った箱のデータが０に等しくなった時（Enemyというタグが付いているオブジェクトが全滅したとき）
		if(enemyObjects.Length == 0)
        {
            
			// ゲームクリアーシーンに遷移する。
			SceneManager.LoadScene("Clear");
		}

	}

}