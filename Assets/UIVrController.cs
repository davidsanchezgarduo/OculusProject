using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIVrController : MonoBehaviour
{
    public static UIVrController instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    public int lives;
    public int points;
    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint() {
        points++;
        scoreText.text = "Score: " + points;
    }

    public void LessLives()
    {
        lives--;
        healthText.text = "Lives: " + lives;
        if (lives == 0) {
            SceneManager.LoadScene(0);
        }
    }
}
