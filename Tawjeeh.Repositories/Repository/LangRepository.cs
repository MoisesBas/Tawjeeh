using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class LangRepository : BaseRepository<Lang>, 
        ILangRepository
    {
        public LangRepository(IConnectionFactory connectionFactory) 
            : base(connectionFactory)
        {
        }
        public int CreateLang(Lang lang) => Create(lang);
        public int DeleteLang(Lang lang) => Delete(lang);
        public Task<IEnumerable<Lang>> GetAll() => GetAllAsync();      

        public Lang GetLangById(int id)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var query = "SELECT * FROM tblLang WHERE Id=@id and IsDeleted=0";
                var result = _conn.Query<Lang>(query, new { @id = id });
                return result.FirstOrDefault();
            }
        }
        public int UpdateLang(Lang lang) => Update(lang);        
    }
}
