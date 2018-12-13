using System;
using System.Collections.Generic;
using System.Text;
using SimpleStore.DataAccess.DbContexts;
using SimpleStore.DataAccess.Entities;
using SimpleStore.DataAccess.Repositories.Interfaces;

namespace SimpleStore.DataAccess.Repositories
{
    public class OrderRepository: Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {

        }


    }
}
