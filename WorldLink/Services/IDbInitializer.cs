using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldLink.Services
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}
