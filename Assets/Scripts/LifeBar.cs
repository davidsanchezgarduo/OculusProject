using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image lifeBarImage;
    public Color fullLife;
    public Color emptyLife;
    public float animDuration;
    private float startTime;

    private float currentHealth;
    private float maxHealth;

    void Start()
    {
        lifeBarImage.color = fullLife;
        lifeBarImage.fillAmount = 1;
        startTime = Time.time;

        maxHealth = this.GetComponentInParent<EnemyController>().maxHealth;
    }

    void Update()
    {
        // lifeBarImage.fillAmount = Mathf.Lerp(0, 1, (Time.time - startTime) / animDuration);
        // lifeBarImage.color = Color.Lerp(emptyLife, fullLife, (Time.time - startTime) / animDuration);
        
        currentHealth = this.GetComponentInParent<EnemyController>().currentHealth;
        float normHealth = (float)currentHealth / (float)maxHealth;
        // lifeBarImage.fillAmount = normHealth;
        lifeBarImage.fillAmount = normHealth;
        lifeBarImage.color = Color.Lerp(emptyLife,fullLife,normHealth);
        // lifeBarImage.fillAmount = Mathf.Lerp(0, normHealth, (Time.time - startTime) / animDuration);
        // lifeBarImage.color = Color.Lerp(emptyLife, fullLife, (Time.time - startTime) / animDuration);
    }
}
