using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    /// <summary>
    /// Текущее количество жизней
    /// </summary>
    public int health;
    /// <summary>
    /// Количество HP на текущем уровне
    /// </summary>
    public int numberOfLives;

    /// <summary>
    /// Сколько HP всего за игру
    /// </summary>
    public Image[] lives;

    public Sprite fullLives;
    public Sprite emptyLives;
    
    void Update()
    {
        if (health>numberOfLives)
        {
            health = numberOfLives;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLives;
            }
            else lives[i].sprite = emptyLives;

            if (i<numberOfLives)
            {
                lives[i].enabled = true;
            }
            if (i>numberOfLives)
            {
                lives[i].enabled = false;
            }
        }
    }
}
