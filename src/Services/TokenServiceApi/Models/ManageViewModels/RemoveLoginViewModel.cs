using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenServiceApi.Models.AccountViewModels
{
    public class RemoveLoginViewModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
