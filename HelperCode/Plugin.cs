using UnityEngine;
using System.Reflection;
using System;

namespace HelperCode
{
    public static class Helpers 
    {
        // Call a function
        public static object call(object o, string methodName, params object[] args)
        {
            try
            {
                var mi = o.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi != null)
                {
                    return mi.Invoke(o, args);
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
                return null;
            }
        }
    }
}