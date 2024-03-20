using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;

//�L���N���X

public class AD_Hint_Show : MonoBehaviour
{

    //�L�����j�b�gID _�e�X�g���̓e�X�g�p�̂��̂��g�p
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


    //Mobile Ads SDK �̏�����
    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
        });
    }

    //�����[�h�L���̓ǂݍ��� 
    public void loadRewardedAd()
    {
        // �����[�h�L���������̏ꍇ�A������������
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // �L���̃��N�G�X�g
        var adRequest = new AdRequest();

        // ���N�G�X�g�̑��M
        RewardedAd.Load(adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
              
              if (error != null || ad == null)
                {
                    Debug.LogError("�����[�h�L���ǂݍ��ݎ��s\n" + "�G���[ : " + error);
                    return;
                }

                Debug.Log("�����[�h�L���ǂݍ��ݓ��e: " + ad.GetResponseInfo());

                rewardedAd = ad;
                adBehaviorFunction();

            });
    }


    //�L���̏����ɉ����Ĕ�������֐��̒�`
    private void adBehaviorFunction()
    {

        // �L�������܂��\������A���[�U�[�ɕ���ꂽ�Ƃ�
        rewardedAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("�����[�h�L������ꂽ");

            // �����[�h�̒�
            showRewardedAd();
        };

        // �L���̕\�������܂������Ȃ������Ƃ�
        rewardedAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("�L���\�����܂��������Ȃ�����\n" + "�G���[ : " + error);

            // �L���~�X�����ꍇ�ł������[�h���
            showRewardedAd();
        };

        showRewardedAd();
  
    }

    //�����[�h�L����\��
    public void showRewardedAd()
    {

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                // ���[�U�ɑ΂��郊���[�h�̏���
                Invoke("giveReward", 1.0f);
                //giveReward();
            });
        }
    }

    //��V�̏����@Hint�����[�U�ɒ񋟂���
    void giveReward()
    {
        string hintText = "";
        hintText = GimmickStatusManager.instance.currentHintSet();
        hintPanel.SetActive(true);
        hint.SetText(hintText);
    }

}
