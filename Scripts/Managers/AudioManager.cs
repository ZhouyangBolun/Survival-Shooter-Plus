using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioMixer masterMixer;

	void Start () {
        masterMixer.SetFloat("sfxVol", 0);
        masterMixer.SetFloat("musicVol", -15);
	}
	
    public void SetSfxLvl(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }
	// Update is called once per frame
	public void SetMusicLvl(float musicLvl) {
        masterMixer.SetFloat("musicVol", musicLvl);
	}
}
