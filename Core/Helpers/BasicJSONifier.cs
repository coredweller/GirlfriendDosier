using System.Text;

namespace Core.Helpers
{
    public class BasicJSONifier : IJSONifier
    {
        public string Id { get; set; }
        public string Text { get; set; }

        private bool FirstAdd { get; set; }

        public BasicJSONifier(string collectionName, string id, string text)
        {
            CollectionName = collectionName;
            Id = id;
            Text = text;

            FirstAdd = true;

            BuildTemplate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName">What you want the group of your JSON objects called</param>
        /// <param name="id">The ID of each object that is going to be jsonified</param>
        /// <param name="text">The Text of each object that is going to be jsonified</param>
        /// <param name="firstId">The custom first set in the JSON will use this ID</param>
        /// <param name="firstText">The custom first set in the JSON will use this Text</param>
        public BasicJSONifier(string collectionName, string id, string text, string firstId, string firstText)
        {
            CollectionName = collectionName;
            Id = id;
            Text = text;

            FirstAdd = true;

            BuildTemplate();
            Add(firstId, firstText);
        }
        
        protected new void BuildTemplate()
        {
            var sb = new StringBuilder();

            sb.Append("{");
            sb.AppendFormat("\"{1}\":\"{0}\",","{0}", Text);
            sb.AppendFormat("\"{0}\":\"{1}\"", Id, "{1}");
            sb.Append("}");

            Template = sb.ToString();

            base.BuildTemplate();
        }

        /// <summary>
        /// Use this one if you want to get back the string after that add for any reason
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string AddReturn(string key, string value)
        {
            return Builder.AppendFormat(Template, value, key).ToString();
        }

        /// <summary>
        /// To not have the overhead of returning the string every time use this void function
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            var temp = Template.Replace("{0}", value);
            var temp2 = temp.Replace("{1}", key);

            if (FirstAdd)
            {
                Builder.Append(temp2);
                FirstAdd = false;
            }
            else
            {
                Builder.Append("," + temp2);
            }
        }
    }
}
