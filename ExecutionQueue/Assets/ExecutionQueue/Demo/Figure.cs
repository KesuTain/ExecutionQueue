using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.ExecutionQueue;
using System.Threading.Tasks;

namespace Demo
{
    public class Figure : MonoBehaviour, IPartQueue
    {
        public async void Execute(Action callback)
        {
            SetGreenColor();
            await Task.Delay(UnityEngine.Random.Range(1000, 2000));
            callback?.Invoke();
        }

        public void SetGreenColor()
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
