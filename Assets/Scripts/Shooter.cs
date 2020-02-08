using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject tmpBullet;
    public float forceBullet;
    public bool isActive = false;

    public XRGrabInteractable mInteractive;

    void Start() {
        mInteractive.OnSelectEnter.AddListener(Shoot);
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0) && isActive)
        //if(OVRInput.Get(Axis1D.PrimaryIndexTrigger) && isActive)
        {
            
        }*/
    }

    public void Shoot(XRBaseInteractor obj) {
        Debug.Log("Shoot");
        if (isActive)
        {
            tmpBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            tmpBullet.transform.up = transform.forward;
            tmpBullet.GetComponent<Rigidbody>().AddForce(transform.forward * forceBullet, ForceMode.Impulse);
        }
    }
}
