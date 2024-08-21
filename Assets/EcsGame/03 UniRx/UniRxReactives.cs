using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;


namespace EcsGame.UniRxLesson
{
    internal sealed class UniRxReactives : MonoBehaviour
    {
        private ReactiveProperty<int> _testint = new();
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _testint.Subscribe(TestMethod).AddTo(_disposable);
        }

        private void TestMethod(int obj)
        {
            Debug.Log($"Value is changed: {obj}");
        }

        [Button]
        public void ChangeIntValue(int value)
        {
            _testint.Value = value;
        }
    }
}