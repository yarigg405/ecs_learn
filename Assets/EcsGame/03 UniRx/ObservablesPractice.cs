using UniRx;
using UnityEngine;


namespace EcsGame.UniRxLesson
{
    internal sealed class ObservablesPractice : MonoBehaviour
    {
        private void Start()
        {
            //Observable.EveryUpdate()
            //    .Subscribe(x => Debug.Log("Every update " + x));

            //Observable.TimerFrame(60)
            //    .Subscribe(x => Debug.Log("Once after 60 frames " + x));

            //Observable.IntervalFrame(160)
            //    .Subscribe(x => Debug.Log("Every 160 frames " + x));

            //Observable.Timer(new System.TimeSpan(0, 0, 5))
            //    .Subscribe(x => Debug.Log("Once after 5 sec"));

            //Observable.Interval(new System.TimeSpan(0, 0, 2))
            //    .Subscribe(x => Debug.Log("Every 2 sec"));

        }
    }
}