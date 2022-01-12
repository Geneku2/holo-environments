using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class statText : MonoBehaviour
{
    private TextMeshPro selfText;

    // Start is called before the first frame update
    void Start()
    {
        selfText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        int numTrue = 0;
        for (int i = 0; i < detector.imageTargets.Length; i++)
        {
            if (detector.imageTargets[i])
            {
                numTrue++;
            }
        }

        selfText.text = "Targets Detected: " + numTrue + " / " + detector.imageTargets.Length + "\n" + "Seen All: " + detector.AllSeen + "\n" + detector.playerHealth + " / 100";
    }
}
