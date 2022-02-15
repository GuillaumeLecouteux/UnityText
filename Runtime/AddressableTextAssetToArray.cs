using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JauntyBear.UnityText
{
    public class AddressableTextAssetToArray
    {
        public event Action<string[]> StringArrayReady;

        public void LoadAddressableTextAsset(AssetReference addressableTextAsset)
        {
            AddressableTextAssetUtility.LoadAddressableTextAsset(addressableTextAsset, (textAsset) => OnTextAssetReady(textAsset));
        }

        public void LoadAddressableTextAsset(string addressableTextAssetKey)
        {
            AddressableTextAssetUtility.LoadAddressableTextAsset(addressableTextAssetKey, (textAsset) => OnTextAssetReady(textAsset));
        }

        public IEnumerator LoadAddressableTextAssetCo(AssetReference reference)
        {
            yield return AddressableTextAssetUtility.LoadAddressableTextAssetCo(reference, (textAsset) => OnTextAssetReady(textAsset));
        }

        public IEnumerator LoadAddressableTextAssetCo(string addressableTextAssetKey)
        {
            yield return AddressableTextAssetUtility.LoadAddressableTextAssetCo(addressableTextAssetKey, (textAsset) => OnTextAssetReady(textAsset));
        }

        private void OnTextAssetReady(TextAsset textAsset)
        {
            string[] strings = TextUtility.TextAssetToArray(textAsset);
            Debug.LogFormat("OnTextAssetReady has a length of {0} and #{1}", textAsset.text.Length, strings.Length);
            StringArrayReady?.Invoke(strings);
        }
    }
}