namespace Task5.Models
{
    public interface ITranslationLanguage
    {
        string GetHundreds(int hundred);

        string GetTens(int tens);

        string GetUnits(int unit);

        string GetRanks(int rank);
    }
}
