using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Animation shooterAnim;

    public AnimationClip[] shooterAnims;

    [SerializeField]
    private AudioSource shooterAudio;

    public AudioClip[] shooterSounds;

    [SerializeField]
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonUp(0))
       {
            Shoot();
       }
    }

    void Shoot()
    {
        Ray disparo = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit[] hitInfoArray;
        RaycastHit hit;

        hitInfoArray = Physics.RaycastAll(disparo);

        if (Physics.Raycast(disparo, out hit))
        {
            Debug.Log(hit);
        }

        shooterAnim.clip = shooterAnims[0];
        shooterAnim.Play();
        shooterAudio.clip = shooterSounds[0];
        shooterAudio.Play();
    }
}
