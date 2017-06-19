using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int lives = 20;
    public int money = 100;

    public Text moneyText;
    public Text livesText;

    public void LoseLife(int l = 1)
    {
        lives -= 1;
        if (lives <= 0)
        {
            GameOver();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        moneyText.text = string.Format("Money: {0}", money.ToString());
        livesText.text = string.Format("Lives: {0}", lives.ToString());

	}

    public void GameOver()
    {
        Debug.Log("Game Over");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
