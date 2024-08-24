using System.Collections;
using UniRx;
using UnityEngine;


namespace EcsGame.UniRxLesson
{
    internal sealed class MicrocoroutinesPractice : MonoBehaviour
    {
        private IEnumerator Worker()
        {
            int counter = 0;
            while (true)
            {
                counter++;
                yield return null;
            }
        }

        private void Start()
        {
            for (int i = 0; i < 1000; i++)
            {
                MainThreadDispatcher.StartUpdateMicroCoroutine(Worker());
            }
        }
    }
}