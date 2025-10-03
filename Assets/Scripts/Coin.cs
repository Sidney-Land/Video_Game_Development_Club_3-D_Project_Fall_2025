using UnityEngine;

public class Coin : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increase score when touched by player
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.IncreaseScore();

        gameObject.SetActive(false);
    }
}
