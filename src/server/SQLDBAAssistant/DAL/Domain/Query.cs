namespace SQLDBAAssistant.Models.SQLiteModels
{
    public class Query
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextQuery { get; set; }
        public int idUser { get; set; }

    }
}
