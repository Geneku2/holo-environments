using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    private DefaultTrackableEventHandler eventHandler;
    private bool eventTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        eventHandler = GetComponent<DefaultTrackableEventHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        //IF OBJECT IS DETECTED, ADD TO LIST, IF UNSEEN REMOVE

        if (eventHandler.getDetected() && !eventTriggered) //IF SEEN THEN DO FOLLOWING
        {
            for(int i = 0; i < detector.imageTargets.Length; i++) //TRAVERSES THE ARRAY AND FINDS FIRST FALSE
            {
                if (!detector.imageTargets[i])
                {
                    detector.setTarget(i, true); //SETS FIRST FALSE TO TRUE
                    eventTriggered = true;
                    break;
                }
            }
        } else if (!eventHandler.getDetected() && eventTriggered) //IF NOT SEEN, REMOVE LAST TRUE FROM LIST
        {
            for (int i = detector.imageTargets.Length - 1; i >= 0 ; i--) //TRAVERSES THE ARRAY AND FINDS LAST TRUE
            {
                if (detector.imageTargets[i])
                {
                    detector.setTarget(i, false); //SETS FIRST FALSE TO TRUE
                    eventTriggered = false;
                    break;
                }
            }
        }
    }
}
