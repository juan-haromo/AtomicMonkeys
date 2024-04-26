using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_IA : MonoBehaviour
{
    WaveManager wm;
    int choice = 0;
    void Start()
    {
        wm = GetComponent<WaveManager>();
    }

    void Update()
    {
        choice = Choice();
        switch (choice)
        {
            case 1:
                PlaceTorret();
                break;
            case 2:
                Placeunit();
                break;
            case 3:
                PlaceEconomy();
                break;
            default:
                Debug.Log(" no se eligio nada");
                break;
        }
    }

    // here will choice whats gonna do
    int Choice()
    {
        int auxChoice = 0;
        return auxChoice;
    }


    // here will place the torret
    void PlaceTorret()
    {

    }
    // here will place an unit
    void Placeunit()
    {

    }

    // here will buy economy
    void PlaceEconomy()
    {

    }
}
