using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    public int size; //sets size of number of objects to be detected
    public GameObject sheild;
    private bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        detector.setSize(size);
        detector.AllSeen = false;
    }

    private void Update()
    {
        

        int numTrue = 0;
        for (int i = 0; i < detector.imageTargets.Length; i++)
        {
            if (detector.imageTargets[i])
            {
                numTrue++;
                if (numTrue == detector.imageTargets.Length)
                {
                    detector.AllSeen = true;
                }
            }
        }


        //SHEILD IS INITIALLY HIDDEN, BUT THEN SHOWS IT WHEN ALL OBJECTS ARE SEEN
        if (detector.AllSeen && !initialized)
        {
            sheild.SetActive(true);
            initialized = true;
        }
    }
}
