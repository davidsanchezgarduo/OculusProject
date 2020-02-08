using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gun;
    public GameObject gunPLayer;
    public Shooter shooter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void grabGun() {
        Destroy(gun);
        gunPLayer.SetActive(true);
        shooter.isActive = true;
    }
}
