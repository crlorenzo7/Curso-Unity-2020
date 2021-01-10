using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameMode
{

    int minObjectsPerWave;
    int maxObjetcsPerWave;
    float spawnInterval;
    int numberOfLifes;

    public int MinObjectsPerWave { get => minObjectsPerWave; set => minObjectsPerWave = value; }
    public int MaxObjetcsPerWave { get => maxObjetcsPerWave; set => maxObjetcsPerWave = value; }
    public float SpawnInterval { get => spawnInterval; set => spawnInterval = value; }
    public int NumberOfLifes { get => numberOfLifes; set => numberOfLifes = value; }

    public GameMode(int minObjectsPerWave, int maxObjectsPerWave, float spawnInterval, int numberOfLifes)
    {
        this.MinObjectsPerWave = minObjectsPerWave;
        this.MaxObjetcsPerWave = maxObjectsPerWave;
        this.SpawnInterval = spawnInterval;
        this.NumberOfLifes = numberOfLifes;
    }

    public static GameMode EASY()
    {
        return new GameMode(1, 2, 1.5f, 3);
    }

    public static GameMode MEDIUM()
    {
        return new GameMode(1, 3, 1.5f, 2);
    }

    public static GameMode HARD()
    {
        return new GameMode(2, 4, 2f, 1);
    }

    public static GameMode GetByIndex(int index)
    {
        GameMode gameMode;
        switch (index)
        {
            default: gameMode = GameMode.EASY(); break;
            case 1: gameMode = GameMode.MEDIUM(); break;
            case 2: gameMode = GameMode.HARD(); break;
        }
        return gameMode;
    }
}
