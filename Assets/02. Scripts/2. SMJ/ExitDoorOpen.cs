using UnityEngine;

public class ExitDoorOpen : MonoBehaviour
{
    Animation animation;
    AudioSource audioSource;
    AudioClip clip;

    void Start()
    {
        animation = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
        clip = audioSource.clip;
    }

    public void IsUnlockedDoor()
    {
        audioSource.PlayOneShot(clip);
        animation.Play("ExitDoor_Open");
    }
}
