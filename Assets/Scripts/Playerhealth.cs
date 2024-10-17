using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    public Image healthBar;   // Assign your health bar Image (filled type) in the inspector
    private float health = 100f;  // Starting health at 100%

    public static Playerhealth Instance;  // Singleton instance

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // Ensure only one instance exists
        }
    }

    public void TakeHit()
    {
        // Decrease health by 10%
        health -= 25f;

        // Update health bar fill amount
        healthBar.fillAmount = health / 100f;

        // Check if health has reached 0
        if (health <= 0)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
