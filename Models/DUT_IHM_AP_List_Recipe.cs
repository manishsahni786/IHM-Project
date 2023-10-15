using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MireWpf.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DUT_IHM_AP_List_Recipe
    {
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeParamIndex = 99, SizeConst = 21)]
        //public string[] ListName;

        public void Init()
        {
            this.ListNames = new StringSizeConst[500];
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 500)]
        public StringSizeConst[] ListNames;

        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 99)]
        //public string[] ListName;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 500)]
        public ushort[] ListFavs;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 500)]
        public ushort[] ListNumRecettes;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 500)]
        public ushort[] Liste_Roue_AV_ARs;
    }
}
