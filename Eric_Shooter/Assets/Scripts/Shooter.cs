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
    private GameObject decal;

    public GameObject[] maxDecals;

    private GameObject hole;

    [SerializeField]
    private GameObject ball;

    PlayerController stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonUp(0))
       {
            if (stats.ammo > 0)
            {
                Shoot();
                stats.ammo--;
            }
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
            if (hit.collider != null)
            {
                if (!hit.collider.isTrigger)
                {
                    Vector3 normal = hit.normal;
                    hole = GameObject.Instantiate(decal, hit.point, Quaternion.identity);
                    hole.transform.forward = normal;
                    AddDecal(hole);
                }     
            }    
        }

        shooterAnim.clip = shooterAnims[0];
        shooterAnim.Play();
        shooterAudio.clip = shooterSounds[0];
        shooterAudio.Play();
    }

    void AddDecal (GameObject decal)
    {
        for (int i = 0; i < maxDecals.Length; i++)
        { 

            if (maxDecals[i] == null)
            {
                maxDecals[i] = decal;
                break;
            }

            if (maxDecals[i] != null && i == maxDecals.Length - 1)
            {
                DecalCleaner(decal);
            }
        }
    }

    void DecalCleaner (GameObject decal)
    {
        for (int j = 0; j < maxDecals.Length; j++)
        {
            if (j == 0)
            {
                Destroy(maxDecals[j]);
            }
            if (j > 0 && j < 24)
            {
                maxDecals[j - 1] = maxDecals[j];
            }
            if (j == 24)
            {
                maxDecals[j] = decal;
            }
        }
    }

    public void Reload()
    {
        stats.ammo = 45;

        shooterAnim.clip = shooterAnims[1];
        shooterAnim.Play();

        shooterAudio.clip = shooterSounds[1];
        shooterAudio.Play();
    }
}


