using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip bg1;
    public AudioClip bg2;
    public Material night;

    private void Start()
    {
        this.GetComponent<AudioSource>().clip = bg1;
        this.GetComponent<AudioSource>().Play();

    }

    public void Change()
    {
        GameObject.Find("Scene Lighting").GetComponent<Light>().enabled = false;
        RenderSettings.skybox = night;
        this.GetComponent<AudioSource>().clip = bg2;
        this.GetComponent<AudioSource>().Play();
    }
}
