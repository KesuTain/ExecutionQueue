using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.ExecutionQueue;

namespace Demo
{
    public class FiguresController : MonoBehaviour
    {
        [SerializeField] private List<Figure> _figures;
        private ExecutionQueueHandler _queueHandler;
        private void Awake()
        {
            _queueHandler = new ExecutionQueueHandler();
        }

        private void Start()
        {
            foreach (Figure figure in _figures)
            {
                _queueHandler.AddToQueue(figure);
            }

            _queueHandler.StartExecute();
        }
    }
}
