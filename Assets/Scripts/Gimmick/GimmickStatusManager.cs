using UnityEngine;

//�M�~�b�N�̃X�e�[�^�X�Ǘ��̃N���X
//Dictionary��GimmickStatus�N���X�ŗ񋓂������O��Key�ɂ���Value��bool�l�ɂ���΁A�����Ƃ��ȒP�ɏ������͂�

public class GimmickStatusManager : MonoBehaviour
{
    public bool tvDrawerGimmick;
    public bool donutBoxGimmick;
    public bool driverBoxGimmick;
    public bool iceBoxGimmick;
    public bool oilGetGimmick;
    public bool shogiGimmick;
    public bool postBoxGimmick;
    public bool doorToiletGimmick;
    public bool setWoodGimmick;
    public bool applyOilGimmick;
    public bool setMeetGimmick;
    public bool bbqGimmick;
    public bool cookEggGimmick;
    public bool batteryInputGimmick;
    public bool greenKeyGimmick;
    public bool redKeyGimmick;
    public bool setRodGimmick;
    public bool removeBoltGimmick;
    public bool switchGimmick;
    public bool setFood_MeetGimmick;
    public bool setFood_EggGimmick;
    public bool setFood_DonutGimmick;
    public bool setFood_FishGimmick;
    public bool setFishGimmick;
    public bool coolGimmick;
    public bool removeDirtGimmick;
    public bool photoSetGimmick;
    public bool pinkBallDeleteGimmick;
    public bool blueBallDeleteGimmick;
    public bool yellowBallDeleteGimmick;
    public bool redBallDeleteGimmick;
    public bool tvSwitchOnGimmick;
    public bool shogiLastSceneGimmick;

    string Hint = "";
    public int GimmickClearCount = 0;

    [SerializeField] Animator animator = default;

    public static GimmickStatusManager instance;

    private void Awake()
    {
        instance = this;
        tvDrawerGimmick = false;
        donutBoxGimmick = false;
        driverBoxGimmick = false;
        iceBoxGimmick = false;
        oilGetGimmick = false;
        shogiGimmick = false;
        postBoxGimmick = false;
        doorToiletGimmick = false;
        setWoodGimmick = false;
        applyOilGimmick = false;
        setMeetGimmick = false;
        bbqGimmick = false;
        cookEggGimmick = false;
        batteryInputGimmick = false;
        greenKeyGimmick = false;
        redKeyGimmick = false;
        setRodGimmick = false;
        removeBoltGimmick = false;
        switchGimmick = false;
        setFood_MeetGimmick = false;
        setFood_EggGimmick = false;
        setFood_DonutGimmick = false;
        setFood_FishGimmick = false;
        setFishGimmick = false;
        coolGimmick = false;
        removeDirtGimmick = false;
        photoSetGimmick = false;
        pinkBallDeleteGimmick = false;
        blueBallDeleteGimmick = false;
        yellowBallDeleteGimmick = false;
        redBallDeleteGimmick = false;
        tvSwitchOnGimmick = false;
        shogiLastSceneGimmick = false;
        Hint = "��q�̉�����ӂ�������̂�T����";
    }

