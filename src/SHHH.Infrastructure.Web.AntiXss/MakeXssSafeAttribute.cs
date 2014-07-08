namespace SHHH.Infrastructure.Web.AntiXss
{
    using System;

    /// <summary>
    /// Using this attribute on either a property or field will flag it to be processed against Microsoft AntiXss library. 
    /// </summary>
    /// <remarks>
    /// The data type of the property or field should be a string, otherwise it will be ignored.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MakeXssSafeAttribute : Attribute
    {
    }
}
