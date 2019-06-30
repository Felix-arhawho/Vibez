using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibez.Domain.Models;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.Dtos.ResponseDtos;

namespace Vibez.Repositories.Repositories.Interface
{
    public interface ICategoryRepository : IRepository<int, Category>
    {
        List<CategoryResponseDto> GetAllCategories();
        CategoryResponseDto GetCategoryById(int Id);
        void CreateCategory(CategoryRequestDto categoryRequestDto);
        void EditCategory(CategoryRequestDto categoryRequestDto);
    }
}
