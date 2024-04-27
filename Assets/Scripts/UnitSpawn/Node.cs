using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int x; 
    public int y;

    GameObject defensePlaced;
    public Color hoverColor;

    private Renderer originalRenderer;
    private Color startColor;


    private void Start()
    {
        originalRenderer = GetComponent<Renderer>();
        startColor = originalRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        originalRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        originalRenderer.material.color = startColor;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BuildTurret();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SellTurret();
        }
    }

    public void BuildTurret()
    {
        if(defensePlaced == null)
        {
            if(DefenseManager.instance.objecToBuild && Economy.instance.Buy(DefenseManager.instance.wall.GetComponentInChildren<Stats>().Price()*(y+1))) 
            { 
                defensePlaced = (GameObject)Instantiate(DefenseManager_IA.instance.wall,transform.position,transform.rotation); 
            }
            else if(Economy.instance.Buy(DefenseManager_IA.instance.wall.GetComponentInChildren<Stats>().Price()*(y+1)))
            {
                defensePlaced = (GameObject)Instantiate(DefenseManager_IA.instance.turret, transform.position, transform.rotation);
            }
            else
            {
                return;
            }
            WaveManager.instance.towers[x][y] = true;
        }
    }

    public void SellTurret()
    {
        if (defensePlaced)
        {
            if(defensePlaced.GetComponent<Stats>().IsMaxHealt()) 
            {
                Economy.instance.AddMoney(defensePlaced.GetComponent<Stats>().Price()*(y+1));
            }
            Destroy(defensePlaced);
            defensePlaced = null;
            WaveManager.instance.towers[x][y] = false;
        }
    }
}
