using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MireWpf.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DUT_IHM
    {
        public DUT_AP AP { get; set; }
        public DUT_PA PA { get; set; }
    }
}
