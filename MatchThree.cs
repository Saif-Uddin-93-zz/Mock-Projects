//using System;
using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks;
using UnityEngine;

public class MatchThree : MonoBehaviour
{
    GameObject[,] go_grid;
    int[,] in_grid;

    int rowTrack = 0;
    int colTrack = 0;

    int id;
    private int[] cubeIDs = new int[4];

    public GameObject Red;
    public GameObject Green;
    public GameObject Orange;
    public GameObject Blue;

    public GameObject redMarkerT;
    public GameObject redMarkerB;
    public GameObject redMarkerL;
    public GameObject redMarkerR;
    public GameObject greenMarker;

    Colours redC;
    Colours greenC;
    Colours blueC;
    Colours orangeC;

    NewSniff sniff;

    void Start()
    {
        go_grid = new GameObject[9, 9];
        in_grid = new int[9, 9];
        for (int i = 1; i<=4; i++) { cubeIDs[i-1] = i; }

        redC = new Colours();
        greenC = new Colours();
        blueC = new Colours();
        orangeC = new Colours();

        BuildRows();
    }

    void Update()
    {
        SelectCube();
    }

    void BuildRows()
    {
        if (colTrack < 9)
        {
            SpawnCubes(colTrack);
        }
    }

    void SpawnCubes(int z) 
    {
        for (int i = 0; i<=8; i++) {
            rowTrack = i;
            go_grid[i, z] = (GameObject)Instantiate(NewCube(), new Vector3((float)i, 0.1f, (float)z), transform.rotation);
            in_grid[i, z] = id;
            if (rowTrack == 8) { rowTrack = 0; colTrack++; BuildRows(); } //else { rowTrack++; }
        }
    }

    
    GameObject NewCube()
    {
        int n = UnityEngine.Random.Range(0, cubeIDs.Length);

        if (colTrack != 0)
        {//check to prevent cubes to match in columns when game initialises
            while (cubeIDs[n] == in_grid[rowTrack, colTrack - 1]) n = UnityEngine.Random.Range(0, cubeIDs.Length);
        }

        id = cubeIDs[n];
        
        switch (id)
        {
            case 1:
                SortIDs(2, 3, 4);
                return Red;
            case 2:
                SortIDs(1, 3, 4);
                return Green;
            case 3:
                SortIDs(1, 2, 4);
                return Orange;
            case 4:
                SortIDs(1, 2, 3);
                return Blue;
            default:
                return null;
        }
    }

    void SortIDs(params int[] ids)
    {//function to prevent cubes to match in rows when game initialises
        cubeIDs = ids;
    }

    GameObject[,] selGrid = new GameObject[9,9];
   // GameObject go_selected;
    //int in_selected;
    int xSel;
    int zSel;
    int xPrev;
    int zPrev;

    int[] toDestroy;


    bool markerShowing = false;
    private bool swapping = false;

