using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace EcsGame.AsyncAwaitLesson
{
    internal sealed class DelayButtonTest : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private CancellationTokenSource _tokenSource = null;


        public async void ClickOnButton()
        {
            _tokenSource = new();
            var token = _tokenSource.Token;

            var progress = new Progress<float>(value =>
            {
                slider.value = value;
            });

            try
            {
                await Task.Run(() => DelayMethod(3f, progress, token));
                Debug.Log("Completed");
            }

            catch (OperationCanceledException ex)
            {
                Debug.Log("CAnceled");
            }

            finally
            {
                _tokenSource.Dispose();
            }
        }


        public void ClickOnCancel()
        {
            _tokenSource.Cancel();
        }

        private void DelayMethod(float time, IProgress<float> progress, CancellationToken token)
        {
            var currentTime = 0f;
            while (currentTime < time)
            {
                var deltaTime = 0.01f;
                currentTime += deltaTime;
                Thread.Sleep(10);
                progress.Report(currentTime / time);

                if (token.IsCancellationRequested)
                {
                    progress.Report(0f);
                    // return;
                    token.ThrowIfCancellationRequested();
                }
            }
        }
    }
}