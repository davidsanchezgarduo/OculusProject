using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGenerator : MonoBehaviour
{
    public float distance;
    Ray viewRay;
    RaycastHit viewHit;
    public GameObject crossHairPrefab;
    private GameObject crossHair;

    void Start() {
        crossHair = Instantiate(crossHairPrefab, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(1))
        // {
            // Generar rayo del centro de la pantalla
            viewRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));
            // en viewHit se guarda la información del raycast 
            if (Physics.Raycast(viewRay, out viewHit, distance))
            {
                // Si el rayo golpea a una esfera, le añade una fuerza
                if (viewHit.transform.tag == "Sphere")
                {
                    viewHit.transform.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 150f);
                }
                crossHair.transform.forward = viewHit.normal;
                crossHair.transform.position = viewHit.point + crossHair.transform.forward * 0.05f;
            }
        // }
    }
}
