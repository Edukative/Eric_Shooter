using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesImortSettings : MonoBehaviour
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
}
