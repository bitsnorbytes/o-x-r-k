using Scullery.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scullery.Service{
    class SculleryX {
         private CinemacatalogingContext _dbContext;
        public SculleryX(CinemacatalogingContext context)
        {
            _dbContext = context;
        }
        public void DisplayMovie()
        {
            Console.WriteLine("Querying for a Movie");
        var movie = _dbContext.Movies
    .OrderBy(b => b.MovieId)
    .First();
        }
    }
} 