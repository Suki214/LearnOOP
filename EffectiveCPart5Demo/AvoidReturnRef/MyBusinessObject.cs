using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidReturnRef
{
    public class MyBusinessObject
    {
        private BindingList<ImportantData> myListofDatas= new BindingList<ImportantData>();

        //public BindingList<ImportantData> Data
        //{
        //    get
        //    {
        //        return myListofDatas;
        //    }
        //}


        //通过某种类型的接口，在调用的时候就只能执行该接口定义的功能
        public IBindingList BindingList
        {
            get
            {
                return myListofDatas;
            }
        }

        public ICollection<ImportantData> CollectionData
        {
            get
            {
                return myListofDatas;
            }
        }

        private DataSet myDS;

        public IList this[string tableName]
        {
            get
            {
                DataView view= myDS.DefaultViewManager.CreateDataView(myDS.Tables[tableName]);
                view.AllowDelete = false;
                view.AllowEdit = false;
                view.AllowNew = false;
                return view;
            }
        }
    }
}
