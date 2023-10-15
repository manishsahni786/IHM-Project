using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MireWpf.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DUT_IHM_DataSpoke
    {
        public void Init()
        {
            this.ListNames = new StringSizeConst[100];
        }

        public ushort SpokeDataSelector;		//	#LDS1
        public ushort BP_CalibrationModif;		//	#LDS2
        public ushort DataSpokeNum;		//	#LDS3
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string DataSpokeName;	//	#LDS4
        public float RegrPoliOrdre0;		//	#LDS5
        public float RegrPoliOrdre1;		//	#LDS6
        public float RegrPoliOrdre2;		//	#LDS7
        public float Accuracy;		//	#LDS8
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string DS_Date;	//	#LDS9
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string DS_Validity;	//	#LDS10
        public ushort Cal_NB_Mesure;		//	#LDS11
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public float[] Profil_CalR_Tensiometre;		//	#LDS12
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public float[] Profil_CalR_Peson;		//	#LDS13
        public ushort BP_Calculate;		//	#LDS14
        public ushort CalibRayon_BP_Compute;		//	#LDS15
        public ushort CalibRun;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public float[] CalComparator;		//	#LDS16
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public float[] CalPeson;		//	#LDS17
        public float CalMesurePeson;		//	#LDS18
        public float CalMesureTension;		//	#LDS19
        public ushort CalNumPesonCrs;		//	#LDS20
        public ushort CalNumTensiometreCrs;		//	#LDS21

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public StringSizeConst[] ListNames;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public ushort[] ListNumbers;

        public ushort BP_DS_Delete;
        public ushort AP_CalRefresh;
        public ushort PA_CalRefreshed;
    }
}
