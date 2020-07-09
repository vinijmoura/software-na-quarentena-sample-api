namespace SwNaQuarentena.Api.Repositories
{
    public interface IQuoteRepository
    {
        string GetAQuoteByPersonName(string name);
    }
}