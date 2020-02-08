using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.XR;
public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject tmpBullet;
    public float forceBullet;
    public bool isActive = false;

    //private InputDevice device;
    private List<InputDevice> allDevices;

    void Start() {
        // mInteractive.onSelectEnter.AddListener(Shoot);
        allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);

    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && isActive)
        /*if(OVRInput.Get(Axis1D.PrimaryIndexTrigger) && isActive)
        {
            Shoot();
        }*/
        bool triggerValue;
        foreach (InputDevice device in allDevices)
        {
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                //Debug.Log("Trigger button is pressed.");
                Shoot();
            }
        }
    }

    public void Shoot( )
    {
        Debug.Log("Shoot");
        if (isActive)
        {
            tmpBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            tmpBullet.transform.up = transform.forward;
            tmpBullet.GetComponent<Rigidbody>().AddForce(transform.forward * forceBullet, ForceMode.Impulse);
        }
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
