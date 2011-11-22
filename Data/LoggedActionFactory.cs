using Core.Helpers;
using log4net;

namespace Data
{
    public static class LoggedActionFactory
    {
        /// <summary>
        /// Use this to log info after an entity is added.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="entity"></param>
        public static void AfterEntityAdd<T>(ILog log, T entity) where T : class
        {
            LoggedActionFactory.EntityInfo(log, "Added {0}".FormatWith(log.Logger.Name), entity);
        }

        
        /// <summary>
        /// Use this to log info before an entity is validated for an addition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="entity"></param>
        public static void BeforeEntityAdd<T>(ILog log, T entity) where T : class
        {
            LoggedActionFactory.EntityInfo(log, "Attempting to add {0}".FormatWith(log.Logger.Name), entity);
        }

        /// <summary>
        /// Use this to log info before an entity is added to the DataContext.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="entity"></param>
        public static void EntityAdd<T>(ILog log, T entity) where T : class
        {
            LoggedActionFactory.EntityInfo(log, "Adding {0}".FormatWith(log.Logger.Name), entity);
        }

        /// <summary>
        /// Use this to log info after an entity is added.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="entity"></param>
        public static void AfterEntityRemove<T>(ILog log, T entity) where T : class
        {
            LoggedActionFactory.EntityInfo(log, "Added {0}".FormatWith(log.Logger.Name), entity);
        }

        /// <summary>
        /// Use this to log info before an entity is validated for an removal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="entity"></param>
        public static void BeforeEntityRemove<T>(ILog log, T entity) where T : class
        {
            LoggedActionFactory.EntityInfo(log, "Attempting to remove {0}".FormatWith(log.Logger.Name), entity);
        }


        /// <summary>
        /// Use this to log info before an entity is removed to the DataContext.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="entity"></param>
        public static void EntityRemove<T>(ILog log, T entity) where T : class
        {
            LoggedActionFactory.EntityInfo(log, "Removing {0}".FormatWith(log.Logger.Name), entity);
        }


        /// <summary>
        /// Generic info logging method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="entity"></param>
        public static void EntityInfo<T>(ILog log, string message, T entity) where T : class
        {
            log.Info(message + " {0}".FormatWith(entity.ToString()));
        }


        /// <summary>
        /// Generic fatal logging method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="entity"></param>
        public static void Fatal<T>(ILog log, string message, T entity) where T : class
        {
            string str;
            if (entity == null) { str = string.Empty; } else { str = entity.ToString(); }
            log.Fatal(message + " {0}".FormatWith(str).Trim());
        }


        /// <summary>
        /// Generic fatal logging method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="entity"></param>
        public static void Fatal<T>(ILog log, string message)
        {
            LoggedActionFactory.Fatal(log, message, (object)null);
        }


        //I KNOW THIS IS A CRIME BUT ITS A QUICK FIX THAT I WILL FIX LATER... I KNOW I KNOW... STOP THINKING THAT I WILL COME BACK TO IT I PROMISE
        public static string FormatWith(this string target, params object[] args)
        {
            Checks.Argument.IsNotEmpty(target, "target");

            return string.Format(Constants.CurrentCulture, target, args);
        }
    }
}
