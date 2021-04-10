using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStableAspect : MonoBehaviour
{
//最初に作った画面のwidth
    public float defaultWidth = 1080f;

    //最初に作った画面のheight
    public float defaultHeight = 1920f;

    void Awake()
    {
        //camera.mainを変数に格納
        Camera mainCamera = Camera.main;

        //最初に作った画面のアスペクト比 
        float defaultAspect = defaultWidth / defaultHeight;

        //実際の画面のアスペクト比
        float actualAspect = (float)Screen.width / (float)Screen.height;

        //実機とunity画面の比率
        float ratio = actualAspect / defaultAspect;

        //サイズ調整
        mainCamera.orthographicSize /= ratio;
    }
}