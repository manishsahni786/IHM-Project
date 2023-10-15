using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MireWpf.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct StringSizeConst
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        private string Value;

        public static implicit operator string(StringSizeConst source)
        {
            return source.Value;
        }

        public static implicit operator StringSizeConst(string source)
        {
            return new StringSizeConst { Value = source };
        }
    }
}
