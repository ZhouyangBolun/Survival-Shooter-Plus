using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAid : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHealth;
    public Slider healthSlider;
    AudioSource aidEffect;
    MeshRenderer meshRenderer;
    Light light;
    BoxCollider collider;

    float countTime;

    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        aidEffect = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        light = GetComponentInChildren<Light>();
        collider = GetComponent<BoxCollider>();
	}

    private void Update()
    {
        countTime += Time.deltaTime;
        transform.Rotate(new Vector3(15, -30, -45) * Time.deltaTime);
        if (countTime >= 40)
        {
            Destroy(gameObject, 0.3f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(playerHealth.currentHealth + 50 > 100)
            {
                playerHealth.currentHealth = 100;
            }
            else
            {
                playerHealth.currentHealth += 50;
            }
            aidEffect.Play();
            healthSlider.value = playerHealth.currentHealth;
            meshRenderer.enabled = false;
            light.enabled = false;
            collider.enabled = false;
            Destroy(gameObject, 1.2f);
            
        }
    }
}
