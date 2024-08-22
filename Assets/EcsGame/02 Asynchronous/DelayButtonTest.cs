using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


namespace EcsGame.AsyncAwaitLesson
{
    internal sealed class DelayButtonTest : MonoBehaviour
    {
        [SerializeField] private int delay = 1000;
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;

        public void ClickOnButton()
        {
            DelayMethod();
        }

        public void ClickOnCancel()
        {
            cancelTokenSource.Cancel();
        }

        private async void DelayMethod()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
                        
            try
            {
                Task task = Task.Delay(delay, token);
                await task;
                TargetMethod();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Debug.Log("Операция прервана");
                    else
                        Debug.Log(e.Message);
                }
            }
        }

        private void TargetMethod()
        {
            Debug.Log("Clicked");
        }
    }
}