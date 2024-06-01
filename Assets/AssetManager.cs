using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Saga.Assets.Loaders;
using Saga.Debug;
using Saga.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Assets
{
    public class AssetManager : ContentManager
    {
        List<IDisposable> _disposableAssets;
        List<IDisposable> DisposableAssets
        {
            get
            {
                if (_disposableAssets == null)
                {
                    var fieldInfo = ReflectionUtil.GetFieldInfo(typeof(ContentManager), "disposableAssets");
                    _disposableAssets = fieldInfo.GetValue(this) as List<IDisposable>;
                }

                return _disposableAssets;
            }
        }

        public AssetManager() : base(((Game)Core._instance).Services, ((Game)Core._instance).Content.RootDirectory) {}
        public AssetManager(IServiceProvider serviceProvider) : base(serviceProvider) {}
        public AssetManager(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory) {}


        public T LoadJson<T>(string id, string path) where T : class, IDisposable
        {      
            LoadedAssets[id] = JsonLoader.LoadJsonFromFile<T>(path);
            return LoadedAssets[id] as T;
        }

        /// <summary>
        /// Removes the asset from LoadedAssets and disposes of this.
        /// </summary>
        /// <typeparam name="T">Asset name</typeparam>
        /// <param name="assetName">The first type parameter</param>
        public void Unload<T>(string assetName) where T : class, IDisposable
        {
            if (LoadedAssets.ContainsKey(assetName))
            {
                try
                {
                    var assetToRemove = LoadedAssets[assetName];
                    for (var i = 0; i < DisposableAssets.Count; i++)
                    {
                        // Ensure the asset is disposeable. If so, find and dispose of it.
                        var typedAsset = DisposableAssets[i] as T;
                        if (typedAsset != null && typedAsset == assetToRemove)
                        {
                            typedAsset.Dispose();
                            DisposableAssets.RemoveAt(i);
                            Term.Debug($"Unloaded asset {assetName}.");
                            break;
                        }
                    }

                    LoadedAssets.Remove(assetName);
                }
                catch (Exception e)
                {
                    Term.Debug($"Could not unload asset {assetName}. {e}");
                }
            }
        }
    }

}
