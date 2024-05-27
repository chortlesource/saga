using Newtonsoft.Json;
using Saga.Debug;
using System;
using System.IO;

namespace Saga.Assets.Loaders
{
    /// <summary>
    /// A Loader to deserialize Json files
    /// </summary>
    public static class JsonLoader
    {
        public static T LoadJsonFromFile<T>(string fullPath)
        {
            try
            {
                if (File.Exists(fullPath))
                {
                    using (var streamReader = new StreamReader(fullPath))
                    {
                        string jsonString = streamReader.ReadToEnd();

                        if (!string.IsNullOrEmpty(jsonString))
                        {
                            Term.Debug($"Loaded Json File: {fullPath}");
                            return JsonConvert.DeserializeObject<T>(jsonString);
                        }
                    }
                }
                Term.Debug($"Unable to load: {fullPath}");
            }
            catch (Exception ex)
            {
                Term.Debug($"An error occurred while loading {fullPath}: {ex.Message}");
            }
            return default;
        }
    }
}
