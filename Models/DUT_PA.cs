using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MireWpf.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DUT_PA
    {
        //Item 4- Affichage du bouton roue arrière
        public short Dde_Changement_roue;			//Toggle 0 to 1
        //Item 5- Button shutdown
        public short dde_ShutDown;		//Bouton pour coupure de l'application (Provoque l'extinction du PC via Twincat)*/
        //Item 21 -	Operator_ID
        public short Operator_ID;	//Numéro d'identification opérateur
        //Item22
        public short Print_sticker;		//Impression etiquettes
        //Item24
        public short Print_DataSheet;       //Impression etiquettes
        public short Return_tag;		//Impression etiquettes

        //Item26
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string IDValue;      //valeur du code barre en manuel
        public short ID_BP_OK;		//BP OK
        public short ID_BP_Cancel;		//BP Cancel


        /*==========================================================================*/
        /*			#Courbe															*/
        /*==========================================================================*/
        /*Courbe d'acquision*/
        public short Num_Refresh;	//#Courbe3 Si valeur différente de last refresh raffraichissement de la courbe

        /*==========================================================================*/
        /*                        #Tableau rayon                                    */
        /*==========================================================================*/
        public short Selecteur_Rayon;        //#Tbl0 Lors de l'appuie sur une case rayon l'on écrase selecteur rayon avec le numéro de rayon
        public short Selecteur_Rayon_INC;        //#Tbl1 Wrinte 1 if press button Down arrow
        public short Selecteur_Rayon_DEC;        //#Tbl2 Wrinte 1 if press button Up arrow
        public short Selecteur_Rayon_Auto;
        /*==========================================================================*/
        /*			#Directory														*/
        /*==========================================================================*/
        public ushort PopupId; //0=nopopup 1=hub 2=perimeter 3=symmetry 4=ID
        public ushort FR_dde_Save;		//Pulse 1sec                                                                #Dir1
        public ushort FR_dde_Load;		//Pulse 1sec                                                                #Dir2

        public ushort FR_BP_Validate;		//Touche Validate 0=False 1 =True		#FR7			
        public ushort FR_Selecteur_FR;		//Sélecteur fiche roue					#FR9

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string FR_String_Name;	//Nom fiche roue						#FR10

        public ushort FR_AV_AR;		//0=Roue Avant, 1= Roue Arrière			#FR11
        public ushort FR_circ;		//Modulo circonference					#FR12
        public float FR_Pos_Broche;		//Position broche						#FR13
        public float FR_Off7_Deport;		//Correction du déport					#FR14
        public ushort FR_DS_Num;		//Data spoke Num						#FR15

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string FR_DS_Name;	//Data spoke_Name						#FR16

        public ushort FR_DS_Nb_Rayon;		//Nb rayon								#FR17

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string FR_DS_Date;	//Date de la calibration				#FR18

        public ushort FR_Type_Roue;		//0=PF, 1=PE, 2=AsymetriquePF, 3=AsymétriquePE		#FR19
        public float FR_Off7_Volontaire;		//Off7 volontaire						#FR20
        public ushort FR_Used;		//Roue active							#FR21
        public float FR_ToleranceVoile_Step1;		//Tolerance en mm						#FR22
        public float FR_ToleranceVoile_Step2;		//Tolerance en mm						#FR23
        public float FR_ToleranceVoile_Step3;		//Tolerance en mm						#FR24
        public float FR_ToleranceVoile_Step4;		//Tolerance en mm						#FR25
        public float FR_ToleranceVoile_Step5;		//Tolerance en mm						#FR26
        public float FR_ToleranceSaut_Step1;		//Tolerance en mm						#FR27
        public float FR_ToleranceSaut_Step2;		//Tolerance en mm						#FR28
        public float FR_ToleranceSaut_Step3;		//Tolerance en mm						#FR29
        public float FR_ToleranceSaut_Step4;		//Tolerance en mm						#FR30
        public float FR_ToleranceSaut_Step5;		//Tolerance en mm						#FR31
        public float FR_ToleranceDeport_Step1;		//Tolerance en mm						#FR32
        public float FR_ToleranceDeport_Step2;		//Tolerance en mm						#FR33
        public float FR_ToleranceDeport_Step3;		//Tolerance en mm						#FR34
        public float FR_ToleranceDeport_Step4;		//Tolerance en mm						#FR35
        public float FR_ToleranceDeport_Step5;		//Tolerance en mm						#FR36
        public ushort FR_TolTR_RMin_G_Step1;		//Tolerance tension rayon gauche en kg		#FR37
        public ushort FR_TolTR_RMin_G_Step2;		//Tolerance tension rayon gauche en kg		#FR38
        public ushort FR_TolTR_RMin_G_Step3;		//Tolerance tension rayon gauche en kg		#FR39
        public ushort FR_TolTR_RMin_G_Step4;		//Tolerance tension rayon gauche en kg		#FR40
        public ushort FR_TolTR_RMin_G_Step5;		//Tolerance tension rayon gauche en kg		#FR41
        public ushort FR_TolTR_RMax_G_Step1;		//Tolerance tension rayon gauche en kg		#FR42
        public ushort FR_TolTR_RMax_G_Step2;		//Tolerance tension rayon gauche en kg		#FR43
        public ushort FR_TolTR_RMax_G_Step3;		//Tolerance tension rayon gauche en kg		#FR44
        public ushort FR_TolTR_RMax_G_Step4;		//Tolerance tension rayon gauche en kg		#FR45
        public ushort FR_TolTR_RMax_G_Step5;		//Tolerance tension rayon gauche en kg		#FR46
        public ushort FR_TolTR_MoyMin_G_Step1;		//Tolerance tension rayon gauche en kg		#FR47
        public ushort FR_TolTR_MoyMin_G_Step2;		//Tolerance tension rayon gauche en kg		#FR48
        public ushort FR_TolTR_MoyMin_G_Step3;		//Tolerance tension rayon gauche en kg		#FR49
        public ushort FR_TolTR_MoyMin_G_Step4;		//Tolerance tension rayon gauche en kg		#FR50
        public ushort FR_TolTR_MoyMin_G_Step5;		//Tolerance tension rayon gauche en kg		#FR51
        public ushort FR_TolTR_MoyMax_G_Step1;		//Tolerance tension rayon gauche en kg		#FR52
        public ushort FR_TolTR_MoyMax_G_Step2;		//Tolerance tension rayon gauche en kg		#FR53
        public ushort FR_TolTR_MoyMax_G_Step3;		//Tolerance tension rayon gauche en kg		#FR54
        public ushort FR_TolTR_MoyMax_G_Step4;		//Tolerance tension rayon gauche en kg		#FR55
        public ushort FR_TolTR_MoyMax_G_Step5;		//Tolerance tension rayon gauche en kg		#FR56
        public ushort FR_TolTR_RMin_D_Step1;			//Tolerance tension rayon droit en kg		#FR57
        public ushort FR_TolTR_RMin_D_Step2;			//Tolerance tension rayon droit en kg		#FR58
        public ushort FR_TolTR_RMin_D_Step3;			//Tolerance tension rayon droit en kg		#FR59
        public ushort FR_TolTR_RMin_D_Step4;			//Tolerance tension rayon droit en kg		#FR60
        public ushort FR_TolTR_RMin_D_Step5;			//Tolerance tension rayon droit en kg		#FR61
        public ushort FR_TolTR_RMax_D_Step1;			//Tolerance tension rayon droit en kg		#FR62
        public ushort FR_TolTR_RMax_D_Step2;			//Tolerance tension rayon droit en kg		#FR63
        public ushort FR_TolTR_RMax_D_Step3;			//Tolerance tension rayon droit en kg		#FR64
        public ushort FR_TolTR_RMax_D_Step4;			//Tolerance tension rayon droit en kg		#FR65
        public ushort FR_TolTR_RMax_D_Step5;			//Tolerance tension rayon droit en kg		#FR66
        public ushort FR_TolTR_MoyMin_D_Step1;		//Tolerance tension rayon droit en kg		#FR67
        public ushort FR_TolTR_MoyMin_D_Step2;		//Tolerance tension rayon droit en kg		#FR68
        public ushort FR_TolTR_MoyMin_D_Step3;		//Tolerance tension rayon droit en kg		#FR69
        public ushort FR_TolTR_MoyMin_D_Step4;		//Tolerance tension rayon droit en kg		#FR70
        public ushort FR_TolTR_MoyMin_D_Step5;		//Tolerance tension rayon droit en kg		#FR71
        public ushort FR_TolTR_MoyMax_D_Step1;		//Tolerance tension rayon droit en kg		#FR72
        public ushort FR_TolTR_MoyMax_D_Step2;		//Tolerance tension rayon droit en kg		#FR73
        public ushort FR_TolTR_MoyMax_D_Step3;		//Tolerance tension rayon droit en kg		#FR74
        public ushort FR_TolTR_MoyMax_D_Step4;		//Tolerance tension rayon droit en kg		#FR75
        public ushort FR_TolTR_MoyMax_D_Step5;		//Tolerance tension rayon droit en kg		#FR76
        public ushort FR_CAS_Pression_Step1;		//Pression CAS en kg						#FR77
        public ushort FR_CAS_Pression_Step2;		//Pression CAS en kg						#FR78
        public ushort FR_CAS_Pression_Step3;		//Pression CAS en kg						#FR79
        public ushort FR_CAS_Pression_Step4;		//Pression CAS en kg						#FR80
        public ushort FR_CAS_Pression_Step5;		//Pression CAS en kg						#FR81
        public ushort FR_CAS_NB_de_tour_Step1;		//Distance a faire avec la CAS				#FR82
        public ushort FR_CAS_NB_de_tour_Step2;		//Distance a faire avec la CAS				#FR83
        public ushort FR_CAS_NB_de_tour_Step3;		//Distance a faire avec la CAS				#FR84
        public ushort FR_CAS_NB_de_tour_Step4;		//Distance a faire avec la CAS				#FR85
        public ushort FR_CAS_NB_de_tour_Step5;		//Distance a faire avec la CAS				#FR86
        public ushort FR_Seuil_Star_0;		//Temps de seuil en seconde					#FR87
        public ushort FR_Seuil_Star_1;		//Temps de seuil en seconde					#FR88
        public ushort FR_Seuil_Star_2;		//Temps de seuil en seconde					#FR89
        public ushort FR_Seuil_Star_3;		//Temps de seuil en seconde					#FR90
        public ushort FR_Autor_Modif_recette;		//Modification modification recette			#FR91
        public ushort FR_Pair_ID;		//Id										#FR92
        public ushort FR_Favorite;		//Favorite									#FR93
        public ushort FR_Autor_Teach_Perimeter;		//Autorisation apprentissage perimetre		#FR94
        public ushort FR_Autor_Teach_Offset;		//Autorisation apprentissage offset			#FR95
        public ushort FR_Nb_cycle_Cas;      //											#FR96
        public ushort FR_Nb_Tour_CAS;       //			
        public ushort FR_Nb_CAS_entree;     //			
        public ushort FR_Nb_CAS_sortie;		//							

        public ushort FS_BP_Validate;		//Touche Validate 0=False 1 =True		#FS07			
        public ushort FS_Selecteur_FR;		//Sélecteur fiche roue					#FS09

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string FS_String_Name;	//Nom fiche roue						#FS10

        public ushort FS_AV_AR;		//0=Roue Avant, 1= Roue Arrière			#FS11
        public ushort FS_circ;		//Modulo circonference					#FS12
        public float FS_Pos_Broche;		//Position broche						#FS13
        public float FS_Off7_Deport;		//Correction du déport					#FS14
        public ushort FS_DS_Num;		//Data spoke Num						#FS15

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string FS_DS_Name;	//Data spoke_Name						#FS16

        public ushort FS_DS_Nb_Rayon;		//Nb rayon								#FS17

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string FS_DS_Date;	//Date de la calibration				#FS18

        public ushort FS_Type_Roue;		//0=PF, 1=PE, 2=AsymetriquePF, 3=AsymétriquePE		#FS19
        public float FS_Off7_Volontaire;		//Off7 volontaire						#FS20
        public ushort FS_Used;		//Roue active							#FS21
        public float FS_ToleranceVoile_Step1;		//Tolerance en mm						#FS22
        public float FS_ToleranceVoile_Step2;		//Tolerance en mm						#FS23
        public float FS_ToleranceVoile_Step3;		//Tolerance en mm						#FS24
        public float FS_ToleranceVoile_Step4;		//Tolerance en mm						#FS25
        public float FS_ToleranceVoile_Step5;		//Tolerance en mm						#FS26
        public float FS_ToleranceSaut_Step1;		//Tolerance en mm						#FS27
        public float FS_ToleranceSaut_Step2;		//Tolerance en mm						#FS28
        public float FS_ToleranceSaut_Step3;		//Tolerance en mm						#FS29
        public float FS_ToleranceSaut_Step4;		//Tolerance en mm						#FS30
        public float FS_ToleranceSaut_Step5;		//Tolerance en mm						#FS31
        public float FS_ToleranceDeport_Step1;		//Tolerance en mm						#FS32
        public float FS_ToleranceDeport_Step2;		//Tolerance en mm						#FS33
        public float FS_ToleranceDeport_Step3;		//Tolerance en mm						#FS34
        public float FS_ToleranceDeport_Step4;		//Tolerance en mm						#FS35
        public float FS_ToleranceDeport_Step5;		//Tolerance en mm						#FS36
        public ushort FS_TolTR_RMin_G_Step1;		//Tolerance tension rayon gauche en kg		#FS37
        public ushort FS_TolTR_RMin_G_Step2;		//Tolerance tension rayon gauche en kg		#FS38
        public ushort FS_TolTR_RMin_G_Step3;		//Tolerance tension rayon gauche en kg		#FS39
        public ushort FS_TolTR_RMin_G_Step4;		//Tolerance tension rayon gauche en kg		#FS40
        public ushort FS_TolTR_RMin_G_Step5;		//Tolerance tension rayon gauche en kg		#FS41
        public ushort FS_TolTR_RMax_G_Step1;		//Tolerance tension rayon gauche en kg		#FS42
        public ushort FS_TolTR_RMax_G_Step2;		//Tolerance tension rayon gauche en kg		#FS43
        public ushort FS_TolTR_RMax_G_Step3;		//Tolerance tension rayon gauche en kg		#FS44
        public ushort FS_TolTR_RMax_G_Step4;		//Tolerance tension rayon gauche en kg		#FS45
        public ushort FS_TolTR_RMax_G_Step5;		//Tolerance tension rayon gauche en kg		#FS46
        public ushort FS_TolTR_MoyMin_G_Step1;		//Tolerance tension rayon gauche en kg		#FS47
        public ushort FS_TolTR_MoyMin_G_Step2;		//Tolerance tension rayon gauche en kg		#FS48
        public ushort FS_TolTR_MoyMin_G_Step3;		//Tolerance tension rayon gauche en kg		#FS49
        public ushort FS_TolTR_MoyMin_G_Step4;		//Tolerance tension rayon gauche en kg		#FS50
        public ushort FS_TolTR_MoyMin_G_Step5;		//Tolerance tension rayon gauche en kg		#FS51
        public ushort FS_TolTR_MoyMax_G_Step1;		//Tolerance tension rayon gauche en kg		#FS52
        public ushort FS_TolTR_MoyMax_G_Step2;		//Tolerance tension rayon gauche en kg		#FS53
        public ushort FS_TolTR_MoyMax_G_Step3;		//Tolerance tension rayon gauche en kg		#FS54
        public ushort FS_TolTR_MoyMax_G_Step4;		//Tolerance tension rayon gauche en kg		#FS55
        public ushort FS_TolTR_MoyMax_G_Step5;		//Tolerance tension rayon gauche en kg		#FS56
        public ushort FS_TolTR_RMin_D_Step1;			//Tolerance tension rayon droit en kg		#FS57
        public ushort FS_TolTR_RMin_D_Step2;			//Tolerance tension rayon droit en kg		#FS58
        public ushort FS_TolTR_RMin_D_Step3;			//Tolerance tension rayon droit en kg		#FS59
        public ushort FS_TolTR_RMin_D_Step4;			//Tolerance tension rayon droit en kg		#FS60
        public ushort FS_TolTR_RMin_D_Step5;			//Tolerance tension rayon droit en kg		#FS61
        public ushort FS_TolTR_RMax_D_Step1;			//Tolerance tension rayon droit en kg		#FS62
        public ushort FS_TolTR_RMax_D_Step2;			//Tolerance tension rayon droit en kg		#FS63
        public ushort FS_TolTR_RMax_D_Step3;			//Tolerance tension rayon droit en kg		#FS64
        public ushort FS_TolTR_RMax_D_Step4;			//Tolerance tension rayon droit en kg		#FS65
        public ushort FS_TolTR_RMax_D_Step5;			//Tolerance tension rayon droit en kg		#FS66
        public ushort FS_TolTR_MoyMin_D_Step1;		//Tolerance tension rayon droit en kg		#FS67
        public ushort FS_TolTR_MoyMin_D_Step2;		//Tolerance tension rayon droit en kg		#FS68
        public ushort FS_TolTR_MoyMin_D_Step3;		//Tolerance tension rayon droit en kg		#FS69
        public ushort FS_TolTR_MoyMin_D_Step4;		//Tolerance tension rayon droit en kg		#FS70
        public ushort FS_TolTR_MoyMin_D_Step5;		//Tolerance tension rayon droit en kg		#FS71
        public ushort FS_TolTR_MoyMax_D_Step1;		//Tolerance tension rayon droit en kg		#FS72
        public ushort FS_TolTR_MoyMax_D_Step2;		//Tolerance tension rayon droit en kg		#FS73
        public ushort FS_TolTR_MoyMax_D_Step3;		//Tolerance tension rayon droit en kg		#FS74
        public ushort FS_TolTR_MoyMax_D_Step4;		//Tolerance tension rayon droit en kg		#FS75
        public ushort FS_TolTR_MoyMax_D_Step5;		//Tolerance tension rayon droit en kg		#FS76
        public ushort FS_CAS_Pression_Step1;		//Pression CAS en kg						#FS77
        public ushort FS_CAS_Pression_Step2;		//Pression CAS en kg						#FS78
        public ushort FS_CAS_Pression_Step3;		//Pression CAS en kg						#FS79
        public ushort FS_CAS_Pression_Step4;		//Pression CAS en kg						#FS80
        public ushort FS_CAS_Pression_Step5;		//Pression CAS en kg						#FS81
        public float FS_CAS_NB_de_tour_Step1;		//Distance a faire avec la CAS				#FS82
        public float FS_CAS_NB_de_tour_Step2;		//Distance a faire avec la CAS				#FS83
        public float FS_CAS_NB_de_tour_Step3;		//Distance a faire avec la CAS				#FS84
        public float FS_CAS_NB_de_tour_Step4;		//Distance a faire avec la CAS				#FS85
        public float FS_CAS_NB_de_tour_Step5;		//Distance a faire avec la CAS				#FS86
        public ushort FS_Seuil_Star_0;		//Temps de seuil en seconde					#FS87
        public ushort FS_Seuil_Star_1;		//Temps de seuil en seconde					#FS88
        public ushort FS_Seuil_Star_2;		//Temps de seuil en seconde					#FS89
        public ushort FS_Seuil_Star_3;		//Temps de seuil en seconde					#FS90
        public ushort FS_Autor_Modif_recette;		//Modification modification recette			#FS91
        public ushort FS_Pair_ID;		//Id										#FS92
        public ushort FS_Favorite;		//Favorite									#FS93
        public ushort FS_Autor_Teach_Perimeter;		//Autorisation apprentissage perimetre		#FS94
        public ushort FS_Autor_Teach_Offset;		//Autorisation apprentissage offset			#FS95
        public ushort FS_Nb_cycle_Cas;      //											#FS96
        public ushort FS_Nb_Tour_CAS;       //			
        public ushort FS_Nb_CAS_entree;     //			
        public ushort FS_Nb_CAS_sortie;

        /*==========================================================================*/
        /*			#User setting													*/
        /*==========================================================================*/
        public ushort AutoZOOM;		//Toggle 0 à 1			#USG1
        public ushort Full_fit;		//Toggle 0 à 1			#USG2

        //Data
        public ushort L_SI;		//0=SI 1=Imperial			#USD1
        public ushort T_SI;		//0=Kg 1=lb  2=mm 3=In.lb			#USD2
        public ushort Real_Time_Tension;		//			#USD3
        public ushort Real_Time;		//			#USD4
        public ushort Tension_Array_Data;		//			#USD5
        public ushort Tension_LR;		//			#USD6

        public ushort Calcul_Off7;		    //Check Box 0=Unused 1=Used			#USC1
        public ushort Jointure_Invisible;   //0=Kg 1=lb  2=mm 3=In.lb	        #USC2
        public ushort Errase_Scratchs;		//Check Box 0=Unused 1=Used		    #USC3
        public ushort Auto_Refresh;		    //mode auto refresh	                #USC4
        public ushort Teacher;		        //Check Box 0=Unused 1=Used		    #USP1
        public ushort Celebrate;		    //Check Box 0=Unused 1=Used			#USP2
        public ushort Per_parts;		    //Check Box 0=Unused 1=Used			#USP3
        public ushort Per_user;		        //Check Box 0=Unused 1=Used		    #USP4

        public ushort Auto_Print_Wheel_OK;		//Check Box 0=Unused 1=Used			#USPr1
        public ushort Barcode;		            //Check Box 0=Unused 1=Used			#USPr2
        public ushort Name;		                //Check Box 0=Unused 1=Used			#USPr3
        public ushort Date_Hour;		        //Check Box 0=Unused 1=Used			#USPr4
        public ushort Final_value;		        //Check Box 0=Unused 1=Used			#USPr5
        public ushort TorqueMin;		        //Check Box 0=Unused 1=Used			#USPr6
        public ushort TorqueMax;                //Check Box 0=Unused 1=Used			#USPr7
        public ushort ZD420;
        public ushort IDManual;                 //Check Box 0=Unused 1=Used			#USPr8
        public ushort Mitutoyo;
        public ushort Mahr;
        public float Load_Cell;                 //-10000=not connected -10001=disconnected
        /*
SpokeDataNameList01		:	STRING(20)	;		//	#LDS01
SpokeDataNumber01		:	UINT	;		//	0
SpokeDataNameList02		:	String(20)	;		//	#LDS02
SpokeDataNumber02		:	UINT	;		//	0
SpokeDataNameList03		:	String(20)	;		//	#LDS03
SpokeDataNumber03		:	UINT	;		//	0
SpokeDataNameList04		:	String(20)	;		//	#LDS04
SpokeDataNumber04		:	UINT	;		//	0
SpokeDataNameList05		:	String(20)	;		//	#LDS05
SpokeDataNumber05		:	UINT	;		//	0
SpokeDataNameList06		:	String(20)	;		//	#LDS06
SpokeDataNumber06		:	UINT	;		//	0
SpokeDataNameList07		:	String(20)	;		//	#LDS07
SpokeDataNumber07		:	UINT	;		//	0
SpokeDataNameList08		:	String(20)	;		//	#LDS08
SpokeDataNumber08		:	UINT	;		//	0
SpokeDataNameList09		:	String(20)	;		//	#LDS09
SpokeDataNumber09		:	UINT	;		//	0
SpokeDataNameList10		:	String(20)	;		//	#LDS10
SpokeDataNumber10		:	UINT	;		//	0
SpokeDataNameList11		:	String(20)	;		//	#LDS11
SpokeDataNumber11		:	UINT	;		//	0
SpokeDataSelector		:	UINT	;		//	#LDS12
BP_CalibrationInProgress		:	UINT	;		//	#LDS20
NB_Mesure		:	UINT	;		//	#LDS21
Profil_CalibRayon_Tensiometre		:	Array[1..2000] of Real	;		//	#LDS22
Profil_CalibRayon_Peson		:	Array[1..2000] of Real	;		//	#LDS23
RegrPoliOrdre0		:	Real	;		//	#LDS24
RegrPoliOrdre1		:	Real	;		//	#LDS25
RegrPoliOrdre2		:	Real	;		//	#LDS26
BP_Calculate		:	UINT	;		//	#LDS27
RegrPoliError		:	Real	;		//	#LDS28
SpokeDataName_Crs		:	String(20)	;		//	#LDS29
SpokeDataDate_Crs		:	String(20)	;		//	#LDS30
RegrPoliOrdre0_Crs		:	Real	;		//	#LDS31
RegrPoliOrdre1_Crs		:	Real	;		//	#LDS32
RegrPoliOrdre2_Crs		:	Real	;		//	#LDS33
CalibRayon_BP_Compute		:	UINT	;		//	#LDS34
CalibRayon_BP_Validate		:	UINT	;		//	#LDS35
Comparator		:	Array[1..200] of Real	;		//	0
Peson		:	Array[1..200) of Real	;		//	0
         */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name00;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name01;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name02;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name03;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name04;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name05;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name06;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name07;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name08;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name09;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name10;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name11;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name12;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name13;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name14;		//User ID Name

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ID_Name15;		//User ID Name


        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamLabel00;    //Parameter Label

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamLabel01;    //Parameter Label

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamLabel02;    //Parameter Label

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamLabel03;    //Parameter Label

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamLabel04;    //Parameter Label


        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamData00;     //Parameter Data

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamData01;     //Parameter Data

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamData02;     //Parameter Data

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamData03;     //Parameter Data

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ParamData04;     //Parameter Data

        public ushort Teach_Perim_Start;	//Button Record Unpress=0 Press=1	
        public ushort Teach_Perim_Stop;	//Button Record Unpress=0 Press=1	
        public ushort Teach_Perim_Circ;	//mm	
        public ushort Teach_Perim_Valid;	//Button Record Unpress=0 Press=1	
        public ushort Teach_Perim_Cancel;	//Button Record Unpress=0 Press=1	

        //Clamp				

        public float Ecartement_Broche;	//Ecartement broche en mm 3.3f	
        public ushort BP_Serrage;	//Button Serrage	
        public ushort BP_Desserrage;	//Button desserrage	
        public ushort Teach_Clamp_Valid;	//Button Record Unpress=0 Press=1	
        public ushort Teach_Clamp_Cancel;	//Button Record Unpress=0 Press=1	

        //Off7				

        public ushort OffsetRecord1;	//Button Record Unpress=0 Press=1	
        public ushort OffsetRecord2;	//Button Record Unpress=0 Press=1	
        public float OffsetRecordValue1;	//Value 3.2f	
        public float OffsetRecordValue2;	//Value 3.2f	
        public ushort OffsetCompute;	//Button Compute	
        public float OffsetActuel;	//Offset actuel 	
        public float OffsetCalcul;	//Offset calculé	
        public float OffsetCorrection;	//Offset Corrigé	
        public ushort Offset_Valid;	//Offset BP Valid	
        public ushort Offset_Cancel;	//Offset BP Cancel	
        public ushort Offset_State;	//Offset state

        //(*==========================================================================*)			
        //(*			#Manual mode													*)
        //(*==========================================================================*)		

        public ushort BPManual_Saut_UP;	//Bouton manuel saut monter #MM1
        public ushort BPManual_Saut_Down;	//Bouton manuel saut Descendre #MM2
        public ushort BPManual_Voile_UP;	//Bouton manuel Voile en position mesure #MM3
        public ushort BPManual_Voile_Down;	//Bouton voile désengager #MM4
        public ushort BPManual_Bridage;	// #MM5
        public ushort BPManual_Debridage;	// #MM6
        public ushort BPManual_CAS_Right;	// #MM7
        public ushort BPManual_CAS_Left;	// #MM8
        public ushort BPManual_Center;  // #MM9
        
        public ushort BPManual_Serrage;	// #MM10
        public ushort BPManual_Desserage;   // #MM11


        //Item27
        public int ModeMesureTension;
    }
}
