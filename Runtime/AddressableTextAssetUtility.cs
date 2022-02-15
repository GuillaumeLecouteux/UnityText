using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

namespace JauntyBear.UnityText
{
    public static class AddressableTextAssetUtility
    {
        /// <summary>
        /// check whether a string exists in an array of strings.
        /// </summary>
        /// <param name="textAsset">a Unity TextAsset.</param>
        /// <returns>string entry found or not.</returns>
        public static void LoadAddressableTextAsset(AssetReference addressableTextAsset, Action<TextAsset> TextAssetReady)
        {
            addressableTextAsset.LoadAssetAsync<TextAsset>().Completed += handle =>
            {

                TextAssetReady?.Invoke(handle.Result);
                Addressables.Release(handle);
            };
        }

        public static void LoadAddressableTextAsset(string addressableTextAssetKey, Action<TextAsset> TextAssetReady)
        {
            Addressables.LoadAssetAsync<TextAsset>(addressableTextAssetKey).Completed += handle =>
            {

                TextAssetReady?.Invoke(handle.Result);
                Addressables.Release(handle);
            };
        }

        public static IEnumerator LoadAddressableTextAssetCo(AssetReference reference, Action<TextAsset> TextAssetReady)
        {
            AsyncOperationHandle<TextAsset> handle = reference.LoadAssetAsync<TextAsset>();
            yield return handle;
            TextAssetReady?.Invoke(handle.Result);
            Addressables.Release(handle);
        }

        public static IEnumerator LoadAddressableTextAssetCo(string addressableTextAssetKey, Action<TextAsset> TextAssetReady)
        {
            AsyncOperationHandle<TextAsset> handle = Addressables.LoadAssetAsync<TextAsset>(addressableTextAssetKey);
            yield return handle;
            TextAssetReady?.Invoke(handle.Result);
            Addressables.Release(handle);
        }
    }
}