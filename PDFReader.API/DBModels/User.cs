namespace PDFReader.API.DBModels
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int FileCount {  get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
