using UnityEngine;

//�T�E���h���Ǘ�����N���X

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource audioSource;
    public AudioClip PickUpSound = default;
    public AudioClip BallDeleteSound = default;
    public AudioClip GimmickClearSound = default;
    public AudioClip FishCookSound = default;
    public AudioClip OpenSound = default;
    public AudioClip WalkSound = default;
    public AudioClip ClearEventSound = default;
    public AudioClip CancelSound = default;
    public AudioClip CleanSound = default;
    public AudioClip CookEggSound = default;
    public AudioClip EggCrackSound = default;
    public AudioClip SlimeMoveSound = default;
    public AudioClip OilApplySound = default;
    public AudioClip BBQSound = default;
    public AudioClip UnlockSound = default;
    public AudioClip FishingSound = default;
    public AudioClip DropBallSound = default;
    public AudioClip SwitchOnSound = default;

    private void Awake()
    {
        instance = this;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    //���炷�@�O�����炱���ɃA�N�Z�X
    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }


}
