using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WebViewScript : MonoBehaviour {

    WebViewObject webViewObject;

    string SearchURL = "https://recipe.rakuten.co.jp/search/";

    string[, ] urls = new string[3, 8] { { "肉じゃが", "とんかつ", "唐揚げ", "チキン南蛮", "魚の煮付け", "生姜焼き", "丼", "天ぷら" }, 
                                         { "ハンバーグ", "カレー", "グラタン", "パスタ", "シチュー", "オムライス", "ロールキャベツ", "ステーキ" },
                                         {"麻婆豆腐","回鍋肉","八宝菜","酢豚","餃子","青椒肉絲","エビチリ","棒棒鶏"} };

    // Start is called before the first frame update
    void Start () {

        // ジャンル番号を受け取る
        int Genre = ButtonScript.getterNumber ();

        // ここに料理名を渡してあげる
        string encodeStr = HttpUtility.UrlEncode (urls[Genre,ChangeSprite.urlName]);
        string formalUrl = SearchURL + encodeStr;

        webViewObject = (new GameObject ("WebViewObject")).AddComponent<WebViewObject> ();
        webViewObject.Init (
            ld: (msg) => Debug.Log (string.Format ("CallOnLoaded[{0}]", msg)),
            enableWKWebView : true);

        // iPhoneの外枠からのマージン設定
        webViewObject.SetMargins (0, 0, 0, 0);
        webViewObject.SetVisibility (true);
        // このURLのサイトを開く
        webViewObject.LoadURL (formalUrl);
    }

    // Update is called once per frame
    void Update () {

    }

    /*void OnGUI () {
        GUI.enabled = webViewObject.CanGoBack ();
        if (GUI.Button (new Rect (10, 10, 80, 80), "<")) {
            // ブラウザ：前のページへ
            //webViewObject.GoBack();
            SceneManager.LoadScene ("SelectScene");
        }
        GUI.enabled = true;

        GUI.enabled = webViewObject.CanGoForward ();
        if (GUI.Button (new Rect (100, 10, 80, 80), ">")) {
            // ブラウザ：次のページへ
            webViewObject.GoForward ();
        }
        GUI.enabled = true;
    }*/

}