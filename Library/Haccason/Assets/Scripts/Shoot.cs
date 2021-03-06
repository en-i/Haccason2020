﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    //ダーツのスピードを調節する値
    public int shotZ;

    //ダーツのz値の取得
    float dartZ;

    public Text dishes;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //タッチされた時
        if (Input.GetMouseButtonDown (0)) {
            //タッチされた座標を判定
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Vector3 world = ray.direction;
            //発射
            arow (world.normalized * shotZ);
        } else if (Input.touchCount > 0) {
            // タッチ情報の取得
            Touch touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                Vector3 world = ray.direction;
                //発射
                arow (world.normalized * shotZ);
            }
        }
        //ダーツのz値を常に取得 
        dartZ = GetComponent<Transform> ().transform.position.z;
        //ダーツが外れた時
        if (dartZ > 100) {
            //再度開始
            SceneManager.LoadScene ("DartsScene");
        }

        //料理名の表示
        if (ChangeSprite.getName) {
            dishes.text = WebViewScript.urls[ButtonScript.CuisineGenre, ChangeSprite.urlName];
        }
    }

    //ダーツが当たった時
    void OnCollisionEnter (Collision other) {
        //刺さる
        GetComponent<Rigidbody> ().isKinematic = true;
    }

    //射出
    public void arow (Vector3 ar) {
        GetComponent<Rigidbody> ().AddForce (ar);
    }
}