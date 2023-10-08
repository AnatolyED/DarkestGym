using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCellToProt : MonoBehaviour
{
    public List<GameObject> cells;

    public void Change()
    {
        foreach(GameObject gmCell in cells)
        {
            CellCoordinate cell = gmCell.GetComponent<CellCoordinate>();   
            var prot = gmCell.AddComponent<CellPrototype>();
            prot.CellCoordinate = cell;
        }
    }
}