    void SelectCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 8f))
            {
                Debug.Log(hit.transform.name + "\n" + hit.transform.position);
                xSel = (int)hit.transform.position.x; zSel = (int)hit.transform.position.z;
                //go_selected = go_grid[xSel, zSel];
               // in_selected = in_grid[xSel, zSel];
                //Debug.Log(go_selected + "\n" + xSel + " " + zSel);                
                if (markerShowing) SwapCubes();
                Debug.Log("markerShowing is " + markerShowing);
                if(!swapping)ShowMarkers();
                Debug.Log("markerShowing is " + markerShowing);
            }
        }
    }


    void ShowMarkers()
    {
        if (selGrid[xSel, zSel] == null && !markerShowing)
        {//Green Marker
            selGrid[xSel, zSel] = (GameObject)Instantiate(greenMarker, new Vector3((float)xSel, 0.05f, (float)zSel), transform.rotation);
            GameObject.Instantiate(redMarkerR, new Vector3((float)xSel+1, 0.01f, (float)zSel), transform.rotation);//right
            GameObject.Instantiate(redMarkerL, new Vector3((float)xSel-1, 0.01f, (float)zSel), transform.rotation);//left
            GameObject.Instantiate(redMarkerB, new Vector3((float)xSel, 0.01f, (float)zSel-1), transform.rotation);//bottom
            GameObject.Instantiate(redMarkerT, new Vector3((float)xSel, 0.01f, (float)zSel+1), transform.rotation);//top
            toDestroy = new int[]{ xSel, zSel };
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("marker"))
            {
                if (g.transform.position.x == -1f || g.transform.position.x == 9f || g.transform.position.z == -1f || g.transform.position.z == 9f)
                {
                    Destroy(g);
                }
            }
            markerShowing = true;
            xPrev = xSel;
            zPrev = zSel;
        }
        
        else DestroyMarker(toDestroy);
    }

    void DestroyMarker(params int[] d) 
    {
        for (int i = 0; i < d.Length; i++) 
        {
            Destroy(selGrid[d[i], d[i+1]]);
            i++;
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("marker")) { Destroy(g); }        
        markerShowing = false;        
    }

    void SwapCubes()
    {        
        if ((xSel == xPrev) && (zSel == zPrev + 1) || (xSel == xPrev) && (zSel == zPrev - 1) || (xSel == xPrev - 1) && (zSel == zPrev) || (xSel == xPrev + 1) && (zSel == zPrev))
        {swapping = true; }
        if (swapping) 
        {
            GameObject go_oldPos = go_grid[xPrev, zPrev]; ;
            GameObject go_newPos = go_grid[xSel, zSel];
            int in_oldPos = in_grid[xPrev, zPrev];
            int in_newPos = in_grid[xSel, zSel];

            Vector3 v3_old = go_grid[xPrev, zPrev].transform.position;
            Vector3 v3_new = go_grid[xSel, zSel].transform.position;

            //Destroy(go_grid[xPrev, zPrev]);
            //Destroy(go_grid[xSel, zSel]);
            //go_grid[d[i, 0], d[i, 1]] = null;
            //in_grid[d[i, 0], d[i, 1]] = 0;
            //go_grid[xSel, zSel] = (GameObject)Instantiate(go_oldPos);//, new Vector3((float)xPrev, 0.1f, (float)zPrev), transform.rotation);
            //go_grid[xPrev, zPrev] = (GameObject)Instantiate(go_newPos);//, new Vector3((float)xSel, 0.1f, (float)zSel), transform.rotation);

            go_grid[xSel, zSel].transform.position = v3_old; //new to old
            go_grid[xPrev, zPrev].transform.position = v3_new; //old to new

            go_grid[xSel, zSel] = go_oldPos;
            go_grid[xPrev, zPrev] = go_newPos;
            in_grid[xSel, zSel] = in_oldPos;
            in_grid[xPrev, zPrev] = in_newPos;
            
            swapping = false;

            //NewSniff(xPrev, xSel, zPrev, zSel);
            SniffX();
        }
    }    

    void SniffX()
    {
        int vID = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Match(j, i, vID);
                vID = in_grid[j, i];
                if (i == 8 && j == 8)
                {//reached end of search
                    SniffZ();
                }
            }
        }
    }
    void SniffZ()
    {
        int vID = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Match(i, j, vID);
                vID = in_grid[i, j];
                if (i == 8 && j == 8)
                {//reached end of search
                    DestroyMatches();
                    //Debug.Log(in_grid);
                }
            }
        }
    }

    void Match(int x, int z, int vID)
    {
        switch (in_grid[x, z])
        {
            case 1:
                if (in_grid[x, z] != vID /*|| in_grid[z, x] != vID2*/) { redC.ClearCounter(); }//return false; }
                redC.CollectMatches(x,z); break;
                //return true;
            case 4:
                if (in_grid[x, z] != vID /*|| in_grid[z, x] != vID2*/) { blueC.ClearCounter(); }//return false; }
                blueC.CollectMatches(x,z); break;
                //return true;
            case 2:
                if (in_grid[x, z] != vID /*|| in_grid[z, x] != vID2*/) { greenC.ClearCounter(); }//return false; }
                greenC.CollectMatches(x,z); break;
                //return true;
            case 3:
                if (in_grid[x, z] != vID /*|| in_grid[z, x] != vID2*/) { orangeC.ClearCounter(); }//return false; }
                orangeC.CollectMatches(x,z); break;
                //return true;
            default: break;// return false;
        }
    }

    void DestroyMatches() 
    {
        int[,] d;
        if (redC.hasMatch)
        {
            for (int r = 0; r < redC.Matches(); r++)
            {
                d = redC.DestroyCubes(r);
                D_Cubes(d);
            }
        }
        redC.ClearCounter(); redC.ClearMatchesFound(); redC.ClearBool();
        if (greenC.hasMatch)
        {
            for (int g = 0; g < greenC.Matches(); g++)
            {
                d = greenC.DestroyCubes(g);
                D_Cubes(d);
            }
        }
        greenC.ClearCounter(); greenC.ClearMatchesFound(); greenC.ClearBool();
        if (orangeC.hasMatch)
        {
            for (int o = 0; o < orangeC.Matches(); o++)
            {
                d = orangeC.DestroyCubes(o);
                D_Cubes(d);
            }
        }
        orangeC.ClearCounter(); orangeC.ClearMatchesFound(); orangeC.ClearBool();
        if (blueC.hasMatch)
        {
            for (int b = 0; b < blueC.Matches(); b++)
            {
                d = blueC.DestroyCubes(b);
                D_Cubes(d);
            }
        }
        blueC.ClearCounter(); blueC.ClearMatchesFound(); blueC.ClearBool();
    }

    void D_Cubes(int [,] d) 
    {
        for (int i = 0; i < 3; i++)
        {
            if (go_grid[d[i, 0], d[i, 1]] != null) 
            {
                sniff = new NewSniff();
                sniff.Sniffer(d[i, 0], d[i, 1], in_grid);
                
                Destroy(go_grid[d[i, 0], d[i, 1]]);
                go_grid[d[i, 0], d[i, 1]] = null;
                in_grid[d[i, 0], d[i, 1]] = 0;
            }            
        }
    }

    //void BubbleSort(int[] arr)
    //{
    //    int n = arr.Length;
    //    for (int i = 0; i < n - 1; i++)
    //        for (int j = 0; j < n - i - 1; j++)
    //            if (arr[j] > arr[j + 1])
    //            {
    //                int temp = arr[j];
    //                arr[j] = arr[j + 1];
    //                arr[j + 1] = temp;
    //            }
    //}
}
