using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    

    public List<List<bool>> towers;

    public class Enemies
    {
        int meleeAmount = 0;
        int tankAmount = 0;
        int rangeAmount = 0;


        public void AddEnemy(int type)
        {
            switch (type)
            {
                case 0:
                    meleeAmount++;
                    break;
                case 1:
                    tankAmount++; 
                    break;
                case 2:
                    rangeAmount++;
                    break;
                default:
                    break;

            }
        }
        public void RemoveEnemy(int type)
        {
            switch (type)
            {
                case 0:
                    meleeAmount--;
                    break;
                case 1:
                    tankAmount--;
                    break;
                case 2:
                    rangeAmount--;
                    break;
                default:
                    break;
            }
        }
    }

    public List<Enemies> enemies;
    
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            towers = new List<List<bool>>();
            enemies = new List<Enemies>();
            for(int i = 0; i < 5; i++)
            {
                enemies.Add(new Enemies());
            }
        }
        else
        {
            Destroy(this);
        }
    }
}


