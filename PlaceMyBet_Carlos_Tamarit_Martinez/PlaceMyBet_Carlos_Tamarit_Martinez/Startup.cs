using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PlaceMyBet_Carlos_Tamarit_Martinez.Startup))]

namespace PlaceMyBet_Carlos_Tamarit_Martinez
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
