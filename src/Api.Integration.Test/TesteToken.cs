using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
    public class TesteToken : BaseIntegration
    {
        [Fact]
        public async Task testaToken()
        {
            await AdicionarToken();
        } 
    }
}
