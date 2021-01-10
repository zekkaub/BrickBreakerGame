using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{

    public float X_Start, Y_Start;
    public float colLength, rowlength;
    public float X_Space, y_Space;
    public void Start()
    {
        for (int i=0; i<colLength*rowlength; i++)
        {
            BrickPooler.Instance.spawnfrompool("Brick", new Vector2(X_Start + (X_Space*(i/rowlength)),Y_Start + (y_Space*(i%rowlength))) , Quaternion.identity);
            
        }
        return;
    }
}
