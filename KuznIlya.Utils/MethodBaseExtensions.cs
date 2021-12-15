using System.Reflection;
using System.Runtime.ExceptionServices;

namespace KuznIlya.Utils
{
    public static class MethodBaseExtensions
    {
        public static object Invoke(this MethodBase methodBase, object obj, params object[] parameters) =>
            methodBase.Invoke(obj, parameters);

        public static TResult Invoke<TResult>(this MethodBase methodBase, object obj, params object[] parameters) =>
            (TResult)methodBase.Invoke(obj, parameters);

        public static object InvokeAndHoistBaseException(this MethodBase methodBase, object obj, params object[] parameters)
        {
            try
            {
                return methodBase.Invoke(obj, parameters);
            }
            catch (TargetInvocationException e)
            {
                ExceptionDispatchInfo.Capture(e.GetBaseException()).Throw();
                throw;
            }
        }

        public static TResult InvokeAndHoistBaseException<TResult>(this MethodBase methodBase, object obj, params object[] parameters)
        {
            try
            {
                return (TResult)methodBase.Invoke(obj, parameters);
            }
            catch (TargetInvocationException e)
            {
                ExceptionDispatchInfo.Capture(e.GetBaseException()).Throw();
                throw;
            }
        }
    }
}
