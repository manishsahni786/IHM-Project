using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MireWpf.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DUT_IHM_AP_Curves
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2000)]
        public int[] xCirc; //#Courbe4

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2000)]
        public int[] yVoile;	//#Courbe5

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2000)]
        public int[] ySaut;	//#Courbe6

        //Position des extrèmes sur la circonference
        public int xCircVMIN;	//#Courbe7	Position du marqueur min Voile	
        public int xCircVMAX;	//#Courbe8	Position du marqueur max Voile	
        public int xCircSMIN;	//#Courbe9	Position du marqueur min Saut	
        public int xCircSMAX;	//#Courbe10	Position du marqueur max Saut	
        public short cTolVoile;	//#Courbe11	Affichage du trait de tolerance voile	
        public short cTolSaut;	//#Courbe12 Affichage du trait de tolerance Saut	
        public short cValTolV;	//#Courbe13 Affichage valeur graduation ordonnées	
        public short cValTolS;	//#Courbe14 Affichage valeur graduation ordonnées	
    }
}
