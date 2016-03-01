using System.Web;

namespace System
{
    public static class MultiTargetSingletonContainer<T>
    {
        private static readonly string _key = typeof(MultiTargetSingletonContainer<T>).FullName;

        public static void RegisterSingleton(T singleton)
        {
            Set(singleton);
        }

        public static T Value => Get();

        private static bool IsWeb()
        {
            return HttpContext.Current != null;
        }

        private static T Get()
        {
            if (IsWeb())
            {
                return (T) HttpContext.Current.Application[_key];
            }
            return (T)ApplicationContext.Current[_key];
        }

        private static void Set(T value)
        {
            if (IsWeb())
                HttpContext.Current.Application[_key] = value;
            else
                ApplicationContext.Current[_key] = value;
        }
    }
}
