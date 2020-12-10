namespace UserService.Dtos
{
    public class UserParametersDto
    {
        public string email{get;set;}
        public string phone{get;set;}
        public string orderBy {get; set;}
        public bool descending {get;set;} = false;
    }
}