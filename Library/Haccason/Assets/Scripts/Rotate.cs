using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour {

    //画像のX値
    public int x = 0;

    //画像のY値
    public int y = 0;

    //画像のZ値
    public int z = 360;

    //ダーツが刺さったことを判定
    public static bool decide;

    //tweenの管理
    Tweener tweener;

    //回転させる速度
    public int rotateSecond = 8;

    // Start is called before the first frame update
    void Start () {
        decide = false;
        //回転開始
        StartCoroutine ("rotate");
    }

    // Update is called once per frame
    void Update () {
        //刺さった時
        if (decide) {
            StartCoroutine ("openWeb");
        }

    }

    IEnumerator rotate () {
        //無限ループ
        tweener = gameObject.GetComponent<RectTransform> ().DOLocalRotate (new Vector3 (x, y, z), rotateSecond, RotateMode.FastBeyond360)
            .SetLoops (-1);
        yield return null;
    }
    //レシピを開く
    IEnumerator openWeb () {
        //回転停止
        tweener.Kill ();
        yield return new WaitForSeconds (1);
        SceneManager.LoadScene ("WebViewScene");
    }
}