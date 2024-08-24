using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


namespace EcsGame.UniRxLesson
{
    internal sealed class TheoryOfReactiveProgramming : MonoBehaviour
    {
        private void Start()
        {
            var clickStream = this.UpdateAsObservable()
                .Where(x => Input.GetMouseButtonDown(0));

            clickStream.Buffer(
                clickStream.Throttle(TimeSpan.FromSeconds(0.25f)))
                .Where(x => x.Count >= 2)
                .Subscribe(x => Debug.Log("DoubleString"));
        }

    }
}