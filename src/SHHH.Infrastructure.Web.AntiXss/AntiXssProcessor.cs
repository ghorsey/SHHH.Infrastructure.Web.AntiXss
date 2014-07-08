namespace SHHH.Infrastructure.Web.AntiXss
{
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
            throw new System.NotImplementedException();
        }
    }
}
