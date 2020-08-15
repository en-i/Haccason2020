using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    // 和洋中のジャンルを管理（和＝0，洋＝1，中＝2）
    public static int CuisineGenre;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    // 和風選択時
    public void JPButtonClicked () {
        ChangeScene (0);
    }

    // 洋風選択時
    public void WEButtonClicked () {
        ChangeScene (1);
    }

    // 中華選択時
    public void CHButtonClicked () {
        ChangeScene (2);
    }

    // 料理ジャンル代入 ＆ シーン切り替え
    private void ChangeScene (int CuisineNumber) {
        CuisineGenre = CuisineNumber;
        SceneManager.LoadScene ("DartsScene");
    }

    // ゲッタの作成
    public static int getterNumber () {
        return CuisineGenre;
    }

}