namespace Project.BLL.Helper
{
    public class ApiResponse<type1>
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public string Status { get; set; }

        public type1? Data { get; set; }
    }
}
