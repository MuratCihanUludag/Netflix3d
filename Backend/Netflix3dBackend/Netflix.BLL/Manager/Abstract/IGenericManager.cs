using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.BLL.Manager.Abstract
{
    internal interface IGenericManager<TViewModel>
    {
        public void Add(TViewModel viewModel);
        public void Delete(TViewModel viewModel);
        public void Remove(TViewModel viewModel);
        public void Update(TViewModel viewModel);
        public TViewModel GetById(int id);
        public ICollection<TViewModel> GetAll();
    }
}
