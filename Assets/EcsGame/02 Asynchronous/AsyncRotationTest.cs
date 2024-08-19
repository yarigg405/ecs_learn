using System.Threading.Tasks;
using TMPro;
using UnityEngine;


namespace EcsGame.AsyncAwaitLesson
{
    internal sealed class AsyncRotationTest : MonoBehaviour
    {
        [SerializeField] private Transform[] rotatables;
        [SerializeField] private float rotatingSpeed = 15f;
        [SerializeField] private TextMeshProUGUI testText;

        private Task[] _tasks;


        private void Awake()
        {
            _tasks = new Task[rotatables.Length];
        }

        private void Start()
        {
            LifeAsync();
        }

        private async void LifeAsync()
        {
            for (int i = 0; i < rotatables.Length; i++)
            {
                _tasks[i] = RotateAsync(rotatables[i], i + 1);
            }

            await Task.WhenAll(_tasks);

            int num = await GetTestNumber();
            testText.text = num.ToString();
        }

        private async Task RotateAsync(Transform tr, float duration)
        {
            var timer = 0f;

            while (timer < 1f)
            {
                var dt = Time.deltaTime / duration;

                timer += dt;
                tr.Rotate(Vector3.up, rotatingSpeed * dt);
                await Task.Yield();
            }
        }

        private async Task<int> GetTestNumber()
        {
            await Task.Delay(10);

            return Random.Range(0, 150);
        }
    }
}