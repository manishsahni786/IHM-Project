using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MireWpf.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DUT_AP
    {
        public ushort PWD_Admin;		//Password
        //Affichage bandeau
        //Item 1- Bouton de chargement roue
        public short Autor_FR;		//Autorisation acces fiche roues

        //Item 3- Affichage du nom de la fiche roues en cours
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string Fiche_Roue_Name;  //Nom de la fiche roue en cours

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TrackID;	//Track ID

        //Item 4- Affichage du bouton roue arrière
        public short Mode_Roue_Arriere;	//Voyant choix fiche roue 0=Hide, 1=VB, 2=VG, 3=BV, 4=GV	

        //Bandeau gauche	
        //Item 8 - 	Affichage de l'état de production
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string Step_Production;	//Affichage de l'état de production
        public short Step_Visible;		//0=Hidden, 1= Showed

        //Item 9 - 	Visualisation valeur "voile roue"
        public float RoueVoile_Val;		//Valeur ecart roue 2 décimale
        public short RoueVoile_NOK;	//(Si 0=Etat initial, Si 1=Rouge car valeur non correcte)

        //Item 10 - Valeur ecart saut
        public float RoueSaut_Val;	//Visualisation valeur "Saut roue"
        public short RoueSaut_NOK;	//(Si 0=Etat initial, Si 1=Rouge car valeur non correcte)	

        //Item 11 - Valeur Déport	
        public float RoueDeport_Val;	//Visualisation valeur "Deport roue"
        public short RoueDeport_NOK;	//(Si 0=Etat initial, Si 1=Rouge car valeur non correcte)		

        //Item 12 - Affichage du model	
        public float Tension_Val; 	// Item12 Affichage 2 décimales
        public short Tension_NOK;		//0 = Transparent, 1= Vert, 2 rouge, 3 Jaune, 4 bleu clair,5 bleu foncée*)

        //Item 13 -	
        public short Ecrou_Gauche;	// 0 = Pas d'affichage, 1 = Rotation sens horaire, 2 = Rotation anti horaire
        public short Ecrou_Droit;	// 0 = Pas d'affichage, 1 = Rotation sens horaire, 2 = Rotation anti horaire

        //Item 14 -	
        public float MesureVoile_Val; 	// Valeur du voile mesuré
        public short MesureVoile_NOK;	//(Si 0=Etat initial, Si 1=Rouge car valeur non correcte)

        //Item 15 -		
        public float MesureSaut_Val; 	// Valeur du voile mesuré
        public short MesureSaut_NOK;	//(Si 0=Etat initial, Si 1=Rouge car valeur non correcte)	

        //Item 16 -		
        public short MesureCirc_Val;	// Valeur de la circonference

        //Item 17 -		
        public float Tension_Mes;	// Valeur de mesure du tensiomètre

        //Item 18 -	
        public ushort TpsCycle;	//Valeur de tems de cycle en seconde

        //Item 19 -	
        public ushort Star;	//Affiche un nombre d'étoile (de 0 à 3)

        //Item 20 -		
        public short MessagePhoto;	//Image d'aide au process

        //Item 23 -	
        public float RoueSTAB_Val;	//Valeur de stabilisation
        public short RoueSTAB_NOK;

        //Item 24 - 
        public short IdManualOption;
        public short MessagePopup;	//Demande l'ouverture d'une popup
        public short RequestTag;

        //Item 25 -		
        public float MesureDeport_Val; 	// Valeur du Déport mesuré
        public short MesureDeport_NOK;  //(Si 0=Etat initial, Si 1=Rouge car valeur non correcte)

        //Item 26 -	
        public short IDPopUpShow;  //Demande d'ouverture de la ID Popup

      
        /*==========================================================================*/
        /*			#MIRE															*/
        /*==========================================================================*/

        //Affichage de la mire
        /*Gestion de la mire*/
        public short Plot_X;	//#MIRE1 Coordonnée en X du plot
        public short Plot_Y;	//#MIRE2 Coordonée en Y du plot
        public short Valeur_Voile;	//#Mire3
        public short Valeur_Saut;	//#Mire4
        public short State;	//#Mire5 Si Valeur dans tolérance affichage en vert
        public short State_Voile;	//#Mire6 Si Valeur dans tolérance affichage en vert
        public short State_Saut;	//#Mire7 Si Valeur dans tolérance affichage en vert
        public float GradMaxVoile;	//#Mire8
        public float GradMaxSaut;	//#Mire9

        /*Positionnement du cadre de tolérance*/
        public short TolMvTL_X;	//#Mire10
        public short TolMvTL_Y;	//#Mire11
        public short TolMvBR_X;	//#Mire12
        public short TolMvBR_Y;	//#Mire13

        /*==========================================================================*/
        /*			#Courbe															*/
        /*==========================================================================*/
        /*Courbe d'acquision*/
        public short Nb_Acquisition;				//#Courbe1 Nb de point a scruter
        public short Num_Refresh;				//#Courbe2 Si valeur différente de last refresh raffraichissement de la courbe

        public int CurveCursor;				//#Courbe7 Valeur de 0 à 1000
        //0=Cursor en haut 1000=Cursor en bas						
        
        /*==========================================================================*/
        /*			#Tableau rayon													*/
        /*==========================================================================*/
        //Affichage du tableau de tension rayon
        public float Rayon_Min; //Rayon le moins tendu
        public float Rayon_Max; //Rayon le plus tendu
        public short RayonG_Moy_Color;              //Couleur de la case
        public short RayonD_Moy_Color;				//Couleur de la case
        public short Auto_Scroll;
        public float Rayon_Info0;
        public float Rayon_Info1;
        public float Rayon_Info2;
        public float Rayon_Info3;

        //Tableau
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public float[] Tension_Rayons; /*Valeur de tension rayon*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public ushort[] Rayons_color; /*Valeur de tension rayon*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public ushort[] TypeRayon; /*Valeur de type rayon*/

        public int iCompteurRoue; //Compteur de roue quotidien
    }
}
