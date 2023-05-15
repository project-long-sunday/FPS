using System;
using System.Collections;
using UnityEngine;

namespace Assembly_CSharp
{
    public static class Helpers
    {
        public static IEnumerator waitFor<T>(this float delay, Func<T> fun)
        {
            yield return new WaitForSeconds(delay);
            fun.Invoke();
        }

    }
}
