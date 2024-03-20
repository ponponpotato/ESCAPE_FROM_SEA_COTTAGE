using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;

//広告クラス

public class AD_Hint_Show : MonoBehaviour
{

    //広告ユニットID _テスト時はテスト用のものを使用
    #if UNITY_ANDROID
        private string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
          private string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
          private string adUnitId = "unused";
#endif

    private RewardedAd rewardedAd;

    [SerializeField] GameObject hintPanel = default;
    [SerializeField] TextMeshProUGUI hint = default;


    //Mobile Ads SDK の初期化
    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
        });
    }

    //リワード広告の読み込み 
    public void loadRewardedAd()
    {
        // リワード広告が既存の場合、初期化させる
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // 広告のリクエスト
        var adRequest = new AdRequest();

        // リクエストの送信
        RewardedAd.Load(adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
              
              if (error != null || ad == null)
                {
                    Debug.LogError("リワード広告読み込み失敗\n" + "エラー : " + error);
                    return;
                }

                Debug.Log("リワード広告読み込み内容: " + ad.GetResponseInfo());

                rewardedAd = ad;
                adBehaviorFunction();

            });
    }


    //広告の処理に応じて発動する関数の定義
    private void adBehaviorFunction()
    {

        // 広告がうまく表示され、ユーザーに閉じられたとき
        rewardedAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("リワード広告閉じられた");

            // リワードの提供
            showRewardedAd();
        };

        // 広告の表示がうまくいかなかったとき
        rewardedAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("広告表示うまくいいかなかった\n" + "エラー : " + error);

            // 広告ミスった場合でもリワードを提供
            showRewardedAd();
        };

        showRewardedAd();
  
    }

    //リワード広告を表示
    public void showRewardedAd()
    {

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                // ユーザに対するリワードの処理
                Invoke("giveReward", 1.0f);
                //giveReward();
            });
        }
    }

    //報酬の処理　Hintをユーザに提供する
    void giveReward()
    {
        string hintText = "";
        hintText = GimmickStatusManager.instance.currentHintSet();
        hintPanel.SetActive(true);
        hint.SetText(hintText);
    }

}
