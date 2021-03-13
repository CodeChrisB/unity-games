using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ObjectExtensions
{
    public static void CheckArgument (this System.Object obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));
    }
}