using System.Collections.Generic;
using Spartan.Model.Models;

namespace Spartan.Services.Interface
{
    public interface INewService : IService
    {
        IEnumerable<News> GetAllNews();

        News GetNew(int newId);

        IEnumerable<News> GetNewsByName(string newName);

        bool CreateNew(News model);

        bool UpdateNew(News oldNew, News model);

        bool UpdateNewState(News oldNew, int state);

        bool DeleteNew(News model);

        bool SaveAll();

        NewType GetNewType(int newTypeId);
    }
}
