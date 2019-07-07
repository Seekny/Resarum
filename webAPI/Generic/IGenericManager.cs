using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HoMe.ServicesInterfaces.Generic
{
    public interface IGenericManager<T>
        where T : IEntity<int>
    {

        /// <summary>
        /// Retourne un objet pour modification. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>L'objet pour modification</returns>
        Task<T> GetOneAsync(int id);

        /// <summary>
        /// Retourne tous les objets de type {T}. A utiliser pour tous les écrans de listing
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

    }
}