    public void StatusChanger(GimmickStatus.Type type)
    {
        switch (type)
        {
            case GimmickStatus.Type.TVDrawerGimmick:
                tvDrawerGimmick = true;
                break;

            case GimmickStatus.Type.DonutBoxGimmick:
                donutBoxGimmick = true;
                break;

            case GimmickStatus.Type.DriverBoxGimmick:
                driverBoxGimmick = true;
                break;

            case GimmickStatus.Type.IceBoxGimmick:
                iceBoxGimmick = true;
                break;

            case GimmickStatus.Type.OilGetGimmick:
                oilGetGimmick = true;
                break;

            case GimmickStatus.Type.ShogiGimmick:
                shogiGimmick = true;
                break;

            case GimmickStatus.Type.PostBoxGimmick:
                postBoxGimmick = true;
                break;

            case GimmickStatus.Type.DoorToiletGimmick:
                doorToiletGimmick = true;
                break;

            case GimmickStatus.Type.SetWoodGimmcik:
                setWoodGimmick = true;
                break;

            case GimmickStatus.Type.ApplyOilGimmick:
                applyOilGimmick = true;
                break;

            case GimmickStatus.Type.SetMeetGimmick:
                setMeetGimmick = true;
                break;

            case GimmickStatus.Type.BBQGimmick:
                bbqGimmick = true;
                break;

            case GimmickStatus.Type.CookEggGimmick:
                cookEggGimmick = true;
                break;

            case GimmickStatus.Type.BatteryInputGimmick:
                batteryInputGimmick = true;
                break;

            case GimmickStatus.Type.GreenKeyGimmick:
                greenKeyGimmick = true;
                break;

            case GimmickStatus.Type.RedKeyGimmick:
                redKeyGimmick = true;
                break;

            case GimmickStatus.Type.SetRodGimmick:
                setRodGimmick = true;
                break;

            case GimmickStatus.Type.RemoveBoltGimmick:
                removeBoltGimmick = true;
                break;

            case GimmickStatus.Type.SwitchGimmick:
                switchGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_MeetGimmick:
                setFood_MeetGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_EggGimmick:
                setFood_EggGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_DonutGimmick:
                setFood_DonutGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_FishGimmick:
                setFood_FishGimmick = true;
                break;

            case GimmickStatus.Type.SetFishGimmick:
                setFishGimmick = true;
                break;

            case GimmickStatus.Type.CoolGimmick:
                coolGimmick = true;
                break;

            case GimmickStatus.Type.RemoveDirtGimmick:
                removeDirtGimmick = true;
                break;

            case GimmickStatus.Type.PhotoSetGimmick:
                photoSetGimmick = true;
                break;

            case GimmickStatus.Type.PinkBallDeleteGimmck:
                pinkBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.BlueBallDeleteGimmck:
                blueBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.YellowBallDeleteGimmck:
                yellowBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.RedBallDeleteGimmck:
                redBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.TvSwitchOnGimmick:
                tvSwitchOnGimmick = true;
                break;

            case GimmickStatus.Type.ShogiLastSceneGimmick:
                shogiLastSceneGimmick = true;
                break;
        }

        if (setFood_MeetGimmick == true)
        {
            animator.Play("Fishing_Ready");
        }
    }

    public bool StatusCheck(GimmickStatus.Type type)
    {
        switch (type)
        {
            case GimmickStatus.Type.TVDrawerGimmick:
                return tvDrawerGimmick;

            case GimmickStatus.Type.DonutBoxGimmick:
                return donutBoxGimmick;

            case GimmickStatus.Type.DriverBoxGimmick:
                return driverBoxGimmick;

            case GimmickStatus.Type.IceBoxGimmick:
                return iceBoxGimmick;

            case GimmickStatus.Type.OilGetGimmick:
                return oilGetGimmick;

            case GimmickStatus.Type.ShogiGimmick:
                return shogiGimmick;

            case GimmickStatus.Type.PostBoxGimmick:
                return postBoxGimmick;

            case GimmickStatus.Type.DoorToiletGimmick:
                return doorToiletGimmick;

            case GimmickStatus.Type.SetWoodGimmcik:
                return setWoodGimmick;

            case GimmickStatus.Type.ApplyOilGimmick:
                return applyOilGimmick;

            case GimmickStatus.Type.SetMeetGimmick:
                return setMeetGimmick;

            case GimmickStatus.Type.BBQGimmick:
                return bbqGimmick;

            case GimmickStatus.Type.CookEggGimmick:
                return cookEggGimmick;

            case GimmickStatus.Type.BatteryInputGimmick:
                return batteryInputGimmick;

            case GimmickStatus.Type.GreenKeyGimmick:
                return greenKeyGimmick;

            case GimmickStatus.Type.RedKeyGimmick:
                return redKeyGimmick;

            case GimmickStatus.Type.SetRodGimmick:
                return setRodGimmick;

            case GimmickStatus.Type.RemoveBoltGimmick:
                return removeBoltGimmick;

            case GimmickStatus.Type.SwitchGimmick:
                return switchGimmick;

            case GimmickStatus.Type.SetFood_MeetGimmick:
                return setFood_MeetGimmick;

            case GimmickStatus.Type.SetFood_EggGimmick:
                return setFood_EggGimmick;

            case GimmickStatus.Type.SetFood_DonutGimmick:
                return setFood_DonutGimmick;

            case GimmickStatus.Type.SetFood_FishGimmick:
                return setFood_FishGimmick;

            case GimmickStatus.Type.SetFishGimmick:
                return setFishGimmick;

            case GimmickStatus.Type.CoolGimmick:
                return coolGimmick;

            case GimmickStatus.Type.RemoveDirtGimmick:
                return removeDirtGimmick;

            case GimmickStatus.Type.PhotoSetGimmick:
                return photoSetGimmick;

            case GimmickStatus.Type.PinkBallDeleteGimmck:
                return pinkBallDeleteGimmick;

            case GimmickStatus.Type.BlueBallDeleteGimmck:
                return blueBallDeleteGimmick;

            case GimmickStatus.Type.YellowBallDeleteGimmck:
                return yellowBallDeleteGimmick;

            case GimmickStatus.Type.RedBallDeleteGimmck:
                return redBallDeleteGimmick;

            case GimmickStatus.Type.TvSwitchOnGimmick:
                return tvSwitchOnGimmick;

            case GimmickStatus.Type.ShogiLastSceneGimmick:
                return shogiLastSceneGimmick;


        }
        Debug.Log("�q�b�g����M�~�b�N�X�e�[�^�X�����݂��܂��� : " + type);
        return false;
    }


