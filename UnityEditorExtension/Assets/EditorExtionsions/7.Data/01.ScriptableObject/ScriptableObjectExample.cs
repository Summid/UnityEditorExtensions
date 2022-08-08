using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    [CreateAssetMenu]
    public class ScriptableObjectExample : ScriptableObject
    {
        public int IntValue;
        public string StringValue;
    }
}