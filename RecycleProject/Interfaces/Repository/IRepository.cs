using RecycleProject.Interfaces.Models;
using RecycleProject.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleProject.Interfaces
{
    public interface IRepository: IDisposable
    {
        /// <summary>
        /// Ассинхронное получение всех точек приёма
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RecyclePoint>> GetRecyclePointsAsync();

        /// <summary>
        /// Получение точки приёма по уникальному идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RecyclePoint GetRecyclePoint(int id);

        /// <summary>
        /// Получение списка всех зарегестрированных компаний
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Company>> GetCompaniesAsync();

        /// <summary>
        /// Получение компании по уникальному идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Company GetCompany(int id);

        /// <summary>
        /// Добавление новой точки приёма
        /// </summary>
        /// <param name="point"></param>
        void AddRecyclePoint(RecyclePoint point);

        /// <summary>
        /// Добавление новой компании
        /// </summary>
        /// <param name="company"></param>
        void AddCompany(Company company);

        /// <summary>
        /// Изменение существующей точки приёма
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        RecyclePoint ModifityRecyclePoint(RecyclePoint point);

        /// <summary>
        /// Изменение существующей компании
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        Company ModifityCompany(Company company);

        /// <summary>
        /// Получение всех имеющихся категорий
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Category AddCategory(Category category);
    }
}
