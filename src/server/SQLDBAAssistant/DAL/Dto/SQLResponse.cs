namespace SQLDBAAssistant.Dto
{
    public class SQLResponse
    {
        public string QueryName = String.Empty;

        public List<Dictionary<string,string>> SelectQuery = new List<Dictionary<string, string>>();
    }
}
