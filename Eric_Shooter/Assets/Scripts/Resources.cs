using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    PlayerController stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            switch (this.transform.tag)
            {
                case ("hp"):
                    if (stats.health == 100)
                    {

                    }
                    else if (stats.health < 100)
                    {
                        stats.health += 25;
                        stats.UIUpdate();
                        Destroy(this.gameObject);
                    }
                    break;
                case ("ammo"):
                    stats.savedAmmo++;
                    stats.UIUpdate();
                    Destroy(this.gameObject);
                    break;

                case ("shield"):
                    if (stats.shield == 100)
                    {

                    }

                    else if (stats.shield < 100)
                    {
                        stats.shield += 25;
                        Destroy(this.gameObject);
                    }
                    break;
            }
        }
    }
}
