using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]struct AsteriodSpawn
{
    public GameObject GameObject;
    public float SpawnChance;
}
public class AsteriodGeneration : MonoBehaviour
{
    [Header("Spawn Settings")] 
    [SerializeField] AsteriodSpawn[] spawns;
    
    [Header("Poisson disc Settings")] 
    public float radius;
    public Vector2 regionSize;
    public int rejectionSamples;
    List<Vector2> points;

    [Header("Debug Settings")] 
    public float displayRadius = 1;
  
    // Start is called before the first frame update
    void Start()
    {
        
        if (points != null && spawns.Length > 0)
        {
            Spawn();
        }
        
    }

    private void Spawn()
    {
        float totalChance = 0;
        foreach (var spawn in spawns)
        {
            totalChance += spawn.SpawnChance;
        }
        foreach (Vector2 point in points)
        {
           

            float randomValue = Random.Range(0f, totalChance);
            // Determine which asteroid to spawn
            float cumulativeChance = 0f;
            foreach (var asteroid in spawns)
            {
                cumulativeChance += asteroid.SpawnChance;
                if (randomValue <= cumulativeChance)
                {
                    Instantiate(asteroid.GameObject, point- regionSize / 2, Quaternion.identity);
                    break;
                }
            }


        }
    }

    void OnValidate()
        {
            points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(Vector2.zero, regionSize);
            if (points != null)
            {
                foreach (Vector2 point in points)
                {
                    Gizmos.DrawSphere(point - regionSize / 2, displayRadius);
                }
            }
        }
    }
