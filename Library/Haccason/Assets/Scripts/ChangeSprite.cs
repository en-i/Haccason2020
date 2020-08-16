using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour {

    //3種類のルーレット
    public Sprite[] sprites;

    //ルーレットの部品
    private Image image;

    //和、洋、中を判定
    int spriteNumber = ButtonScript.CuisineGenre;

    //当たった料理を判定
    public static int urlName;

    // Start is called before the first frame update
    void Start () {
        //imageの取得、Spriteの変更
        image = gameObject.GetComponent<Image> ();
        image.sprite = sprites[spriteNumber];
    }

    // Update is called once per frame
    void Update () {

    }

    //ダーツが当たった時
    void OnCollisionEnter (Collision other) {
        //当たったことを通知
        Rotate.decide = true;
        //オブジェクト名から当たった部分を判定
        urlName = int.Parse (image.transform.name);
    }
}