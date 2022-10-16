namespace DesafioGranto.Models.Utils
{
    public class CpfCnpjUtils
    {
        public static string SemFormatacao(string cnpj)
        {
            return cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }
    }
}
