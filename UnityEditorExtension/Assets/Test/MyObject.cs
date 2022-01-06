using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Test
{
    public class MyObject : MonoBehaviour
    {
        [SerializeField]
        public int anInt;
        [SerializeField]
        public string anString;
        [SerializeField]
        public List<int> anIntArray;
        [SerializeField]
        public GameObject anGameObject;
    }

}
