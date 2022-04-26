using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMac.SnapperCoding.Model
{
    interface ISnapperObject
    {
        char[][] GetObject();
        void SetObject();
        void DisplayObject();

    }
}
