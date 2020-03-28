using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceTest
{
    public class MyAspectAttribute : ProxyAttribute
    {
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            MarshalByRefObject target = base.CreateInstance(serverType);
            RealProxy rp;
            rp = new MyProxy(target, serverType);
            return rp.GetTransparentProxy() as MarshalByRefObject;
        }
    }
}
