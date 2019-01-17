using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Library.Entity;
using Library.Models;
using Library.Mappers;

[assembly: OwinStartup(typeof(Library.Startup))]

namespace Library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
            //ConfigureAuth(app);
        }
        
    }
}
