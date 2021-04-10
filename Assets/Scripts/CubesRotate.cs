using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CubesRotate : MonoBehaviour
{
    private GameObject[] enemyObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<ScoreController>().AddScore(100);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        // Enemyというタグが付いているオブジェクトのデータを箱の中に入れる。
		enemyObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in enemyObjects)
        {
            //transform.Rotate(0.01f,0.01f,0.01f);
        }

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
