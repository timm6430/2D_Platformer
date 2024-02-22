using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CharacterData
{
    public int level;
    public float health;
    public float[] position;

    public CharacterData (CharacterStats player)
    {
        level = SceneManager.GetActiveScene().buildIndex;
        health = player.GetHealth();
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
