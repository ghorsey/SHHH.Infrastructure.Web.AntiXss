namespace SHHH.Infrastructure.Web.AntiXss.Tests
{
    /// <summary>
    /// The sample object used to test/validate the processor
    /// </summary>
    public class SampleTestObject
    {
        public SampleTestObject()
        {
            this.PrivateSetProperty = "This <script>alert('boo');</script> is unsafe";
        }
        /// <summary>
        /// The string field
        /// </summary>
        [MakeXssSafe]
        private string stringField;

        /// <summary>
        /// The object field
        /// </summary>
        [MakeXssSafe]
        private object objectField;

        /// <summary>
        /// Gets or sets the object field.
        /// </summary>
        /// <value>
        /// The object field.
        /// </value>
        public object ObjectField
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <summary>
        /// Gets or sets the string field.
        /// </summary>
        /// <value>
        /// The string field.
        /// </value>
        public string StringField
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }

        /// <summary>
        /// Gets or sets the string property.
        /// </summary>
        /// <value>
        /// The string property.
        /// </value>
        [MakeXssSafe]
        public string StringProperty { get; set; }

        /// <summary>
        /// Gets or sets the int property.
        /// </summary>
        /// <value>
        /// The int property.
        /// </value>
        [MakeXssSafe]
        public int IntProperty { get; set; }

        /// <summary>
        /// Gets the private set property.
        /// </summary>
        /// <value>
        /// The private set property.
        /// </value>
        [MakeXssSafe]
        public string PrivateSetProperty { get; private set; }

        /// <summary>
        /// Gets or sets the allow unsafe.
        /// </summary>
        /// <value>
        /// The allow unsafe.
        /// </value>
        public string AllowUnsafe { get; set; }
    }
}
