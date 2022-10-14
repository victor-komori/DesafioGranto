namespace DesafioGranto.Models.Utils
{
    public class CpfCnpjUtils
    {
        public static string SemFormatacao(string cnpj)
        {
            return cnpj.Length == 18 ? cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty) : cnpj;
        }
    }
}
