using DevLabs.Domain.Pagination;

namespace DevLabs.Application.DTOs.Pagination
{
    public class ViewPaginationDataDTO<T>
    {
        public int PaginaAtual { get; private set; }
        public int TotalPaginas { get; private set; }
        public int ResultadosExibidosPagina { get; private set; }
        public int ContagemTotalResultados { get; private set; }
        public bool ExistePaginaAnterior { get; private set; }
        public bool ExistePaginaPosterior { get; private set; }

        public ViewPaginationDataDTO(PagedList<T> pagedList)
        {
            ContagemTotalResultados = pagedList.ContagemTotalResultados;
            ResultadosExibidosPagina = pagedList.ResultadosExibidosPagina;
            PaginaAtual = pagedList.PaginaAtual;
            TotalPaginas = pagedList.TotalPaginas;
            ExistePaginaPosterior = pagedList.ExistePaginaPosterior;
            ExistePaginaAnterior = pagedList.ExistePaginaAnterior;
        }
    }
}