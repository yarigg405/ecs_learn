using System.Threading.Tasks;
using UnityEngine;


namespace EcsGame.AsyncAwaitLesson
{
    internal sealed class AsyncTestRotator : MonoBehaviour
    {
        internal async Task RotateForSeconds(float duration)
        {
            var end = Time.time+duration;
            while (Time.time < end)
            {
                transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
                await Task.Yield(); 
            }
        }            
    }
}