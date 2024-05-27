using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErikAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stepClips = new AudioClip[5];
    private AudioSource audioPlayer;
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
        int randomIndex = Random.Range(0, 6);
        AudioClip chosenClip = stepClips[randomIndex];

        return chosenClip;
    }

    public void PlayRandomErikStep()
    {
        audioPlayer.PlayOneShot(getRandomStep());
    }
}
