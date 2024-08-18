using Sirenix.OdinInspector;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace EcsGame.AddressablesLesson
{
    internal sealed class Manager : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Renderer;
        [SerializeField] private AssetReference[] materials;
        private AsyncOperationHandle _operationHandle;


        [Button]
        public void SetMaterial(int index)
        {
            SetMaterialAsync(index);
        }

        private async void SetMaterialAsync(int index)
        {
            AsyncOperationHandle<Material> handle = materials[index].LoadAssetAsync<Material>();
            await handle.Task;
            var mat = handle.Result;
            m_Renderer.material = mat;
        }
    }
}