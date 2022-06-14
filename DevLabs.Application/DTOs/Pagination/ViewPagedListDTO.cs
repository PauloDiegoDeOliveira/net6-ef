using DevLabs.Domain.Entitys.Base;
using DevLabs.Domain.Pagination;
using System.Collections.Generic;

namespace DevLabs.Application.DTOs.Pagination
{
    public class ViewPagedListDto<TEntity, TView> where TEntity : EntityBase where TView : class
    {
        public ICollection<TView> Pagina { get; set; }
        public ViewPaginationDataDto<TEntity> Dados { get; set; }

        public ViewPagedListDto(PagedList<TEntity> pagedList, List<TView> list)
        {
            Pagina = list;
            Dados = new ViewPaginationDataDto<TEntity>(pagedList);
        }
    }
}