
namespace Core.Helpers
{
    public class ScriptHelper
    {
        //Used when Registering a Startup Script
        public string ScriptName { get; set; }
        //Used to determine which Div the alert appears in
        public string DivName { get; set; }
        //The message the you want the user to see
        public string Message { get; set; }

        public ScriptHelper(string scriptName, string divName, string message)
        {
            ScriptName = scriptName;
            DivName = divName;
            Message = message;
        }

        public string GetSuccessScript()
        {
           return GenerateScript("success");
        }

        public string GetWarningScript()
        {
            return GenerateScript("warning");
        }

        public string GetFatalScript()
        {
            return GenerateScript("fatal");
        }

        public string GetInfoScript()
        {
            return GenerateScript("info");
        }

        private string GenerateScript(string type)
        {
            return string.Format("<script type=\"text/javascript\"> $('#{0}').jAlert('{1}', \"{2}\"); </script>", DivName, Message, type);
        }
    }
}
