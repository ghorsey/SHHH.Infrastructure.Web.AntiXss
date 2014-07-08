namespace SHHH.Infrastructure.Web.AntiXss
{
    /// <summary>
    /// An interface that is used run an object through Microsoft's Anti-XSS library
    /// </summary>
    public interface IAntiXssProcessor
    {
        /// <summary>
        /// Processes the object and finds all properties and fields decorated with the <see cref="MakeXssSafeAttribute"/>.
        /// </summary>
        /// <param name="toProcess">To process.</param>
        void ProcessObject(object toProcess);


    }
}
