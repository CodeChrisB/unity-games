using UnityEngine;
using System.Collections;
using System;

//It is common to create a class to contain all of your
//extension methods. This class must be static.
public static class ExtensionMethods
{

    public static int ToInt(this String str)
    {
        int num = int.MinValue;
        int.TryParse(str, out num);
        return num;
    }
}