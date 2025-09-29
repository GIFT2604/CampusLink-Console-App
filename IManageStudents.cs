using System.Collections.Generic;

namespace CampusLink
{
    public interface IManageStudents<T>
    {
        void Add(T item);
        bool Edit(string id, string name = null, string gender = null, int? age = null);
        bool Delete(string id);
        List<T> List();
        List<T> Sort(string by);
    }
}
