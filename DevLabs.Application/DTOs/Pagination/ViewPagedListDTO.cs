using DevLabs.Domain.Entitys.Base;
using DevLabs.Domain.Pagination;
using System.Collections.Generic;

namespace DevLabs.Application.DTOs.Pagination
{
    public class ViewPagedListDTO<TEntity, TView> where TEntity : EntityBase where TView : class
    {
        public ICollection<TView> Pagina { get; set; }
        public ViewPaginationDataDTO<TEntity> Dados { get; set; }

        public ViewPagedListDTO(PagedList<TEntity> pagedList, List<TView> list)
        {
            Pagina = list;
            Dados = new ViewPaginationDataDTO<TEntity>(pagedList);
        }
    }
}