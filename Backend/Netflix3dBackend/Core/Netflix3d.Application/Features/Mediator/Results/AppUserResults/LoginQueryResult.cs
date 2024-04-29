namespace Netflix3d.Application.Features.Mediator.Results.AppUserResults
{
    public class LoginQueryResult
    {
        public string Token { get; set; }   
        public string RefreshToken { get; set; }    
        public DateTime Expiration { get; set; }    
    }
}
