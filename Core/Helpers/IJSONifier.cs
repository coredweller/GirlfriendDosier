using System.Text;

namespace Core.Helpers
{
    public abstract class IJSONifier
    {
        public string CollectionName { get; set; }
        protected string Template { get; set; }
        protected StringBuilder Builder { get; set; }

        protected void BuildTemplate()
        {
            Builder = new StringBuilder();

            Builder.Append("{\"" + CollectionName + "\":");
            Builder.Append("[");
        }

        /// <summary>
        /// Use this to get the finished JSON string
        /// </summary>
        /// <returns></returns>
        public virtual string GetFinalizedJSON()
        {
            Builder.Append("]}");

            return Builder.ToString();
        }
    }
}
