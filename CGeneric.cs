using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGeneric : MonoBehaviour
{

    private void Start()
    {
        Print();
    }

    public void Print()
    {
        NameStore<string> snames = new NameStore<string>();
        snames.AddOrUpdate(0, "TreButler CGeneric list test");
        snames.GetData(0);
        Debug.Log(snames);
    }
    class NameStore<T>
    {
        private T[] _data = new T[10];

        public void AddOrUpdate(int index,T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }




    }
}
