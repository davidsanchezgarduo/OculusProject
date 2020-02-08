using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FirstPersonController : MonoBehaviour
{
    public float speed;
    public float speedRot;
    public Transform transformCamera;
    public float jumpForce;
    public GameObject gun;
    public Shooter shooter;
    private Rigidbody fpsRB;

    private float angleX;
    private int maxHealth = 10;
    private int currentHealth;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        fpsRB = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthText.text = "Lives: " + currentHealth.ToString();
        scoreText.text = "Score: " + score.ToString();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            fpsRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        fpsRB.velocity = (transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime) +
                         (transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime) +
                          Vector3.up * fpsRB.velocity.y;
        /* transform.Translate((Vector3.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime) +
                            (Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime)); */

        transform.Rotate(Vector3.up * speedRot * Time.deltaTime * Input.GetAxis("Mouse X"));
        // transformCamera.Rotate(-Vector3.right * speedRot * Time.deltaTime * Input.GetAxis("Mouse Y"));

        // Limitar el ángulo de giro de la cámara
        angleX += -speedRot * Time.deltaTime * Input.GetAxis("Mouse Y");
        angleX = Mathf.Clamp(angleX, -85f, 75f);
        transformCamera.transform.localRotation = Quaternion.Euler(angleX, 0, 0);

        healthText.text = "Lives: " + currentHealth.ToString();
        scoreText.text = "Score: " + score.ToString();

        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Gun")
        {
            Destroy(collision.gameObject);
            gun.SetActive(true);
            shooter.isActive = true;
        }
        if (collision.transform.tag == "Enemy")
        {
            currentHealth -= 1;
        }
    }
}
