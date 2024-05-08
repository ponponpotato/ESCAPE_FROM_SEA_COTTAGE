using TMPro;
using UnityEngine;

//�A�C�e���g��p�l������

public class ZoomPanel : MonoBehaviour
{
    // zoomPanel�̕\��
    //���C���J�����ȊO�ł������悤�ɂ���

    [SerializeField] GameObject zoomPanel;
    [SerializeField] Transform ZoomObjParent;
    [SerializeField] TextMeshProUGUI UIText;
    Canvas canvas;
    GameObject ZoomedItem;
    Transform RectTransform;
    public static ZoomPanel instance;
    public Item SelectedItem;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        RectTransform = ZoomObjParent.GetComponent<RectTransform>();
        UIText.text = "";
        HideZoomPanel();
    }

    void ShowItem()
    {
        //�I�𒆂̃A�C�e����\������
        //�\������=�f�[�^�x�[�X���琶������
        //prefab�𐶐�����Ƃ���Instantiate�ł��炩���ߐ������Ă���g�p����B�ϐ��ɓ����Ƃ��ɂ��ł�Instantiate���Ă����Ȃ��ƈӖ����Ȃ�
        if(ZoomedItem != null)
        {
            Destroy(ZoomedItem);
        }
        SelectedItem = ItemBox.instance.GetSelectedItem();
        ZoomedItem = Instantiate(ItemDataBase.instance.CreateZoomItem(SelectedItem.type));
        ZoomedItem.transform.SetParent(ZoomObjParent,false); //false�ɂ��ă��[�J�����W�̔{���ɂ���
        RectTransform.localRotation = Quaternion.Euler(0, 0, 0);
        TextSetter(SelectedItem);
    }

    //�L�����o�X�̃J���������ݎg�p���̃J�����ɐ؂�ւ�
    public void SetRenderCamera(Camera camera)
    {
        canvas.worldCamera = camera;
    }

    //�A�C�e���g��p�l���\��
    public void OnClickZoom()
    {
        if (ItemBox.instance.GetSelectedItem() == null) return;
        zoomPanel.SetActive(true);
        ShowItem();
    }

    //�A�C�e���g��p�l����\��
    public void HideZoomPanel()
    {
        zoomPanel.SetActive(false);
    }

    //�A�C�e���̖��O�e�L�X�g�̐ݒ�
    void TextSetter(Item item)
    {
        UIText.text = item.ItemName;
    }
}
