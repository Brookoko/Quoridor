namespace Quoridor.Debug
{
    using System;
    using JetBrains.Annotations;
    using UnityEngine;

    [AttributeUsage(System.AttributeTargets.Method), MeansImplicitUse]
    public class EditorButtonAttribute : PropertyAttribute
    {
    }
}
