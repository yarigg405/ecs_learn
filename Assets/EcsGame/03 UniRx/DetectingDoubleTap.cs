using System;
using UniRx;
using UnityEngine;


namespace EcsGame.UniRxLesson
{
    internal sealed class DetectingDoubleTap : MonoBehaviour
    {
        private void Start()
        {
            Method3();
        }

        private void Method1()
        {
            var mouseEvent = Observable.EveryUpdate().Where(x => Input.GetMouseButtonDown(0))
                  .Buffer(TimeSpan.FromMilliseconds(500)).Where(x => x.Count >= 2)
                  .Subscribe(x => Debug.Log("Double Tap"));
        }


        private void Method2()
        {
            var mouseEvent = Observable.EveryUpdate().Where(x => Input.GetMouseButtonDown(0));
            mouseEvent.Buffer(mouseEvent.SampleFrame(120)).Where(x => x.Count >= 2)
                .Subscribe(x => Debug.Log("Double Tap"));

        }

        private void Method3()
        {
            var mouseEvent = Observable.IntervalFrame(0).Where(x => Input.GetMouseButtonDown(0))
                .Buffer(TimeSpan.FromMilliseconds(400)).Where(x => x.Count >= 2)
                .Subscribe(x => Debug.Log("Double Tap"));

        }
    }
}