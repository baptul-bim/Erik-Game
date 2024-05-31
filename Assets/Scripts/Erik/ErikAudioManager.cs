using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErikAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stepClips = new AudioClip[5];
    private AudioSource audioPlayer;
    private AudioClip recentClip;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private AudioClip getRandomStep()
    {
        int randomIndex = Random.Range(0, stepClips.Length -1);
        AudioClip chosenClip = stepClips[randomIndex];
        if (chosenClip == recentClip)
        {
            return getRandomStep();
        }
        else
        {
            recentClip = chosenClip;
            return chosenClip;

        }
    }

    public void PlayRandomErikStep()
    {
        audioPlayer.PlayOneShot(getRandomStep());
    }
}
