using Sirenix.OdinInspector;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;


namespace EcsGame.UniRxLesson
{
    internal sealed class UniRxTest : MonoBehaviour
    {
        [SerializeField] private TestNotMonoBeh notMonoBeh;


        private readonly float _fireRate = 0.25f;
        private DateTimeOffset _lastFire;

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(x => Input.GetMouseButtonDown(0))
                .Timestamp()
                .Where(x => x.Timestamp > _lastFire.AddSeconds(_fireRate))
                .Subscribe(x =>
                {
                    Fire();
                    _lastFire = x.Timestamp;
                });
        }

        private void Fire()
        {
            Debug.Log("Fire");
        }
    }

    [Serializable]
    internal sealed class TestNotMonoBeh
    {
        private CompositeDisposable _disposable = new();

        [Button]
        public void StartScript()
        {
            Observable.EveryUpdate().Subscribe(LogicMethod).AddTo(_disposable);
        }

        [Button]
        public void StopScript()
        {
            _disposable.Clear();
        }

        private void LogicMethod(long obj)
        {
            Debug.Log($"Update {obj}");
        }
    }
}