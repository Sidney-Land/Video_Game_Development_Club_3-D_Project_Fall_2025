using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Sensitivity for Camera Rotation when looking
    public int playerMouseSensitivity = 0;

    // Speed player moves with thir input (non-normalized)
    public int playerMovementSpeed = 0;

    // Player's Score
    public int score = 0;

    // How much player's score increases when picking up a coin
    public int scoreIncrement = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensures there is only 1 GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        // Destroys all extra GameManagers
        else 
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increases score by scoreIncrement
    public void IncreaseScore()
    {
        score += scoreIncrement;
    }
}
