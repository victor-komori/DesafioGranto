using DesafioGranto.Repositories.Interface;
using DesafioGranto.Services.Interface;

namespace DesafioGranto.Services
{
    public class OportunidadeService : IOportunidadeService
    {
        private readonly IOportunidadeService _oportunidadeService;

        public OportunidadeService(IOportunidadeService oportunidadeService)
        {
            _oportunidadeService = oportunidadeService;
        }
    }
}
