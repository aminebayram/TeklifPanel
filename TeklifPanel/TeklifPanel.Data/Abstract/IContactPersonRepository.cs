﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Data.Abstract
{
    public interface IContactPersonRepository : IRepository<CustomerContact>
    {
        Task<List<CustomerContact>> GetCustomerContacts(int companyId, int customerId);

    }
}
