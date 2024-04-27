using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_IA : MonoBehaviour
{
    public int x;
    public int y;

    GameObject defensePlaced;
    public Color hoverColor;


    private Renderer originalRenderer;

  
    public void BuildTurret()
    {
        if (defensePlaced == null)
        {
            if (DefenseManager_IA.instance.objecToBuild && Economy_IA.instance.Buy(DefenseManager_IA.instance.wall.GetComponentInChildren<Stats>().Price() * (y + 1)))
            {
                defensePlaced = (GameObject)Instantiate(DefenseManager_IA.instance.wall, transform.position, transform.rotation);
            }
            else if (Economy_IA.instance.Buy(DefenseManager_IA.instance.wall.GetComponentInChildren<Stats>().Price() * (y + 1)))
            {
                defensePlaced = (GameObject)Instantiate(DefenseManager_IA.instance.turret, transform.position, transform.rotation);
            }
        }
    }
    public bool candBuild()
    {
        if(defensePlaced == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
