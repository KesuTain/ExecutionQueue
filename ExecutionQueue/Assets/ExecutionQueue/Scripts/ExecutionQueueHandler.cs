using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.ExecutionQueue
{
    public interface IPartQueue
    {
        public void Execute(Action callback);
    }

    public class ExecutionQueueHandler
    {
        private Queue<IPartQueue> _executionQueue = new Queue<IPartQueue>();
        private Action OnExecuteMethodComplete => Execute;

        public event Action OnQueueComplete;

        public void AddToQueue(IPartQueue item)
        {
            _executionQueue.Enqueue(item);
        }

        public void StopAndClearQueue()
        {
            _executionQueue.Clear();
        }

        public void StartExecute()
        {
            Execute();
        }

        private void Execute()
        {
            if (_executionQueue.Count != 0)
            {
                Debug.Log($"ExecutionQueueHandler: Step! Element: {_executionQueue.Peek()}. Left: {_executionQueue.Count - 1}");

                IPartQueue item = _executionQueue.Dequeue();
                item.Execute(OnExecuteMethodComplete);
            }
            else
            {
                OnQueueComplete?.Invoke();
                Debug.Log("Execute Queue complete!");
            }
        }
    }
}