    //�q���g�̃��b�Z�[�W�̊Ǘ�
    int arraynumber = 1;
    public string currentHintSet()
    {
        if (removeDirtGimmick == false) return "��q�̉�����ӂ�������̂�T����";
        if (greenKeyGimmick == false) return "�ΐF�̌���T����";
        if (driverBoxGimmick == false)
        {
            string[] Hint = new string[2] { "�Q�����猩���鑋�Ɛ���@�̒��莆�̓e�g���X�Ɗ֌W�����肻����", "�{�I�̍����ɂ��锠�̓�̓e�g���X�Ɗ֌W���Ă���" };
            arraynumber++;
            return Hint[arraynumber % 2];
        }
        if (removeBoltGimmick == false) return "�h���C�o�[���g����Ƃ����T����";
        if (pinkBallDeleteGimmick == false) return "�{�I�̐A�ԁA���A�s���N�̒u������s�v�c�ȗ͂�������A�����A�C�e�����g���邩������Ȃ�";
        if (batteryInputGimmick == false) return "�����R���ɓd�r�������Ă���΃e���r�̓d��������ꂻ����";
        if (photoSetGimmick == false) return "�{�I�̎ʐ^���Ă̎ʐ^�͔j��Ă���B�j�ꂽ�ʐ^��T���Ă݂悤";
        if (tvSwitchOnGimmick == false) return "�e���r�̓d�������Ă݂悤";
        if (donutBoxGimmick == false) return "�e���r�̂��ꂼ��̃`�����l���͋G�߂Ɗ֌W�����肻����";
        if (shogiLastSceneGimmick == false) return "�����Ղ�������";
        if (shogiGimmick == false) return "�L�b�`���̔��ɂ���G���͏����̋�Ɗ֌W�����肻����";
        if (donutBoxGimmick == false) return "�e���r�̂��ꂼ��̃`�����l���͋G�߂Ɗ֌W�����肻����";
        if (postBoxGimmick == false) return "L���^�̃e�[�u���ɂ���4�̊D�F�̃v���[�g�͂����C��ɂ��锠�Ɗ֌W�����肻����";
        if (doorToiletGimmick == false) return "�h�A�m�u�̂Ȃ����Ƀh�A�m�u�����t���Ă݂悤";
        if (iceBoxGimmick == false) return "�|�����ƃg���b�N�A�[�g�̊G��͊֌W�����肻����";
        if (coolGimmick == false) return "���C�^�[������΁A�x�����_�ňꕞ�ł�������";
        if (cookEggGimmick == false) return "���ƃt���C�p��������΁A�ڋʏĂ�����ꂻ����";
        if (setFood_EggGimmick == false) return "4�l�|���e�[�u���̃����`�����}�b�g�̊G���ɒ��ڂ��悤";
        if (tvDrawerGimmick == false) return "�e���r���4�̐����͖{�I�̖{�̐��Ɗ֌W���Ă�����";
        if (setWoodGimmick == false) return "�x�����_�ɂ���d�̓o�[�x�L���[�O�����̉Ύ�ɂł�������";
        if (oilGetGimmick == false) return "L���^�e�[�u���̃{�^���͗①�ɂ̒��̊ʂƊ֌W�����肻����";
        if (applyOilGimmick == false) return "�R���Ɖ΂�������̂�����ΐd�ɉ΂����ꂻ����";
        if (setMeetGimmick == false) return "�o�[�x�L���[�Ƃ����΂������~������Ȃ�";
        if (bbqGimmick == false) return "�o�[�x�L���[������ɂ͐H�ו���Ύ킪�K�v��";
        if (setFood_MeetGimmick == false) return "4�l�|���e�[�u���̃����`�����}�b�g�̊G���ɒ��ڂ��悤";
        if (setFishGimmick == false) return "���̃X�^���h�ɒނ�Ƃ��Z�b�g���Ă݂悤";
        if (redKeyGimmick == false) return "�ΐF�̌���T����";

        return "�q���g�͂���܂���";
    }
    


}
