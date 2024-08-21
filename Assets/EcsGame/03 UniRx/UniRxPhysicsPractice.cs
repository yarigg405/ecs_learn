using UniRx;
using UniRx.Triggers;
using UnityEngine;


namespace EcsGame.UniRxLesson
{
    internal sealed class UniRxPhysicsPractice : MonoBehaviour
    {
        [SerializeField] private Collider trigger;

        private CompositeDisposable _disposable = new();

        private void Start()
        {
            trigger.OnTriggerEnterAsObservable()
                .Subscribe(x =>
                {
                    SomeLogic();
                }).AddTo(_disposable);
        }

        private void SomeLogic()
        {
            Debug.Log("On trigger enter!");
        }
    }
}