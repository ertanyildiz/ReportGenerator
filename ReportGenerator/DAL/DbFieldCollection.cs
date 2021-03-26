using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.DAL
{
    public class DbFieldCollection : CollectionBase
    {
        public DbFieldCollection()
        {

        }

        public DbField this[int index]
        {
            get
            {
                return ((DbField)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(DbField value)
        {
            return (List.Add(value));
        }

        public int IndexOf(DbField value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, DbField value)
        {
            List.Insert(index, value);
        }

        public void Remove(DbField value)
        {
            List.Remove(value);
        }

        public void RemoveField(string value)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (((DbField)List[i]).Field == value)
                {
                    List.Remove(((DbField)List[i]));
                    break;
                }
            }
        }

        public object GetValue(string value)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (((DbField)List[i]).Field == value)
                {
                    return ((DbField)List[i]).Value;
                }
            }

            return DBNull.Value;
        }

        public bool Contains(DbField value)
        {
            return (List.Contains(value));
        }

    }
}
