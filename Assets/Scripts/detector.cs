using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class detector
{
    private static bool[] imageTarget;
    private static bool allSeen;

    public static bool[] imageTargets
    {
        get
        {
            return imageTarget;
        }
    }

    public static bool AllSeen
    {
        get
        {
            return allSeen;
        }

        set
        {
            allSeen = value;
        }
    }

    public static void setTarget(int pos, bool detected)
    {
        imageTarget[pos] = detected;
    }

    public static void setSize(int size)
    {
        imageTarget = new bool[size];
    }

    private static int health = 100;

    public static int playerHealth
    {
        get
        {
            return health;
        }
    }

    public static void doMissileDamage()
    {
        health -= 10;
    }
}
