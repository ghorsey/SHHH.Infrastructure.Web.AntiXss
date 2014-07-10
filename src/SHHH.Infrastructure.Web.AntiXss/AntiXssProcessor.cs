namespace SHHH.Infrastructure.Web.AntiXss
{
    using System.Linq;
    using System.Reflection;

    using Microsoft.Security.Application;

    /// <summary>
    /// The implementation class of the <see cref="IAntiXssProcessor"/> interface
    /// </summary>
    public class AntiXssProcessor : IAntiXssProcessor
    {
        /// <summary>
        /// Processes the object and finds all properties and fields decorated with the <see cref="MakeXssSafeAttribute" />.
        /// </summary>
        /// <param name="toProcess">To process.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ProcessObject(object toProcess)
        {
            var type = toProcess.GetType();
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public|BindingFlags.NonPublic).Where(p => p.IsDefined(typeof(MakeXssSafeAttribute), true));
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(p => p.IsDefined(typeof(MakeXssSafeAttribute), true));

            foreach (var fieldInfo in fields)
            {
                var cleanse = fieldInfo.GetValue(toProcess) as string;
                if (cleanse != null)
                {
                    fieldInfo.SetValue(toProcess, Sanitizer.GetSafeHtmlFragment(cleanse));
                }
            }

            foreach (var propertyInfo in properties)
            {
                var cleanse = propertyInfo.GetValue(toProcess) as string;
                if (cleanse != null)
                {
                    propertyInfo.SetValue(toProcess, Sanitizer.GetSafeHtmlFragment(cleanse));
                }
            }
        }
    }
}
