using System;
using System.IO;
using UnityEngine;
 
namespace Geekbrains
{
    public class Test : MonoBehaviour
    {
        public delegate int TestDelegate(bool value);

        public Func<int> FuncTest;

        public Predicate<int> PredTest;

        public TestDelegate DelegateField;
        private void Start()
        {
            If(0);
            DisplayShapesName(new Sphere());
        }


        public void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }
        
        private interface IShape
        {
            void DisplayName();
        }

        private class Sphere : IShape
        {
            public void DisplayName()
            {
                Debug.Log("Sphere");
            }
        }

        public class Triangle : IShape
        {
            public void DisplayName()
            {
                Debug.Log("Triangle");
            }
        }

        private void DisplayShapesName(IShape shape)
        {
            shape.DisplayName();
        }

        private int Do()
        {
            return 0;
        }

        private bool If(int a)
        {
            if (a <= 0)
            {
               Debug.LogError("Value was zero");
            }
            return a > 0;
        }

        public class Observable
        {
            public Action Event;
        }

        public class Observer
        {
            public void Observe(){}
        }
    }
}
