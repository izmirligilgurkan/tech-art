using System;
using System.Collections.Generic;

namespace Core.Provider
{
    public static class ProviderService
    {
        private static readonly Dictionary<Type, IProvider> Providers = new();
        
        public static void Register<T>(IProvider provider) where T : IProvider
        {
            Providers[typeof(T)] = provider;
        }
        
        public static T Get<T>() where T : IProvider
        {
            if (Providers.TryGetValue(typeof(T), out var provider))
            {
                return (T)provider;
            }
            
            throw new Exception("Provider not found");
        }

        public static void Unregister<T>() where T : IProvider
        {
            Providers.Remove(typeof(T));
        }
    }
}