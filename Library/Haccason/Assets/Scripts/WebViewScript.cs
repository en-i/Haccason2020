using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Web;

public class WebViewScript : MonoBehaviour
{

    WebViewObject webViewObject;

    string SearchURL = "https://recipe.rakuten.co.jp/search/";

    // Start is called before the first frame update
    void Start()
    {

        // ジャンル番号を受け取る
        int Genre = ButtonScript.getterNumber();

        switch (Genre)
        {
            case 0:
            Debug.Log("0でした");
            break;

            case 1:
            Debug.Log("1でした");
            break;

            case 2:
            Debug.Log("2でした");
            break;

            default:
            Debug.Log("どれでもなかった");
            break;
        }

        // ここに料理名を渡してあげる
        string encodeStr = HttpUtility.UrlEncode("ラーメン");
        string formalUrl = SearchURL + encodeStr;

        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
            ld: (msg) => Debug.Log(string.Format("CallOnLoaded[{0}]", msg)),
            enableWKWebView: true);

// #if UNITY_EDITOR_OSX || UNITpY_STANDALONE_OSX
//         webViewObject.bitmaRefreshCycle = 1;
// #endif

        // iPhoneの外枠からのマージン設定
        webViewObject.SetMargins(0, 0, 0, 0);
        webViewObject.SetVisibility(true);
        // このURLのサイトを開く
        webViewObject.LoadURL(formalUrl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.enabled = webViewObject.CanGoBack();
        if (GUI.Button(new Rect(10, 10, 80, 80), "<"))
        {
            // ブラウザ：前のページへ
            //webViewObject.GoBack();
            SceneManager.LoadScene("SelectScene");
        }
        GUI.enabled = true;

        GUI.enabled = webViewObject.CanGoForward();
        if (GUI.Button(new Rect(100, 10, 80, 80), ">"))
        {
            // ブラウザ：次のページへ
            webViewObject.GoForward();
        }
        GUI.enabled = true;
    }

}
