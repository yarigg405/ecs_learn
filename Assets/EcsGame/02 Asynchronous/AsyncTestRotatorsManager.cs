using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace EcsGame.AsyncAwaitLesson
{
    internal sealed class AsyncTestRotatorsManager : MonoBehaviour
    {
        [SerializeField] private AsyncTestRotator[] rotators;

        [Button]
        public async void BeginTest()
        {
            List<Task> tasks = new(3);
            for (int i = 0; i < rotators.Length; i++)
            {
                tasks.Add(rotators[i].RotateForSeconds(1 + 1 * i));
            }

            await Task.WhenAny(tasks);
            Debug.Log("Finished");
        }

        [Button]
        public async void ShowRandomNumber()
        {
            var num = await GetRandomNumber();
            Debug.Log(num.ToString());
        }

        private async Task<int> GetRandomNumber()
        {
            await Task.Delay(1000);
            return Random.Range(0, 500);
        }
    }
}
