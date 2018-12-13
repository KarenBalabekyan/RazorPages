using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using SimpleStore.DataAccess.Enums;

namespace SimpleStore.DataAccess.Helpers
{
    public static class ResourceHelper
    {
        private static readonly Dictionary<ResourceType, ResourceManager> ResourceDictionary;

        private const string ResourceDirectory = "AutoList.Infrastructure.Resources";

        static ResourceHelper()
        {
            ResourceDictionary = new Dictionary<ResourceType, ResourceManager>();

            foreach (var item in EnumHelper<ResourceType>.GetValues(typeof(ResourceType)))
            {
                var resourceManager = new ResourceManager(Type.GetType($"{ ResourceDirectory }.{ item }Resource"));
                ResourceDictionary.Add(item, resourceManager);
            }
        }

        public static string GetMessageFromResource(string key, ResourceType resourceType, params object[] args)
        {
            var resourceValue = GetValueFromResource(key, ResourceDictionary[resourceType]);

            if (resourceValue == null)
            {
                return $"Resource key { key } does not found!";
            }

            return string.Format(resourceValue, args);
        }

        private static string GetValueFromResource(string propertyName, ResourceManager resourceManager)
        {
            return resourceManager.GetString(propertyName);
        }
    }
}
