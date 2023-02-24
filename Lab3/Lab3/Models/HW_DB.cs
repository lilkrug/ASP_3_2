using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    
    public class HW_DB
    {
        public HW_DB()
        {
            SortedSet<Data> database = null;
            this.database = new SortedSet<Data>
                (
                    new Data[]
                    {
                        new Data{Id = 1, Name = "Петров В.В.", BDate = new DateTime(2000,12,2), Spec = "Исит", SYear = 2018},
                        new Data{Id = 2, Name = "Шула А.А.", BDate = new DateTime(2002,01,1), Spec = "Исит", SYear = 2019},
                        new Data{Id = 3, Name = "Круглик А.В.", BDate = new DateTime(2003,03,18), Spec = "Исит", SYear = 2020},
                    }, new DataComparer()
                );
        }
        public Data Find(int id) { }
        public bool Insert(Data data) { }
        public bool Update(Data data) { }
        public bool Delete(Data data) { }
        public Data[] GetAll() { }

    }

    public class Data { }
    public class DataComparer { }
}