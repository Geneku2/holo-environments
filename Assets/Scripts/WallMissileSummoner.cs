using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Academy.HoloToolkit.Unity
{

    public class WallMissileSummoner : MonoBehaviour
    {
        public GameObject WallCollection = null; //Hold Surface Planes, Empty Object that stores all Walls
        public Transform[] Walls; //Array of each of the Walls

        private bool getWallsDone = false; //set to true when all walls are initialized

        private GameObject missileResource;

        private float timePassed = 0.0f;
        private const float repeatTime = 5f;

        private void Start()
        {
            missileResource = Resources.Load("Missile") as GameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (!getWallsDone)
            {
                findWalls();
            }
            else if (detector.AllSeen)
            {
                timePassed += Time.deltaTime; //ADDS TIME THAT HAS PASSED TO TOTAL TIME
                if (timePassed >= repeatTime) //RESETS TIME IF IT GOES OVER THE LIMIT
                {
                    timePassed = 0.0f;
                    summonMissile();
                }
            }
        }

        private void findWalls() //FIND THE WALLS AND PUTS THEM IN AN ARRAY
        {
            WallCollection = GameObject.Find("SurfacePlanes");

            

            int wallCount = 0; //FINDS NUMBER OF WALLS IN COLLECTION

            for(int i = 0; i < WallCollection.transform.childCount; i++)
            {
                if (WallCollection.transform.GetChild(i).GetComponent<SurfacePlane>().PlaneType == PlaneTypes.Wall)
                {
                    wallCount++;
                }
            }

            Walls = new Transform[wallCount]; //ESTABLISHES HOW MANY WALLS


            if (wallCount > 0) { getWallsDone = true; }
            
            //Cycles through all planes and adds Walls to the Walls Array
            int wallNum = 0;
            for (int planeNum = 0; planeNum < WallCollection.transform.childCount; planeNum++)//Cycles through all planes
            {
                if (WallCollection.transform.GetChild(planeNum).GetComponent<SurfacePlane>().PlaneType == PlaneTypes.Wall) //if plane is wall
                {
                    Walls[wallNum] = WallCollection.transform.GetChild(planeNum);
                    wallNum++;
                }
            }
        }

        private void summonMissile()
        {
            int wallNumber = Random.Range(0, Walls.Length - 1); //Selects a random wall


            //summons missile
            GameObject missile = Instantiate(missileResource) as GameObject;
            missile.transform.position = (new Vector3(Walls[wallNumber].transform.position.x, Walls[wallNumber].transform.position.y, Walls[wallNumber].transform.position.z));
        }
    }
}