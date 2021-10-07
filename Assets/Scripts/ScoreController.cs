using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public Text lifeText;

    // Start is called before the first frame update
    private int Score = 0;
    private int lifes = 3;
    void Start()
    {
        scoreText.text = "Puntaje: " + Score;
        PrintLifes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return this.Score;
    }

    public void PlusScore(int score)
    {
        this.Score += score;
        scoreText.text = "Puntaje: " + Score;

    }

    public void LoseLife()
    {
        lifes -= 1;
        PrintLifes();
    }

    public int GetLifes()
    {
        return lifes;
    }

    private void PrintLifes()
    {
        var text = "Vidas: ";
        for(var i=0; i<lifes; i++)
        {
            text += "I";
        }
        lifeText.text = text;
    }
}
