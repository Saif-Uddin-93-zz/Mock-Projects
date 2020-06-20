using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSniff : MonoBehaviour
{
    public int[,] extras = new int [4,2];

    public void Sniffer(int x, int z, int[,] grid)
    {
        int vID = grid[x, z];
        int up =    (z + 1) == 9 ? 0 : grid[x, z + 1];
        int down = (z - 1) == -1 ? 0 : grid[x, z - 1];
        int right = (x + 1) == 9 ? 0 : grid[x + 1, z];
        int left = (x - 1) == -1 ? 0 : grid[x - 1, z];


        if (vID == up)
        {
            extras[0, 0] = x; extras[0, 1] = z;
        }
        if (vID == down)
        {
            extras[1, 0] = x; extras[1, 1] = z;
        }
        if (vID == right)
        { 
            extras[2, 0] = x; extras[2, 1] = z; 
        }
        if (vID == left)
        { 
            extras[3, 0] = x; extras[3, 1] = z;
        }
    }
}


//public void Sniffer(int x, int x2, int z, int z2, int[,] grid)
//{
//    int ahead = (x2 + (x2 - x)) == -1 || (x2 + (x2 - x)) == 9 || (z2 + (z2 - z)) == -1 || (z2 + (z2 - z)) == 9 ? 0 : grid[x2 + (x2 - x), z2 + (z2 - z)];
//    int right = (x2 + (z2 - z)) == -1 || (x2 + (z2 - z)) == 9 || (z2 + (x2 - x)) == -1 || (z2 + (x2 - x)) == 9 ? 0 : grid[x2 + (z2 - z), z2 + (x2 - x)];
//    int left = (x2 - (z2 - z)) == -1 || (x2 - (z2 - z)) == 9 || (z2 - (x2 - x)) == -1 || (z2 - (x2 - x)) == 9 ? 0 : grid[x2 - (z2 - z), z2 - (x2 - x)];
//    int vID = 0;// = in_grid[x2, z2];

//    //Debug.Log("\nCOLOUR, POSITION\nAHEAD: " + ahead + ", X: " + (x2 + (x2 - x)) + " Z: " + (z2 + (z2 - z)));
//    //Debug.Log("\nCOLOUR, POSITION\nRIGHT: " + right + ", Xe: " + (x2 + (z2 - z)) + " Z: " + (z2 + (x2 - x)));
//    //Debug.Log("\nCOLOUR, POSITION\nLEFT: " + left + ", X: " + (x2 - (z2 - z)) + " Z: " + (z2 - (x2 - x)));

//    //Match(x, z, in_grid[x, z]);
//    //Match(x2, z2, vID);
//    if (vID == ahead)//Match(x2, z2, ahead))
//    {
//        //Match(x2, z2, ahead);
//        //Sniffer(x2, x2 + (x2 - x), z2, z2 + (z2 - z));
//    }
//    if (vID == right)//Match(x2, z2, right))
//    {
//        //Match(x2, z2, right);
//        //Sniffer(x2, x2 + (z2 - z), z2, z2 + (x2 - x));
//    }
//    if (vID == left)//Match(x2, z2, left))
//    {
//        //Match(x2, z2, left);
//        //Sniffer(x2, x2 - (z2 - z), z2, z2 - (x2 - x));
//    }
//    else //if (!(in_grid[x2, z2] == ahead) && !(in_grid[x2, z2] == right) && !(in_grid[x2, z2] == left))//!Match(x2, z2, ahead) && !Match(x2, z2, right) && !Match(x2, z2, left))
//    {
//        Debug.Log("\n" + left + " , " + vID + " , " + right + "\n" + vID + " , " + ahead);
//        //DestroyMatches();
//    }
//}