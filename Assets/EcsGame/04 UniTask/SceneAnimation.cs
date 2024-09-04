using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using UnityEngine;


namespace EcsGame.UniTaskLesson
{
    internal sealed class SceneAnimation : MonoBehaviour
    {
        [SerializeField] private Transform[] outerObjectsTransform;

        private async void Start()
        {
            await AnimateOuterObjects(outerObjectsTransform, this.GetCancellationTokenOnDestroy());
        }


        private async UniTask AnimateOuterObjects(Transform[] array, CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f) );
            foreach (var tr in array)
            {
                tr.gameObject.SetActive(true);
                tr.DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.InOutBack);
            }
        }
    }
}