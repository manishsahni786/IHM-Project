using System;
using System.Collections.ObjectModel;
using System.Windows;
using MireWpf.Models;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using System.Windows.Media;
using System.Linq;
using System.IO;
using System.Drawing.Printing;
//using System.Windows.Controls;


namespace MireWpf.ViewModels
{
    public class MireViewModel : BaseViewModel, IRegion
    {
        #region Tension Table Data Class
        public class Tension : ObservableCollection<Tension>
        {
            public int _index;
            public float _tensionRayon;
            public ushort _rayonColor;
            public ushort _typeRayon;
            public int _rowHeight;
            public int index { get; set; }
            public float tensionRayon
            {
                get { return _tensionRayon; }
                set
                {
                    _tensionRayon = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }
            public ushort rayonColor
            {
                get { return _rayonColor; }
                set
                {
                    _rayonColor = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }
            public ushort typeRayon
            {
                get { return _typeRayon; }
                set
                {
                    _typeRayon = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }
            public int rowHeight
            {
                get { return _rowHeight; }
                set
                {
                    _rowHeight = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(""));
                }
            }

            public Tension() { }
        }
        #endregion

        #region parameters
        public MainWindowViewModel _parent;
        public int _chartType;
        public int _chartTypeTension;
        public int _actualChart;
        public int _unitType;
        public int _showVoile;
        public int _showSaut;
        public int _showMinMax;
        public int _showPosition;
        public float[] TensionToPrint = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                          0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                          0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                          0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                          0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                          0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                          0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                          0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Pour impression


        private string _stepProduction;
        private int _stepVisible;
        private int _IdManualOption;
        private float _roueVoileVal;
        private int _roueVoileCol;
        private float _roueSautVal;
        private int _roueSautCol;
        private float _roueDeportVal;
        private int _roueDeportCol;
        private float _tensionVal;
        private int _tensionCol;
        private float _stabilizationVal;
        private int _stabilizationCol;
        private short _ecrouDroit;
        private short _ecrouGauche;
        private float _mesureVoile;
        private int _mesureVoileCol;
        private float _mesureSaut;
        private int _mesureSautCol;
        private short _mesureCirc;
        private float _tensionMes;
        private ushort _tpsCycle;
        private ushort _star;
        private float _rayonMin;
        private float _rayonMax;
        private short _RayonG_Moy_Color;
        private short _RayonD_Moy_Color;
        private int _messagePhoto;
        private float _mesureDeport;
        private float _MesureEcartement;
        private int _mesureDeportCol;
        private int _ddeIDPopUpShow;
        private short _modeautoscroll;
        private short _modeMesureTension;

        //graph parameters
        private double _gradMaxVoile;
        private double _gradMaxSaut;
        private double _gradVoile4;
        private double _gradVoile3;
        private double _gradVoile2;
        private double _gradVoile1;
        private double _gradSaut4;
        private double _gradSaut3;
        private double _gradSaut2;
        private double _gradSaut1;
        private double _recHeight;
        private double _recWidth;
        private Thickness _recMargin;
        private double _originX;
        private double _originY;
        private int _plotX = 319;
        private int _plotY = 239;
        private short _state;
        private short _voileState;
        private short _sautState;
        private Thickness _pointMargin;

        //block chart parameters
        private PointCollection _block_chart_voile_collection;
        private PointCollection _block_chart_saut_collection;
        private PointCollection _xy_chart_voile_collection;
        private PointCollection _xy_chart_saut_collection;
        private PointCollection _radial_chart_voile_collection;
        private PointCollection _radial_chart_saut_collection;
        private double _block_chart_height = 700*8/7;
        private double _xy_chart_height = 480*75/50+10;
        private double _xy_chart_width = 850*127/86;
        private ushort[] _typeRayonSpider;
        private float[] _tensionRayonSpider;
        private ushort[] _colorRayonSpider;
        private int _curveCursor;
        private Thickness _curveCursorBlock;
        private Thickness _curveCursorXYVoile;
        private Thickness _curveCursorXYSaut;
        private int _toleranceLineVoile;
        private int _toleranceLineSaut;
        private int _chart_voile_tol_minus;
        private int _chart_voile_tol_plus;
        private int _chart_saut_tol_minus;
        private int _chart_saut_tol_plus;
        private string _chart_voile_tol_minus_text;
        private string _chart_voile_tol_plus_text;
        private string _chart_saut_tol_minus_text;
        private string _chart_saut_tol_plus_text;
        private Thickness _block_chart_voile_min;
        private Thickness _block_chart_voile_max;
        private Thickness _block_chart_saut_min;
        private Thickness _block_chart_saut_max;
        private Thickness _xy_chart_voile_min;
        private Thickness _xy_chart_voile_max;
        private Thickness _xy_chart_saut_min;
        private Thickness _xy_chart_saut_max;
        private Thickness _radial_chart_voile_min;
        private Thickness _radial_chart_voile_max;
        private Thickness _radial_chart_saut_min;
        private Thickness _radial_chart_saut_max;
        private int _xCircVMin;
        private int _xCircVMax;
        private int _xCircSMin;
        private int _xCircSMax;
        private Point _radial_chart_cursor_point1;
        private Point _radial_chart_cursor_point2;
        private Point _radial_chart_cursor_point3;
        private Point _radial_chart_cursor_point4;

        private double _chartHeight = 480;
        private double _chartWidth = 640;
        private double _spiderchartHeight = 480;
        private double _spiderchartWidth = 640;
        private int tensionRayonRowCountG = 20;
        private int tensionRayonRowCountD = 20;
        private bool _showIDPopUp = false;
        private string _IDValue = "";
        private bool _showShutPopUp = false;
        private bool _showSpiderChartPopUp = false;
        private int _ModeAutoScroll = 0;
        private float _Rayon_Info0;
        private float _Rayon_Info1;
        private float _Rayon_Info2;
        private float _Rayon_Info3;

        private Thickness _firstSpoke;
        private PointCollection _axes;
        private PointCollection _spiderGauche;
        private PointCollection _spiderDroite;
        private PointCollection _spiderSelector;
        private PointCollection _spiderTolerance;

        private int _selector = 1;
        private double _toleranceGaucheMin = 0;
        private double _toleranceGaucheMax = 0;
        private double _toleranceDroiteMin = 0;
        private double _toleranceDroiteMax = 0;

        private string _label1 = "";
        private string _label2 = "";
        private string _label3 = "";
        private string _label4 = "";
        private string _label5 = "";

        private string _data1 = "";
        private string _data2 = "";
        private string _data3 = "";
        private string _data4 = "";
        private string _data5 = "";

        private int _iCompteurRoue;

        #endregion
        private readonly Random random = new Random();

        #region fields
        public int ChartType
        {
            get { return _chartType; }
            set
            {
                _chartType = value;
                Console.WriteLine("ChartType : " + _chartType);
                OnPropertyChanged();
                RefreshActiveChart();
            }
        }

        public int ChartTypeTension
        {
            get { return _chartTypeTension; }
            set
            {
                _chartTypeTension = value;
                if (value == 1)
                {
                    ChartType = 3;
                    Properties.Settings.Default["SettingsChartType"] = 3;
                    Properties.Settings.Default.Save();
                }
                OnPropertyChanged();
            }
        }

        public int UnitType
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                OnPropertyChanged();
            }
        }

        public int ShowVoile
        {
            get { return _showVoile; }
            set
            {
                _showVoile = value;
                OnPropertyChanged();
            }
        }

        public int ShowSaut
        {
            get { return _showSaut; }
            set
            {
                _showSaut = value;
                OnPropertyChanged();
            }
        }

        public int ShowMinMax
        {
            get { return _showMinMax; }
            set
            {
                _showMinMax = value;
                OnPropertyChanged();
            }
        }

        public int ShowPosition
        {
            get { return _showPosition; }
            set
            {
                _showPosition = value;
                OnPropertyChanged();
            }
        }

        public int MessagePhoto
        {
            get { return _messagePhoto; }
            set
            {
            //    GC.Collect();
                _messagePhoto = value;
             //   Dispose();
                OnPropertyChanged();
            }
        }

        private string _messagePhotoSource;

        public string MessagePhotoSource
        {
            get { return _messagePhotoSource; }
            set
            {
                //    GC.Collect();
                _messagePhotoSource = value;
                //   Dispose();
                OnPropertyChanged();
            }
        }

        public string StepProduction
        {
            get { return _stepProduction; }
            set
            {
                _stepProduction = value;
                OnPropertyChanged();
            }
        }
        public int IdManualOption
        {
            get { return _IdManualOption; }
            set
            {
                _IdManualOption = value;
                OnPropertyChanged();
            }
        }

        public int StepVisible
        {
            get { return _stepVisible; }
            set
            {
                _stepVisible = value;
                OnPropertyChanged();
            }
        }

        public float RoueVoileVal
        {
            get { return _roueVoileVal; }
            set
            {
                _roueVoileVal = value;
                OnPropertyChanged();
            }
        }

        public float RoueSautVal
        {
            get { return _roueSautVal; }
            set
            {
                _roueSautVal = value;
                OnPropertyChanged();
            }
        }

        public float RoueDeportVal
        {
            get { return _roueDeportVal; }
            set
            {
                _roueDeportVal = value;
                OnPropertyChanged();
            }
        }

        public float TensionVal
        {
            get { return _tensionVal; }
            set
            {
                _tensionVal = value;
                OnPropertyChanged();
            }
        }

        public float StabilizationVal
        {
            get { return _stabilizationVal; }
            set
            {
                _stabilizationVal = value;
                OnPropertyChanged();
            }
        }

        public float MesureVoile
        {
            get { return _mesureVoile; }
            set
            {
                _mesureVoile = value;
                OnPropertyChanged();
            }
        }

        public float MesureSaut
        {
            get { return _mesureSaut; }
            set
            {
                _mesureSaut = value;
                OnPropertyChanged();
            }
        }

        public short EcrouDroit
        {
            get { return _ecrouDroit; }
            set
            {
                _ecrouDroit = value;
                OnPropertyChanged();
            }
        }

        public short EcrouGauche
        {
            get { return _ecrouGauche; }
            set
            {
                _ecrouGauche = value;
                OnPropertyChanged();
            }
        }
        public short ModeAutoScroll
        {
            get { return _modeautoscroll; }
            set
            {
                _modeautoscroll = value;
                OnPropertyChanged();
            }
        }
        public short ModeMesureTension
        {
            get { return _modeMesureTension; }
            set
            {
                _modeMesureTension = value;
                OnPropertyChanged();
            }
        }
        public float Rayon_Info0
        {
            get { return _Rayon_Info0; }
            set
            {
                _Rayon_Info0 = value;
                OnPropertyChanged();
            }
        }
        public float Rayon_Info1
        {
            get { return _Rayon_Info1; }
            set
            {
                _Rayon_Info1 = value;
                OnPropertyChanged();
            }
        }
        public float Rayon_Info2
        {
            get { return _Rayon_Info2; }
            set
            {
                _Rayon_Info2 = value;
                OnPropertyChanged();
            }
        }
        public float Rayon_Info3
        {
            get { return _Rayon_Info3; }
            set
            {
                _Rayon_Info3 = value;
                OnPropertyChanged();
            }
        }
        public short MesureCirc
        {
            get { return _mesureCirc; }
            set
            {
                _mesureCirc = value;
                OnPropertyChanged();
            }
        }

        public float TensionMes
        {
            get { return _tensionMes; }
            set
            {
                _tensionMes = value;
                OnPropertyChanged();
            }
        }

        public ushort TpsCycle
        {
            get { return _tpsCycle; }
            set
            {
                _tpsCycle = value;
                OnPropertyChanged();
            }
        }

        public ushort Star
        {
            get { return _star; }
            set
            {
                _star = value;
                OnPropertyChanged();
            }
        }

        public int RoueVoileCol
        {
            get { return _roueVoileCol; }
            set
            {
                _roueVoileCol = value;
                OnPropertyChanged();
            }
        }

        public int RoueSautCol
        {
            get { return _roueSautCol; }
            set
            {
                _roueSautCol = value;
                OnPropertyChanged();
            }
        }

        public int RoueDeportCol
        {
            get { return _roueDeportCol; }
            set
            {
                _roueDeportCol = value;
                OnPropertyChanged();
            }
        }

        public int TensionCol
        {
            get { return _tensionCol; }
            set
            {
                _tensionCol = value;
                OnPropertyChanged();
            }
        }

        public int StabilizationCol
        {
            get { return _stabilizationCol; }
            set
            {
                _stabilizationCol = value;
                OnPropertyChanged();
            }
        }

        public int MesureVoileCol
        {
            get { return _mesureVoileCol; }
            set
            {
                _mesureVoileCol = value;
                OnPropertyChanged();
            }
        }

        public int MesureSautCol
        {
            get { return _mesureSautCol; }
            set
            {
                _mesureSautCol = value;
                OnPropertyChanged();
            }
        }

        public float RayonMin
        {
            get { return _rayonMin; }
            set
            {
                _rayonMin = value;
                OnPropertyChanged();
            }
        }

        public float RayonMax
        {
            get { return _rayonMax; }
            set
            {
                _rayonMax = value;
                OnPropertyChanged();
            }
        }
        public short RayonG_Moy_Color
        {
            get { return _RayonG_Moy_Color; }
            set
            {
                _RayonG_Moy_Color = value;
                OnPropertyChanged();
            }
        }

        public short RayonD_Moy_Color
        {
            get { return _RayonD_Moy_Color; }
            set
            {
                _RayonD_Moy_Color = value;
                OnPropertyChanged();
            }
        }
        public float MesureDeport
        {
            get { return _mesureDeport; }
            set
            {
                _mesureDeport = value;
                OnPropertyChanged();
            }
        }
        public float MesureEcartement
        {
            get { return _MesureEcartement; }
            set
            {
                _MesureEcartement = value;
                OnPropertyChanged();
            }
        }
        public int MesureDeportCol
        {
            get { return _mesureDeportCol; }
            set
            {
                _mesureDeportCol = value;
                OnPropertyChanged();
            }
        }
        public int ddeIDPopUpShow
        {
            get { return _ddeIDPopUpShow; }
            set
            {
                _ddeIDPopUpShow = value;
                OnPropertyChanged();
            }
        }

        public bool ShowIDPopUp
        {
            get { return _showIDPopUp; }
            set
            {
                _showIDPopUp = value;
                if (value)
                    _parent.SetTwincatValue("PopupId", (short)4);
                else
                    _parent.SetTwincatValue("PopupId", (short)0);
                OnPropertyChanged();
            }
        }

        public string IDValue
        {
            get { return _IDValue; }
            set
            {
                _IDValue = value;
                _parent.SetTwincatValue("IDValue", value);
                OnPropertyChanged();
            }
        }

        public bool ShowShutPopUp
        {
            get { return _showShutPopUp; }
            set
            {
                _showShutPopUp = value;
                OnPropertyChanged();
            }
        }

        public bool ShowSpiderChartPopUp
        {
            get { return _showSpiderChartPopUp; }
            set
            {
                _showSpiderChartPopUp = value;
                OnPropertyChanged();
            }
        }

        public Thickness FirstSpoke
        {
            get { return _firstSpoke; }
            set
            {
                _firstSpoke = value;
                OnPropertyChanged();
            }
        }

        public PointCollection Axes
        {
            get { return _axes; }
            set
            {
                _axes = value;
                OnPropertyChanged();
            }
        }

        public PointCollection SpiderGauche
        {
            get { return _spiderGauche; }
            set
            {
                _spiderGauche = value;
                OnPropertyChanged();
            }
        }

        public PointCollection SpiderDroite
        {
            get { return _spiderDroite; }
            set
            {
                _spiderDroite = value;
                OnPropertyChanged();
            }
        }
        public PointCollection SpiderSelector
        {
            get { return _spiderSelector; }
            set
            {
                _spiderSelector = value;
                OnPropertyChanged();
            }
        }

        public PointCollection SpiderTolerance
        {
            get { return _spiderTolerance; }
            set
            {
                _spiderTolerance = value;
                OnPropertyChanged();
            }
        }

        public int Selector
        {
            get { return _selector; }
            set
            {
                _selector = value;
                OnPropertyChanged();
            }
        }

        public double ToleranceGaucheMin
        {
            get { return _toleranceGaucheMin; }
            set
            {
                _toleranceGaucheMin = value;
                OnPropertyChanged();
            }
        }

        public double ToleranceGaucheMax
        {
            get { return _toleranceGaucheMax; }
            set
            {
                _toleranceGaucheMax = value;
                OnPropertyChanged();
            }
        }

        public double ToleranceDroiteMin
        {
            get { return _toleranceDroiteMin; }
            set
            {
                _toleranceDroiteMin = value;
                OnPropertyChanged();
            }
        }

        public double ToleranceDroiteMax
        {
            get { return _toleranceDroiteMax; }
            set
            {
                _toleranceDroiteMax = value;
                OnPropertyChanged();
            }
        }

        public string Label1
        {
            get { return _label1; }
            set
            {
                _label1 = value;
                OnPropertyChanged();
            }
        }

        public string Label2
        {
            get { return _label2; }
            set
            {
                _label2 = value;
                OnPropertyChanged();
            }
        }

        public string Label3
        {
            get { return _label3; }
            set
            {
                _label3 = value;
                OnPropertyChanged();
            }
        }

        public string Label4
        {
            get { return _label4; }
            set
            {
                _label4 = value;
                OnPropertyChanged();
            }
        }

        public string Label5
        {
            get { return _label5; }
            set
            {
                _label5 = value;
                OnPropertyChanged();
            }
        }

        public string Data1
        {
            get { return _data1; }
            set
            {
                _data1 = value;
                OnPropertyChanged();
            }
        }

        public string Data2
        {
            get { return _data2; }
            set
            {
                _data2 = value;
                OnPropertyChanged();
            }
        }

        public string Data3
        {
            get { return _data3; }
            set
            {
                _data3 = value;
                OnPropertyChanged();
            }
        }

        public string Data4
        {
            get { return _data4; }
            set
            {
                _data4 = value;
                OnPropertyChanged();
            }
        }

        public string Data5
        {
            get { return _data5; }
            set
            {
                _data5 = value;
                OnPropertyChanged();
            }
        }

        public int CompteurRoue
        {
            get { return _iCompteurRoue; }
            set
            {
                _iCompteurRoue = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region graph fields

        public int PlotX
        {
            get { return _plotX; }
            set
            {
                _plotX = value;
                OnPropertyChanged();
            }
        }

        public int PlotY
        {
            get { return _plotY; }
            set
            {
                _plotY = value;
                OnPropertyChanged();
            }
        }

        public short State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        public short VoileState
        {
            get { return _voileState; }
            set
            {
                _voileState = value;
                OnPropertyChanged();
            }
        }

        public short SautState
        {
            get { return _sautState; }
            set
            {
                _sautState = value;
                OnPropertyChanged();
            }
        }

        public double RecHeight
        {
            get { return _recHeight; }
            set
            {
                _recHeight = value;
                OnPropertyChanged();
            }
        }

        public double RecWidth
        {
            get { return _recWidth; }
            set
            {
                _recWidth = value;
                OnPropertyChanged();
            }
        }

        public double ChartHeight
        {
            get { return _chartHeight; }
            set
            {
                _chartHeight = value;
                OriginY = _chartHeight / 2;
                OnPropertyChanged();
            }
        }
        public double SpiderChartHeight
        {
            get { return _spiderchartHeight; }
            set
            {
                _spiderchartHeight = value;
                OnPropertyChanged();
            }
        }
        public double SpiderChartWidth
        {
            get { return _spiderchartWidth; }
            set
            {
                _spiderchartWidth = value;
                OnPropertyChanged();
            }
        }
        public double OriginY
        {
            get { return _originY; }
            set
            {
                _originY = value;
                OnPropertyChanged();
            }
        }

        public double ChartWidth
        {
            get { return _chartWidth; }
            set
            {
                _chartWidth = value;
                OriginX = _chartWidth / 2;
                OnPropertyChanged();
            }
        }

        public double OriginX
        {
            get { return _originX; }
            set
            {
                _originX = value;
                OnPropertyChanged();
            }
        }

        public double GradMaxVoile
        {
            get { return _gradMaxVoile; }
            set
            {
                _gradMaxVoile = value;
                OnPropertyChanged();
            }
        }

        public double GradMaxSaut
        {
            get { return _gradMaxSaut; }
            set
            {
                _gradMaxSaut = value;
                OnPropertyChanged();
            }
        }

        public double GradVoile4
        {
            get { return _gradVoile4; }
            set
            {
                _gradVoile4 = value;
                OnPropertyChanged();
            }
        }

        public double GradVoile3
        {
            get { return _gradVoile3; }
            set
            {
                _gradVoile3 = value;
                OnPropertyChanged();
            }
        }

        public double GradVoile2
        {
            get { return _gradVoile2; }
            set
            {
                _gradVoile2 = value;
                OnPropertyChanged();
            }
        }

        public double GradVoile1
        {
            get { return _gradVoile1; }
            set
            {
                _gradVoile1 = value;
                OnPropertyChanged();
            }
        }

        public double GradSaut4
        {
            get { return _gradSaut4; }
            set
            {
                _gradSaut4 = value;
                OnPropertyChanged();
            }
        }

        public double GradSaut3
        {
            get { return _gradSaut3; }
            set
            {
                _gradSaut3 = value;
                OnPropertyChanged();
            }
        }

        public double GradSaut2
        {
            get { return _gradSaut2; }
            set
            {
                _gradSaut2 = value;
                OnPropertyChanged();
            }
        }

        public double GradSaut1
        {
            get { return _gradSaut1; }
            set
            {
                _gradSaut1 = value;
                OnPropertyChanged();
            }
        }

        public Thickness RecMargin
        {
            get { return _recMargin; }
            set
            {
                _recMargin = value;
                OnPropertyChanged();
            }
        }

        public Thickness PointMargin
        {
            get { return _pointMargin; }
            set
            {
                _pointMargin = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region chart fields
        public double Block_Chart_Height
        {
            get { return _block_chart_height; }
            set
            {
                _block_chart_height = value;
                OnPropertyChanged();
            }
        }
        public double XY_Chart_Height
        {
            get { return _xy_chart_height; }
            set
            {
                _xy_chart_height = value;
                OnPropertyChanged();
            }
        }
        public double XY_Chart_Width
        {
            get { return _xy_chart_width; }
            set
            {
                _xy_chart_width = value;
                OnPropertyChanged();
            }
        }

        public ushort[] TypeRayonSpider
        {
            get { return _typeRayonSpider; }
            set
            {
                _typeRayonSpider = value;
                OnPropertyChanged();
            }
        }

        public float[] TensionRayonSpider
        {
            get { return _tensionRayonSpider; }
            set
            {
                _tensionRayonSpider = value;
                OnPropertyChanged();
            }
        }
        public ushort[] ColorRayonSpider
        {
            get { return _colorRayonSpider; }
            set
            {
                _colorRayonSpider = value;

                OnPropertyChanged();
               
            }
        }

        public int CurveCursor
        {
            get { return _curveCursor; }
            set
            {
                _curveCursor = value;
                OnPropertyChanged();
                double top = _block_chart_height * value / 3000 - 10;
                double bottom = _block_chart_height - (top + 20);
                CurveCursorBlock = new Thickness(0, top, 10, bottom);

                double left = _xy_chart_width * value / 3000 - 10;
                double right = _xy_chart_width - (left + 20);
                CurveCursorXYSaut = new Thickness(left, 0, right + 10, 0);

                top = _xy_chart_height * value / 3000 - 10;
                bottom = _xy_chart_height - (top + 20);
                CurveCursorXYVoile = new Thickness(0, top, 0, bottom);

                double radialAngle = 262.8 - (value * 345.6 / 3000);
                double radianAngle1 = (radialAngle + 6) * Math.PI / 180;
                double radianAngle2 = (radialAngle - 6) * Math.PI / 180;                
                double sinAngle1 = Math.Sin(radianAngle1);
                double cosAngle1 = Math.Cos(radianAngle1);
                double sinAngle2 = Math.Sin(radianAngle2);
                double cosAngle2 = Math.Cos(radianAngle2);
                RadialChartCursorPoint1 = new Point(360 + 210 * cosAngle1, 360 - 210 * sinAngle1);
                RadialChartCursorPoint2 = new Point(360 + 210 * cosAngle2, 360 - 210 * sinAngle2);
                RadialChartCursorPoint3 = new Point(360 + 360 * cosAngle2, 360 - 360 * sinAngle2);
                RadialChartCursorPoint4 = new Point(360 + 360 * cosAngle1, 360 - 360 * sinAngle1);
            }
        }
        public Thickness CurveCursorBlock
        {
            get { return _curveCursorBlock; }
            set
            {
                _curveCursorBlock = value;
                OnPropertyChanged();
            }
        }
        public Thickness CurveCursorXYSaut
        {
            get { return _curveCursorXYSaut; }
            set
            {
                _curveCursorXYSaut = value;
                OnPropertyChanged();
            }
        }
        public Thickness CurveCursorXYVoile
        {
            get { return _curveCursorXYVoile; }
            set
            {
                _curveCursorXYVoile = value;
                OnPropertyChanged();
            }
        }
        public int ToleranceLineVoile
        {
            get { return _toleranceLineVoile; }
            set
            {
                _toleranceLineVoile = value;
                OnPropertyChanged();
                ChartVoileTolPlus = value / 4 + 75;
                ChartVoileTolMinus = value / -4 + 75;
            }
        }
        public int ToleranceLineSaut
        {
            get { return _toleranceLineSaut; }
            set
            {
                _toleranceLineSaut = value;
                OnPropertyChanged();
                ChartSautTolPlus = value / 4 + 75;
                ChartSautTolMinus = value / -4 + 75;
            }
        }
        public int ChartVoileTolMinus
        {
            get { return _chart_voile_tol_minus; }
            set
            {
                _chart_voile_tol_minus = value;
                OnPropertyChanged();
            }
        }
        public int ChartVoileTolPlus
        {
            get { return _chart_voile_tol_plus; }
            set
            {
                _chart_voile_tol_plus = value;
                OnPropertyChanged();
            }
        }
        public int ChartSautTolMinus
        {
            get { return _chart_saut_tol_minus; }
            set
            {
                _chart_saut_tol_minus = value;
                OnPropertyChanged();
            }
        }
        public int ChartSautTolPlus
        {
            get { return _chart_saut_tol_plus; }
            set
            {
                _chart_saut_tol_plus = value;
                OnPropertyChanged();
            }
        }
        public string ChartVoileTolMinusText
        {
            get { return _chart_voile_tol_minus_text; }
            set
            {
                _chart_voile_tol_minus_text = value;
                OnPropertyChanged();
            }
        }
        public string ChartVoileTolPlusText
        {
            get { return _chart_voile_tol_plus_text; }
            set
            {
                _chart_voile_tol_plus_text = value;
                OnPropertyChanged();
            }
        }
        public string ChartSautTolMinusText
        {
            get { return _chart_saut_tol_minus_text; }
            set
            {
                _chart_saut_tol_minus_text = value;
                OnPropertyChanged();
            }
        }
        public string ChartSautTolPlusText
        {
            get { return _chart_saut_tol_plus_text; }
            set
            {
                _chart_saut_tol_plus_text = value;
                OnPropertyChanged();
            }
        }
        public Thickness BlockChartVoileMin
        {
            get { return _block_chart_voile_min; }
            set
            {
                _block_chart_voile_min = value;
                OnPropertyChanged();
            }
        }
        public Thickness BlockChartVoileMax
        {
            get { return _block_chart_voile_max; }
            set
            {
                _block_chart_voile_max = value;
                OnPropertyChanged();
            }
        }
        public Thickness BlockChartSautMin
        {
            get { return _block_chart_saut_min; }
            set
            {
                _block_chart_saut_min = value;
                OnPropertyChanged();
            }
        }
        public Thickness BlockChartSautMax
        {
            get { return _block_chart_saut_max; }
            set
            {
                _block_chart_saut_max = value;
                OnPropertyChanged();
            }
        }
        public Thickness XYChartVoileMin
        {
            get { return _xy_chart_voile_min; }
            set
            {
                _xy_chart_voile_min = value;
                OnPropertyChanged();
            }
        }
        public Thickness XYChartVoileMax
        {
            get { return _xy_chart_voile_max; }
            set
            {
                _xy_chart_voile_max = value;
                OnPropertyChanged();
            }
        }
        public Thickness XYChartSautMin
        {
            get { return _xy_chart_saut_min; }
            set
            {
                _xy_chart_saut_min = value;
                OnPropertyChanged();
            }
        }
        public Thickness XYChartSautMax
        {
            get { return _xy_chart_saut_max; }
            set
            {
                _xy_chart_saut_max = value;
                OnPropertyChanged();
            }
        }
        public Thickness RadialChartVoileMin
        {
            get { return _radial_chart_voile_min; }
            set
            {
                _radial_chart_voile_min = value;
                OnPropertyChanged();
            }
        }
        public Thickness RadialChartVoileMax
        {
            get { return _radial_chart_voile_max; }
            set
            {
                _radial_chart_voile_max = value;
                OnPropertyChanged();
            }
        }
        public Thickness RadialChartSautMin
        {
            get { return _radial_chart_saut_min; }
            set
            {
                _radial_chart_saut_min = value;
                OnPropertyChanged();
            }
        }
        public Thickness RadialChartSautMax
        {
            get { return _radial_chart_saut_max; }
            set
            {
                _radial_chart_saut_max = value;
                OnPropertyChanged();
            }
        }
        public int XCircVMin
        {
            get { return _xCircVMin; }
            set
            {
                _xCircVMin = value;
                OnPropertyChanged();

                double top = _block_chart_height * value / 3000;
                double left = -5000;
                if (chartDataVoile.ContainsKey(value))
                    left = chartDataVoile[value] / 2;
                BlockChartVoileMin = new Thickness(left + 5, top - 5, 10, 0);

                top = _xy_chart_height * value / 3000;
                left = -5000;
                if (chartDataVoile.ContainsKey(value))
                    left = chartDataVoile[value] / 2;
                XYChartVoileMin = new Thickness(left + 10, top - 5, 10, 0);

                if (chartDataVoile.ContainsKey(value))
                {
                    double radian = 262.8 - (value * 345.6 / 3000);
                    double radius = 360 - (chartDataVoile[value] + 300) / 4;
                    double x = 350 + radius * Math.Cos(radian * Math.PI / 180);
                    double y = 350 - radius * Math.Sin(radian * Math.PI / 180);
                    RadialChartVoileMin = new Thickness(x, y, 0, 0);
                }
            }
        }
        public int XCircVMax
        {
            get { return _xCircVMax; }
            set
            {
                _xCircVMax = value;
                OnPropertyChanged();

                double top = _block_chart_height * value / 3000;
                double left = -5000;
                if (chartDataVoile.ContainsKey(value))
                    left = chartDataVoile[value] / 2;
                BlockChartVoileMax = new Thickness(left + 5, top - 5, 10, 0);

                top = _xy_chart_height * value / 3000;
                left = -5000;
                if (chartDataVoile.ContainsKey(value))
                    left = chartDataVoile[value] / 2;
                XYChartVoileMax = new Thickness(left + 10, top - 5, 10, 0);

                if (chartDataVoile.ContainsKey(value))
                {
                    double radian = 262.8 - (value * 345.6 / 3000);
                    double radius = 360 - (chartDataVoile[value] + 300) / 4;
                    double x = 350 + radius * Math.Cos(radian * Math.PI / 180);
                    double y = 350 - radius * Math.Sin(radian * Math.PI / 180);
                    RadialChartVoileMax = new Thickness(x, y, 0, 0);
                }
            }
        }
        public int XCircSMin
        {
            get { return _xCircSMin; }
            set
            {
                _xCircSMin = value;
                OnPropertyChanged();

                double top = _block_chart_height * value / 3000;
                double left = -5000;
                if (chartDataSaut.ContainsKey(value))
                    left = chartDataSaut[value] / 2;
                BlockChartSautMin = new Thickness(left + 5, top - 5, 10, 0);

                left = _xy_chart_width * value / 3000;
                top = -5000;
                if (chartDataSaut.ContainsKey(value))
                    top = 150 - (chartDataSaut[value] + 300) / 4;
                XYChartSautMin = new Thickness(left - 5, top - 5, 0, 150 - (top + 10));

                if (chartDataSaut.ContainsKey(value))
                {
                    double radian = 262.8 - (value * 345.6 / 3000);
                    double radius = 360 - (chartDataSaut[value] + 300) / 4;
                    double x = 350 + radius * Math.Cos(radian * Math.PI / 180);
                    double y = 350 - radius * Math.Sin(radian * Math.PI / 180);
                    RadialChartSautMin = new Thickness(x, y, 0, 0);
                }
            }
        }
        public int XCircSMax
        {
            get { return _xCircSMax; }
            set
            {
                _xCircSMax = value;
                OnPropertyChanged();

                double top = _block_chart_height * value / 3000;
                double left = -5000;
                if (chartDataSaut.ContainsKey(value))
                    left = chartDataSaut[value] / 2;
                BlockChartSautMax = new Thickness(left + 5, top - 5, 10, 0);

                left = _xy_chart_width * value / 3000;
                top = -5000;
                if (chartDataSaut.ContainsKey(value))
                    top = 150 - (chartDataSaut[value] + 300) / 4;
                XYChartSautMax = new Thickness(left - 5, top - 5, 0, 150 - (top + 10));

                if (chartDataSaut.ContainsKey(value))
                {
                    double radian = 262.8 - (value * 345.6 / 3000);
                    double radius = 360 - (chartDataSaut[value] + 300) / 4;
                    double x = 350 + radius * Math.Cos(radian * Math.PI / 180);
                    double y = 350 - radius * Math.Sin(radian * Math.PI / 180);
                    RadialChartSautMax = new Thickness(x, y, 0, 0);
                }
            }
        }
        public PointCollection BlockChartVoileCollection
        {
            get { return _block_chart_voile_collection; }
            set
            {
                _block_chart_voile_collection = value;
                OnPropertyChanged();
            }
        }
        public PointCollection BlockChartSautCollection
        {
            get { return _block_chart_saut_collection; }
            set
            {
                _block_chart_saut_collection = value;
                OnPropertyChanged();
            }
        }
        public PointCollection XYChartVoileCollection
        {
            get { return _xy_chart_voile_collection; }
            set
            {
                _xy_chart_voile_collection = value;
                OnPropertyChanged();
            }
        }
        public PointCollection XYChartSautCollection
        {
            get { return _xy_chart_saut_collection; }
            set
            {
                _xy_chart_saut_collection = value;
                OnPropertyChanged();
            }
        }
        public PointCollection RadialChartVoileCollection
        {
            get { return _radial_chart_voile_collection; }
            set
            {
                _radial_chart_voile_collection = value;
                OnPropertyChanged();
            }
        }
        public PointCollection RadialChartSautCollection
        {
            get { return _radial_chart_saut_collection; }
            set
            {
                _radial_chart_saut_collection = value;
                OnPropertyChanged();
            }
        }
        public Point RadialChartCursorPoint1
        {
            get { return _radial_chart_cursor_point1; }
            set
            {
                _radial_chart_cursor_point1 = value;
                OnPropertyChanged();
            }
        }
        public Point RadialChartCursorPoint2
        {
            get { return _radial_chart_cursor_point2; }
            set
            {
                _radial_chart_cursor_point2 = value;
                OnPropertyChanged();
            }
        }
        public Point RadialChartCursorPoint3
        {
            get { return _radial_chart_cursor_point3; }
            set
            {
                _radial_chart_cursor_point3 = value;
                OnPropertyChanged();
            }
        }
        public Point RadialChartCursorPoint4
        {
            get { return _radial_chart_cursor_point4; }
            set
            {
                _radial_chart_cursor_point4 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands
        public ICommand ModifyAutoScroll { get; set; }
        private void OnModifyAutoScroll()
        {
           // ModeAutoScroll = (ModeAutoScroll + 1) % 2;
            _parent.SetTwincatValue("BPManual_Bridage", (short)1);
        }
        public ICommand ModifyTensionCommand { get; set; }
        private void OnModifyTensionCommand(string parameter)
        {
            _parent.SetSelecteurRayon(parameter);
        }

        public ICommand ModifyMesureTension { get; set; }
        private void OnModifyMesureTension(string parameter)
        {
            if (ModeMesureTension == 2)
            {
                ModeMesureTension = 0;
            }
            else
            {
                ModeMesureTension++;
            }
            _parent.SetTwincatValue("ModeMesureTension", ModeMesureTension);

        }

        public ICommand Tension1SelectionChangeCommand { get; set; }
        private void OnTension1SelectionChangeCommand(int? index)
        {
            _parent.SetSelecteurRayon((index.Value + 1).ToString());

        }

        public ICommand Tension2SelectionChangeCommand { get; set; }
        private void OnTension2SelectionChangeCommand(int? index)
        {
            _parent.SetSelecteurRayon((index.Value + 100 + 1).ToString());
         
        }

        public ICommand PrintDataSheetCommand { get; set; }
        private void OnPrintDataSheetCommand()
        {
            _parent.SetPrintDataSheet();
        }

        public ICommand PrintIDPopUpCommand { get; set; }
        private void OnPrintIDPopUpCommand()
        {
            if (ShowSpiderChartPopUp == false)
            {
                 ShowIDPopUp = true;

            }
        }

        public ICommand IDPopUpOkCommand { get; set; }
        private void OnIDPopUpOkCommand()
        {
            //_parent.SetIDValue(IDValue);
            OnPrintDataSheetCommand();
            //impression
            ShowIDPopUp = false;
   
            _parent.SetTwincatValue("ID_BP_OK", (short)1);
            
                
        }

        public ICommand IDPopUpCancelCommand { get; set; }
        private void OnIDPopUpCancelCommand()
        {
            ShowIDPopUp = false;
            _parent.SetTwincatValue("ID_BP_Cancel", (short)1);
        }

        public ICommand PrintShutPopUpCommand { get; set; }
        private void OnPrintShutPopUpCommand()
        {
            ShowShutPopUp = true;
        }

        public ICommand ShutPopUpOkCommand { get; set; }
        private void OnShutPopUpOkCommand()
        {
            _parent.Shutdown();
        }

        public ICommand ShutPopUpCancelCommand { get; set; }
        private void OnShutPopUpCancelCommand()
        {
            ShowShutPopUp = false;
        }

        public ICommand ShowChartTypeTensionPopUpCommand { get; set; }
        private void OnShowChartTypeTensionPopUpCommand()
        {
            if (ShowSpiderChartPopUp == false)
            {
                //_actualChart = ChartType;
                //System.Console.WriteLine("TensionChart On : {0:HH:mm:ss.fff}", System.DateTime.Now);
                //ChartTypeTension = 1;
                ShowSpiderChartPopUp = true;
                RefreshTensionChart();
            } else if (ShowSpiderChartPopUp == true)
            {
                //System.Console.WriteLine("TensionChart Off : {0:HH:mm:ss.fff}", System.DateTime.Now);
                //ChartTypeTension = 0;
                //ChartType = _actualChart;
                //Properties.Settings.Default["SettingsChartType"] = _actualChart;
                //Properties.Settings.Default.Save();
                ShowSpiderChartPopUp = false;
            }
            
        }

        public ICommand SpiderChartPopUpCancelCommand { get; set; }
        public void OnSpiderChartPopUpCancelCommand()
        {
            ShowSpiderChartPopUp = false;
        }

        #endregion

        public ObservableCollection<Tension> CellTensionRayon1 { get; set; }
        public ObservableCollection<Tension> CellTensionRayon2 { get; set; }
        Dictionary<int, double> chartDataVoile = new Dictionary<int, double>();
        Dictionary<int, double> chartDataSaut = new Dictionary<int, double>();
        private StreamReader streamToPrint;
        private System.Drawing.Font printFont;

        public MireViewModel()
        {
            ModifyTensionCommand = new DelegateCommand<string>(OnModifyTensionCommand);
            ModifyMesureTension = new DelegateCommand<string>(OnModifyMesureTension);
            Tension1SelectionChangeCommand = new DelegateCommand<int?>(OnTension1SelectionChangeCommand);
            Tension2SelectionChangeCommand = new DelegateCommand<int?>(OnTension2SelectionChangeCommand);
            PrintDataSheetCommand = new DelegateCommand(OnPrintDataSheetCommand);

            PrintIDPopUpCommand = new DelegateCommand(OnPrintIDPopUpCommand);
            IDPopUpOkCommand = new DelegateCommand(OnIDPopUpOkCommand);
            IDPopUpCancelCommand = new DelegateCommand(OnIDPopUpCancelCommand);

            PrintShutPopUpCommand = new DelegateCommand(OnPrintShutPopUpCommand);
            ShutPopUpOkCommand = new DelegateCommand(OnShutPopUpOkCommand);
            ShutPopUpCancelCommand = new DelegateCommand(OnShutPopUpCancelCommand);

            ShowChartTypeTensionPopUpCommand = new DelegateCommand(OnShowChartTypeTensionPopUpCommand);
            SpiderChartPopUpCancelCommand = new DelegateCommand(OnSpiderChartPopUpCancelCommand);

            CellTensionRayon1 = new ObservableCollection<Tension>();
            CellTensionRayon2 = new ObservableCollection<Tension>();
            
            #region BlockChart and XYChart tempdata            
            //Random rnd = new Random(DateTime.Now.Millisecond);
            //double lastValue1 = rnd.Next(600) - 300;
            //double lastValue2 = rnd.Next(600) - 300;
            //double lastValue3 = rnd.Next(600) - 300;
            //double lastValue4 = rnd.Next(600) - 300;
            //for (int i = 0; i < 3000; i++)
            //{
            //    chartDataVoile[i] = lastValue1;
            //    if (rnd.Next() % 2 == 0)
            //        lastValue1++;
            //    else
            //        lastValue1--;

            //    chartDataSaut[i] = lastValue2;
            //    if (rnd.Next() % 2 == 0)
            //        lastValue2++;
            //    else
            //        lastValue2--;
            //}
            #endregion

            RefreshLayout();

           for (int i = 0; i < tensionRayonRowCountG; i++)
            {

                CellTensionRayon1.Add(new Tension()
                {
                     //index = i + 1,
                    tensionRayon = 0,
                    rayonColor = 0,
                    typeRayon = 0,
                    rowHeight = 33
                }); 
            }
            for (int i = 0; i < tensionRayonRowCountD; i++)
            {
                CellTensionRayon2.Add(new Tension()
                {
                    // index = i + tensionRayonRowCount + 1,
                    tensionRayon = 0,
                    rayonColor = 0,
                    typeRayon = 0,
                    rowHeight = 33
                });
            }
        }

        public void Dispose()   ///test sur la surcharge de l'appli
        {
            // Dispose of unmanaged resources.
            Dispose();
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public void RefreshActiveChart()
        {
            if (ChartType == 0)
                RefreshBlockChart();
            else if (ChartType == 1)
                RefreshXYChart();
            else if (ChartType == 2)
                RefreshRadarChart();
            else
                RefreshTensionChart();
        }

        public void RefreshBlockChart()
        {
            double blockUnitY = Block_Chart_Height / 3000;
            PointCollection PointCollectionBlockVoile = new PointCollection();
            PointCollection PointCollectionBlockSaut = new PointCollection();

            var orderedVoile = chartDataVoile.OrderBy(p => p.Key).ToList();
            foreach (KeyValuePair<int, double> key in orderedVoile)
            {
                double top = key.Key * blockUnitY;
                double blockVoile = (key.Value + 300) / 4;
                PointCollectionBlockVoile.Add(new Point(blockVoile, top));
            }
            var orderedSaut = chartDataSaut.OrderBy(p => p.Key).ToList();
            foreach (KeyValuePair<int, double> key in orderedSaut)
            {
                double top = key.Key * blockUnitY;
                double blockSaut = (key.Value + 300) / 4;
                PointCollectionBlockSaut.Add(new Point(blockSaut, top));
            }
            BlockChartVoileCollection = PointCollectionBlockVoile;
            BlockChartSautCollection = PointCollectionBlockSaut;
        }

        public void RefreshXYChart()
        {
            double xyY = XY_Chart_Height / 3000;
            double xyW = XY_Chart_Width / 3000;
            PointCollection PointCollectionXYVoile = new PointCollection();
            PointCollection PointCollectionXYSaut = new PointCollection();

            var orderedVoile = chartDataVoile.OrderBy(p => p.Key).ToList();
            foreach (KeyValuePair<int, double> key in orderedVoile)
            {
                double top = key.Key * xyY;
                double xyVoile = (key.Value + 300) / 4;
                PointCollectionXYVoile.Add(new Point(xyVoile, top));
            }
            var orderedSaut = chartDataSaut.OrderBy(p => p.Key).ToList();
            foreach (KeyValuePair<int, double> key in orderedSaut)
            {
                double left = key.Key * xyW;
                double xySaut = 150 - (key.Value + 300) / 4;
                PointCollectionXYSaut.Add(new Point(left, xySaut));
            }
            XYChartVoileCollection = PointCollectionXYVoile;
            XYChartSautCollection = PointCollectionXYSaut;
        }

        public void RefreshRadarChart()
        {
            PointCollection PointCollectionRadialVoile = new PointCollection();
            PointCollection PointCollectionRadialSaut = new PointCollection();

            var orderedVoile = chartDataVoile.OrderBy(p => p.Key).ToList();
            foreach (KeyValuePair<int, double> key in orderedVoile)
            {
                double radian = 262.8 - (key.Key * 345.6 / 3000);
                double radius = 360 - (key.Value + 300) / 4;
                double x = 360 + radius * Math.Cos(radian * Math.PI / 180);
                double y = 360 - radius * Math.Sin(radian * Math.PI / 180);
                PointCollectionRadialVoile.Add(new Point(x, y));
            }
            var orderedSaut = chartDataSaut.OrderBy(p => p.Key).ToList();
            foreach (KeyValuePair<int, double> key in orderedSaut)
            {
                double radian = 262.8 - (key.Key * 345.6 / 3000);
                double radius = 360 - (key.Value + 300) / 4;
                double x = 360 + radius * Math.Cos(radian * Math.PI / 180);
                double y = 360 - radius * Math.Sin(radian * Math.PI / 180);
                PointCollectionRadialSaut.Add(new Point(x, y));
            }
            RadialChartVoileCollection = PointCollectionRadialVoile;
            RadialChartSautCollection = PointCollectionRadialSaut;
        }

        public void RefreshTensionChart()
        {
            //On cherche le centre (Looking for centre)
            PointCollection lesAxes = new PointCollection();
            PointCollection lesSpiderGauche = new PointCollection();
            PointCollection lesSpiderDroite = new PointCollection();
            PointCollection lesSpiderSelector = new PointCollection();
            PointCollection lesSpiderTolerance = new PointCollection();
            double LargeurConteneur = _spiderchartWidth;
            double HauteurConteneur = _spiderchartHeight;
            double refX = LargeurConteneur / 2;
            double refY = HauteurConteneur / 2;

            //Constante pour calcul de l'angle en fonction du nombre de rayon (Constant for calculating the angle according to the number of rays)
            double nbTotalRayon = CellTensionRayon1.Count + CellTensionRayon2.Count;
            double radius = 0;
            //Console.WriteLine("Local spider chart X "+_spiderchartWidth);
            //Console.WriteLine("Public spider chart Y "+SpiderChartHeight);
            //Console.WriteLine("Origine " + refX +" , "+refY);
            //Console.WriteLine("Public  chart Height "+ChartHeight);
            //Console.WriteLine("info affichage spider " + ChartType);
            if (nbTotalRayon > 0)
            {
                radius = 2 * Math.PI / nbTotalRayon;
            }

            //Definition taille du graphique (Graphic size definition)
            double dimMin;
            if (LargeurConteneur < HauteurConteneur)
            {
                dimMin = LargeurConteneur;
            } else
            {
                dimMin = HauteurConteneur;
            }

            double tailleTrait = dimMin * 0.8 / 2;
          

            for (int i = 1; i <= nbTotalRayon; i++)
            {
                double angle = Math.PI/2 - radius * i;
                double x = refX + tailleTrait * Math.Cos(angle);
                double y = refY - tailleTrait * Math.Sin(angle);
                lesAxes.Add(new Point(x, y));
                lesAxes.Add(new Point(refX, refY));
                if (i == 1)
                {
                    FirstSpoke = new Thickness(x, y-50, 0, 0);
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //affichage spider rayon (spider ray display)
            double xG0 = 0;
            double xD0 = 0;
            double yG0 = 0;
            double yD0 = 0;
            double cptG = 0;
            double cptD = 0;
            double ValTension = 0;    //VALEUR TENSION EN UNITEE UTILISATEUR (VOLTAGE VALUE IN USER UNITS)
            double ValTensionMAE = 0; //VALEUR TENSION EN PIXEL (VOLTAGE VALUE IN PIXEL)
            double ValTensionMax = 0;
            double TolMaxG = 0;
            double TolMinG = 0;
            double TolMaxD = 0;
            double TolMinD = 0;
            int Color = 0;

            //Recherche de la valeur max (Finding the max value)
            for (int i = 0; i <= nbTotalRayon-1; i++)
            {
                ValTension = TensionRayonSpider[i];
                if (ValTension >= ValTensionMax)
                {
                    ValTensionMax = ValTension;
                }
                Color = ColorRayonSpider[i];
                 if (Color == 3)
                   {
                     Selector = i;
                   }
            }

         
                if (ToleranceGaucheMax > ValTensionMax)
                {
                    ValTensionMax = ToleranceGaucheMax;
                }
            
            
                if (ToleranceDroiteMax > ValTensionMax)
                {
                    ValTensionMax = ToleranceDroiteMax;
                }
            

            for (int i = 0; i <= nbTotalRayon-1; i++)
            {
                double angle = Math.PI / 2 - radius * i - radius;
                ValTension = TensionRayonSpider[i];
                ValTensionMAE = ValTension * tailleTrait / ValTensionMax*0.9;

                double x = refX + ValTensionMAE * Math.Cos(angle);
                double y = refY - ValTensionMAE * Math.Sin(angle);
                if (TypeRayonSpider[i] == 0)
                {
                    cptG++;
                    if (cptG == 1)
                    {
                        xG0 = x;
                        yG0 = y;
                    }

                    lesSpiderGauche.Add(new Point(x, y));
                    TolMaxG = ToleranceGaucheMax * tailleTrait / ValTensionMax * 0.9;
                    TolMinG = ToleranceGaucheMin * tailleTrait / ValTensionMax * 0.9;
                    

                    //Console.WriteLine("ValTensionMax : " + ValTensionMax);
                }
                else
                {
                    cptD++;
                    if (cptD == 1)
                    {
                        xD0 = x;
                        yD0 = y;
                    }

                    lesSpiderDroite.Add(new Point(x, y));
                    TolMaxD = ToleranceDroiteMax * tailleTrait / ValTensionMax * 0.9;
                    TolMinD = ToleranceDroiteMin * tailleTrait / ValTensionMax * 0.9;
                   
                    
                }
            }
            //Cas du dernier point pour reboucler le cercle (Case of the last point to close the circle)
            lesSpiderGauche.Add(new Point(xG0, yG0));
            lesSpiderDroite.Add(new Point(xD0, yD0));

            //Console.WriteLine(ToleranceGaucheMin);
            //Console.WriteLine(ToleranceGaucheMax);
            //Console.WriteLine(ToleranceDroiteMin);
            //Console.WriteLine(ToleranceDroiteMax);
            //Console.WriteLine(ValTensionMax);

            double XTolMax = 0;
            double YTolMax = 0;
            double XTolMin = 0;
            double YTolMin = 0;

            //Affichage du selecteur (Selector display)
            if (Selector >= 0)
            {
                double angle = Math.PI / 2 - radius * Selector - radius;
                double Xselector = refX + tailleTrait * 1.1 * Math.Cos(angle);
                double Yselector = refY - tailleTrait * 1.1 * Math.Sin(angle);

                lesSpiderSelector.Add(new Point(Xselector, Yselector));
                lesSpiderSelector.Add(new Point(refX, refY));
                //Console.WriteLine("Selecteur " + Selector);

                if (TypeRayonSpider[Selector] == 0)
                {
                    XTolMax = refX + TolMaxG * Math.Cos(angle);
                    YTolMax = refY - TolMaxG * Math.Sin(angle);
                    XTolMin = refX + TolMinG * Math.Cos(angle);
                    YTolMin = refY - TolMinG * Math.Sin(angle);
                    //Console.WriteLine("TolMin : " + TolMin);
                    //Console.WriteLine("Tolmax : " + TolMax);
                } else
                {
                    XTolMax = refX + TolMaxD * Math.Cos(angle);
                    YTolMax = refY - TolMaxD * Math.Sin(angle);
                    XTolMin = refX + TolMinD * Math.Cos(angle);
                    YTolMin = refY - TolMinD * Math.Sin(angle);
                    //Console.WriteLine("TolMin : " + TolMin);
                    //Console.WriteLine("Tolmax : " + TolMax);
                }
                //Console.WriteLine(XTolMin);
                //Console.WriteLine(YTolMin);
                //Console.WriteLine(XTolMax);
                //Console.WriteLine(YTolMax);

                lesSpiderTolerance.Add(new Point(XTolMax, YTolMax));
                lesSpiderTolerance.Add(new Point(XTolMin, YTolMin));
                //Console.WriteLine("XTolMin : " + XTolMin + " | YTolMin : " + YTolMin);
                //Console.WriteLine("XTolMax : " + XTolMax + " | YTolMax : " + YTolMax);
            }

            Axes = lesAxes;
            SpiderGauche = lesSpiderGauche;
            SpiderDroite = lesSpiderDroite;
            SpiderSelector = lesSpiderSelector;
            SpiderTolerance = lesSpiderTolerance;
        }

        public List<double> GenerateRandomDataSet(int nmbrOfPoints)
        {
            Console.WriteLine("Début appel GenerateRandomDataSet(int nmbrOfPoints) : {0:HH:mm:ss.fff}", DateTime.Now);
            var pts = new List<double>(nmbrOfPoints);
            for (var i = 0; i < nmbrOfPoints; i++)
            {
                pts.Add(random.Next(49, 145));
            }
            return pts;
            Console.WriteLine("  Fin appel GenerateRandomDataSet(int nmbrOfPoints) : {0:HH:mm:ss.fff}", DateTime.Now);
        }

        public void RefreshLayout()
        {
            int chartType = 0, showVoile = 1, showSaut = 1, showMinMax = 1, showPosition = 1, unitType = 0;
            int.TryParse(Properties.Settings.Default["SettingsChartType"].ToString(), out chartType);
            ChartType = chartType;
            int.TryParse(Properties.Settings.Default["SettingsUnitType"].ToString(), out unitType);
            UnitType = unitType;
            int.TryParse(Properties.Settings.Default["SettingsShowVoile"].ToString(), out showVoile);
            ShowVoile = showVoile;
            int.TryParse(Properties.Settings.Default["SettingsShowSaut"].ToString(), out showSaut);
            ShowSaut = showSaut;
            int.TryParse(Properties.Settings.Default["SettingsShowMinMax"].ToString(), out showMinMax);
            ShowMinMax = showMinMax;
            int.TryParse(Properties.Settings.Default["SettingsShowPosition"].ToString(), out showPosition);
            ShowPosition = showPosition;
        }


        public string ZPLLabelMaker(int iLine, string Data)
        {
            String sFS = "^FS";
            String sLine = iLine.ToString();
            return " ^FO20," + sLine + "^FD" + Data + sFS;
        }
        private void OnPrint()
        {
            Views.UserSettingsView userSettingsView = new Views.UserSettingsView();

            string[] tabVarImpression = new string[60];
            string DataQRCode = "";
            int NbSpoke = CellTensionRayon1.Count + CellTensionRayon2.Count;

            string sMasqueChoisie;

            if (userSettingsView.cbChoixMasque.SelectedIndex > -1)
            {
                sMasqueChoisie = userSettingsView.cbChoixMasque.SelectedValue.ToString();
            }
            else
            {
                sMasqueChoisie = "TestImpressionFinale.prn";
            }
            //On recupere le chemin complet du masque d'impression (We retrieve the full path of the print mask)
            string sPathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string sPathMask = sPathDesktop.Insert(sPathDesktop.Length, "\\PrintMask\\" + sMasqueChoisie);

            //Copier l'intégralité du fichier pour le réecrire à la fin (Copy the entire file to overwrite it at the end)
            string sMasque = File.ReadAllText(sPathMask);
            string sCopieMasque = sMasque;

            //Remplissage de tableau de valeurs pour l'impression (Filling in table of values ​​for printing)
            try
            {
                tabVarImpression[0] = "Number : " + _parent.TrackID;
                DataQRCode = DataQRCode + _parent.TrackID + ";";
            }
            catch (Exception)
            { tabVarImpression[0] = "##"; }

            try
            {
                tabVarImpression[1] = "Operator : " + _parent.UserName;
                DataQRCode = DataQRCode + _parent.UserName + ";";
            }
            catch (Exception)
            { tabVarImpression[1] = "##"; }

            try
            {
                tabVarImpression[2] = "Date : " + DateTime.Now.ToString();
                DataQRCode = DataQRCode + DateTime.Now.ToString() + ";";
            }
            catch (Exception)
            { tabVarImpression[2] = "##"; }

            try
            {
                tabVarImpression[3] = "Side to side : " + RoueVoileVal.ToString("00.00");
                DataQRCode = DataQRCode + RoueVoileVal.ToString("00.00") + ";";
            }
            catch (Exception)
            { tabVarImpression[3] = "##"; }

            try
            {
                tabVarImpression[4] = "Up & Down : " + RoueSautVal.ToString("00.00");
                DataQRCode = DataQRCode + RoueSautVal.ToString("00.00") + ";";
            }
            catch (Exception)
            { tabVarImpression[4] = "##"; }

            try
            {
                tabVarImpression[5] = "Offset : " + RoueDeportVal.ToString("00.00");
                DataQRCode = DataQRCode + RoueDeportVal.ToString("00.00") + ";";
            }
            catch (Exception)
            { tabVarImpression[5] = "##"; }

            try
            {
                tabVarImpression[6] = "Spoke left min : " + Rayon_Info0.ToString("00.000");
                DataQRCode = DataQRCode + Rayon_Info0.ToString("00.000") + ";";
            }
            catch (Exception)
            { tabVarImpression[6] = "##"; }

            try
            {
                tabVarImpression[7] = "Spoke left max : " + Rayon_Info1.ToString("00.000");
                DataQRCode = DataQRCode + Rayon_Info1.ToString("00.000") + ";";
            }
            catch (Exception)
            { tabVarImpression[7] = "##"; }

            try
            {
                tabVarImpression[8] = "Spoke left average : " + RayonMin.ToString("00.000");
                DataQRCode = DataQRCode + RayonMin.ToString("00.000") + ";";
            }
            catch (Exception)
            { tabVarImpression[8] = "##"; }

            try
            {
                tabVarImpression[9] = "Spoke right min : " + Rayon_Info2.ToString("00.000");
                DataQRCode = DataQRCode + Rayon_Info2.ToString("00.000") + ";";
            }
            catch (Exception)
            { tabVarImpression[9] = "##"; }

            try
            {
                tabVarImpression[10] = "Spoke right max : " + Rayon_Info3.ToString("00.000");
                DataQRCode = DataQRCode + Rayon_Info3.ToString("00.000") + ";";
            }
            catch (Exception)
            { tabVarImpression[10] = "##"; }

            try
            {
                tabVarImpression[11] = "Spoke right average : " + RayonMax.ToString("00.000");
                DataQRCode = DataQRCode + RayonMax.ToString("00.000") + ";";
            }
            catch (Exception)
            { tabVarImpression[11] = "##"; }

            try
            {
                tabVarImpression[52] = "Wheel name : " + _parent.FicheRoueName;
                DataQRCode = DataQRCode + _parent.FicheRoueName + ";";
            }
            catch (Exception)
            { tabVarImpression[52] = "##"; }

            for (int i = 0; i < NbSpoke; i++)
            {
                try
                {
                    tabVarImpression[12 + i] = (i + 1) + " : " + TensionToPrint[i].ToString("0.000");
                    DataQRCode = DataQRCode + TensionToPrint[i].ToString("0.000") + ";";
                }
                catch (Exception)
                { tabVarImpression[12 + i] = "##"; }
            }

            if (IdManualOption != 0)
            {
                {
                    tabVarImpression[53] = "ID Manual : " + IDValue;
                    DataQRCode = DataQRCode + IDValue + ";";
                }
            }

            if (Label1 != "")
            {
                tabVarImpression[54] = Label1 + " : " + Data1;
                DataQRCode = DataQRCode + Data1 + ";";
            }

            if (Label2 != "")
            {
                tabVarImpression[55] = Label2 + " : " + Data2;
                DataQRCode = DataQRCode + Data2 + ";";
            }

            if (Label3 != "")
            {
                tabVarImpression[56] = Label3 + " : " + Data3;
                DataQRCode = DataQRCode + Data3 + ";";
            }

            if (Label4 != "")
            {
                tabVarImpression[57] = Label4 + " : " + Data4;
                DataQRCode = DataQRCode + Data4 + ";";
            }

            if (Label5 != "")
            {
                tabVarImpression[58] = Label5 + " : " + Data5;
                DataQRCode = DataQRCode + Data5 + ";";
            }

            try
            { tabVarImpression[59] = DataQRCode; }
            catch (Exception)
            { tabVarImpression[59] = "##"; }


            //Boucle de lecture pour trouver chaque variable et les rempalcer par leur valeur
            string sMaskVariable;
            for (int i = 0; i < tabVarImpression.Length; i++)
            {
                if (i < 10)
                {
                    sMaskVariable = "#Var0" + i;
                }
                else
                {
                    sMaskVariable = "#Var" + i;
                }
                try
                { sMasque = sMasque.Replace(sMaskVariable, tabVarImpression[i]); }
                catch (Exception)
                { sMasque = sMasque.Replace(sMaskVariable, ""); }


            }
            File.WriteAllText(sPathMask, sMasque);

            //Sequence d'impression en fonction du masque choisit
            RawPrinterHelper.SendStringToPrinter("ZD420", sMasque);

            //Réecriture du texte original pour nouvelle utilisation
            File.WriteAllText(sPathMask, sCopieMasque);
        }
        public void Refresh(DUT_AP ap, DUT_PA pa)
        {
            #region TensionTable
            tensionRayonRowCountG = 0;
            tensionRayonRowCountD = 0;

            for (
                int i = 0; i < pa.FR_DS_Nb_Rayon; i++)
            {
                if (ap.TypeRayon[i] == 0) ++tensionRayonRowCountG;
                if (ap.TypeRayon[i] == 1) ++tensionRayonRowCountD;
                TensionToPrint[i] = ap.Tension_Rayons[i];
            }

            if ((tensionRayonRowCountG != CellTensionRayon1.Count) | (tensionRayonRowCountD != CellTensionRayon2.Count))
            {
                CellTensionRayon1.Clear();
                CellTensionRayon2.Clear();
                for (int i = 0; i < pa.FR_DS_Nb_Rayon; i++)
                {
                    if (ap.TypeRayon[i] == 0)
                    {
                        CellTensionRayon1.Add(new Tension()
                        {
                            index = i + 1,
                            tensionRayon = 0,
                            rayonColor = 0,
                            typeRayon = 0,
                            rowHeight = 660 / tensionRayonRowCountG
                        });
                    }
                    else
                    {
                        CellTensionRayon2.Add(new Tension()
                        {
                            index = i + 1,
                            tensionRayon = 0,
                            rayonColor = 0,
                            typeRayon = 0,
                            rowHeight = 660 / tensionRayonRowCountD
                        });
                    }
                }
            }
            int ig = 0;
            int id = 0;
            for (int i = 0; i < pa.FR_DS_Nb_Rayon; i++)
            {
                if (ap.TypeRayon[i] == 0)
                {
                    CellTensionRayon1[ig].index = i + 1;
                    CellTensionRayon1[ig].tensionRayon = ap.Tension_Rayons[i];
                    CellTensionRayon1[ig].rayonColor = ap.Rayons_color[i];
                    CellTensionRayon1[ig].typeRayon = ap.TypeRayon[i];
                    ig = ig + 1;
                }
                else
                {
                    CellTensionRayon2[id].index = i + 1;
                    CellTensionRayon2[id].tensionRayon = ap.Tension_Rayons[i];
                    CellTensionRayon2[id].rayonColor = ap.Rayons_color[i];
                    CellTensionRayon2[id].typeRayon = ap.TypeRayon[i];
                    id = id + 1;
                }
            }
            #endregion

            TypeRayonSpider = ap.TypeRayon;
            TensionRayonSpider = ap.Tension_Rayons;
            ColorRayonSpider = ap.Rayons_color;

            if (pa.T_SI < 2)
            {
                ToleranceGaucheMin = pa.FR_TolTR_RMin_G_Step5;
                ToleranceGaucheMax = pa.FR_TolTR_RMax_G_Step5;
                ToleranceDroiteMin = pa.FR_TolTR_RMin_D_Step5;
                ToleranceDroiteMax = pa.FR_TolTR_RMax_D_Step5;
            } else
            {
                ToleranceGaucheMin = (double) pa.FR_TolTR_RMin_G_Step5/100;
                ToleranceGaucheMax = (double) pa.FR_TolTR_RMax_G_Step5/100;
                ToleranceDroiteMin = (double) pa.FR_TolTR_RMin_D_Step5/100;
                ToleranceDroiteMax = (double) pa.FR_TolTR_RMax_D_Step5/100;
            }
            Console.WriteLine(pa.T_SI + "    " + ToleranceGaucheMin);
            Console.WriteLine(pa.T_SI + "    " + ToleranceGaucheMax);
            Console.WriteLine(pa.T_SI + "    " + ToleranceDroiteMin);
            Console.WriteLine(pa.T_SI + "    " + ToleranceDroiteMax);
            CurveCursor = ap.CurveCursor;
            IdManualOption = ap.IdManualOption;
            StepProduction = ap.Step_Production;
            StepVisible = ap.Step_Visible;
            RoueVoileVal = ap.RoueVoile_Val;
            RoueVoileCol = ap.RoueVoile_NOK;
            RoueSautVal = ap.RoueSaut_Val;
            RoueSautCol = ap.RoueSaut_NOK;
            RoueDeportVal = ap.RoueDeport_Val;
            RoueDeportCol = ap.RoueDeport_NOK;
            TensionVal = ap.Tension_Val;
            TensionCol = ap.Tension_NOK;
            StabilizationVal = ap.RoueSTAB_Val;
            StabilizationCol = ap.RoueSTAB_NOK;
            EcrouDroit = ap.Ecrou_Droit;
            EcrouGauche = ap.Ecrou_Gauche;
            MesureVoile = ap.MesureVoile_Val;
            MesureVoileCol = ap.MesureVoile_NOK;
            MesureSaut = ap.MesureSaut_Val;
            MesureSautCol = ap.MesureSaut_NOK;
            MesureCirc = ap.MesureCirc_Val;
            TensionMes = ap.Tension_Mes;
            TpsCycle = ap.TpsCycle;
            Star = ap.Star;
            Rayon_Info0 = ap.Rayon_Info0;
            Rayon_Info1 = ap.Rayon_Info1;
            Rayon_Info2 = ap.Rayon_Info2;
            Rayon_Info3 = ap.Rayon_Info3;
            RayonMin = ap.Rayon_Min;
            RayonMax = ap.Rayon_Max;
            RayonG_Moy_Color = ap.RayonG_Moy_Color;
            RayonD_Moy_Color = ap.RayonD_Moy_Color;
            MessagePhoto = ap.MessagePhoto;
            MesureDeport = ap.MesureDeport_Val;
            MesureDeportCol = ap.MesureDeport_NOK;
            ddeIDPopUpShow = ap.IDPopUpShow;

            MesureEcartement = pa.Ecartement_Broche;
            ModeAutoScroll = ap.Auto_Scroll;

            GradMaxVoile = ap.GradMaxVoile;
            GradMaxSaut = ap.GradMaxSaut;
            State = ap.State;
            VoileState = ap.State_Voile;
            SautState = ap.State_Saut;

            CompteurRoue = ap.iCompteurRoue;

            GradSaut1 = _gradMaxSaut / 5;
            GradSaut2 = _gradSaut1 * 2;
            GradSaut3 = _gradSaut1 * 3;
            GradSaut4 = _gradSaut1 * 4;

            GradVoile1 = _gradMaxVoile / 5;
            GradVoile2 = _gradVoile1 * 2;
            GradVoile3 = _gradVoile1 * 3;
            GradVoile4 = _gradVoile1 * 4;

            PlotX = (int)((ap.Plot_X * _chartWidth / 600.0) + _chartWidth / 2);
            PlotY = (int)(_chartHeight / 2 - (ap.Plot_Y * _chartHeight / 600.0));
            PointMargin = new Thickness(PlotX, PlotY, 0, 0);
            _parent.SetIDValue(IDValue);

            UnitType = pa.L_SI;

            var scaledMvBrX = ap.TolMvBR_X * _chartWidth / 600.0;
            var scaledMvBrY = ap.TolMvBR_Y * _chartHeight / 600.0;
            var scaledMvTlX = ap.TolMvTL_X * _chartWidth / 600.0;
            var scaledMvTlY = ap.TolMvTL_Y * _chartHeight / 600.0;

            RecWidth = Math.Abs(scaledMvBrX - scaledMvTlX);
            RecHeight = Math.Abs(scaledMvBrY - scaledMvTlY);

            int TolMvTlx = (int)(scaledMvTlX + _chartWidth / 2);
            int TolMvTly = (int)(_chartHeight / 2 - scaledMvTlY);

            RecMargin = new Thickness(TolMvTlx, TolMvTly, 0, 0);
           
            // if graph data has changed, refresh graph
            if (ap.Num_Refresh != pa.Num_Refresh)
            {
                var ihm_graph = _parent.GetGraphData();
                if (ihm_graph.HasValue)
                {
                    chartDataVoile.Clear();
                    chartDataSaut.Clear();
                    for (int i = 0; i < ap.Nb_Acquisition; i++ )
                    {
                        int x = ihm_graph.Value.xCirc[i];
                        int voile = ihm_graph.Value.yVoile[i];
                        int saut = ihm_graph.Value.ySaut[i];
                        chartDataVoile[x] = voile;
                        chartDataSaut[x] = saut;
                    }

                    ToleranceLineVoile = ihm_graph.Value.cTolVoile;
                    ToleranceLineSaut = ihm_graph.Value.cTolSaut;
                    XCircVMin = ihm_graph.Value.xCircVMIN;
                    XCircVMax = ihm_graph.Value.xCircVMAX;
                    XCircSMin = ihm_graph.Value.xCircSMIN;
                    XCircSMax = ihm_graph.Value.xCircSMAX;

                    ChartVoileTolPlusText = (((double)ihm_graph.Value.cValTolV) / 100).ToString("+0.00;-0.00;0.00");
                    ChartVoileTolMinusText = (((double)ihm_graph.Value.cValTolV) / -100).ToString("+0.00;-0.00;0.00");
                    ChartSautTolPlusText = (((double)ihm_graph.Value.cValTolS) / 100).ToString("+0.00;-0.00;0.00");
                    ChartSautTolMinusText = (((double)ihm_graph.Value.cValTolS) / -100).ToString("+0.00;-0.00;0.00");

                    RefreshActiveChart();
                    
                    _parent.SetTwincatValue("Num_Refresh", (int)ap.Num_Refresh);
                }
            }

            if(ap.RequestTag==1 &&  pa.Return_tag==0)
            {
                _parent.SetTwincatValue("Return_tag", (short)1);
                pa.Return_tag = ap.RequestTag;
                // ap.RequestTag = 0;
                OnPrint(); //RawPrinterHelper.SendStringToPrinter("ZD420", "^XA^FO60,60^GFA,1463,1463,19,gWFC::::gMFI0MFCgLF8I01LFCgKFEK07KFCgKF8K01KFCgKF001F800KFCgJFE01IF803JFCgJFC07IFE01JFCgJF80KF80JFCgJF03KFC0JFCgIFE07KFE07IFCgIFE0MF03IFCIFC01FE00PFC0FC1IFC07F83IFCIFC00FE00PFC0FC1IF807FC1IFCIFC00FC00PFC0F83IF007FC0IFCIFC00FC00PFC0F83FFC007FE0IFCIFC00FC00PFC0FF7FF8007FF0IFCIFC007C00FE07IF03FC0C1IFI07FF07FFCIFC007800F8I07C007CI07FCI07FF07FFCIFC007800FJ078003CI03F8I07FF07FFCIFC003800EJ07I01CI03FCI07FF87FFCIFC003I0CJ06J0CI01FCI07FF83FFCIFC003I0CJ04J0CI01FEI07FF83FFCIFC001I0803004030040201FFI07FF83FFCIFC001I080FC0407C040701FFI07FF83FFCIFC04J080FC040FE040F01FFI07FF83FFCIFC04008081FCI0IFC0F81FFI07FF83FFCIFC04008081FCI0IFC0F81FFI07FF87FFCIFC04008080FCI0FE0C0F81FFI07FF87FFCIFC06008080FC0407C040F81FFI07FF07FFCIFC060180807004038040F81FFI07FF07FFCIFC060180CJ04J0C0F81FFI07FF0IFCIFC070180CJ06J0C0F81FFI07FE0IFCIFC070380EJ07I01C0F81FFI07FE0IFCIFC070380FJ078003C0F81FFI07FC1IFCIFC070380F8I07C007C0F81FF003FFC1IFCIFE0F87C1FC060FF01FC0F83FF7JF83IFCgRF03IFCgJF03KFE07IFCgJF01KFC0JFCgJF80KF01JFCgJFC03IFC03JFCgJFE00IF007JFCgKF8L0KFCgKFCK03KFCgLFK0LFCgLFCI03LFCgMFC03MFCgWFC:::,:::gWFC::VF9gFCPFBF7EFE0DF26F98306F3NFCPFBE7C7CF9F66793FI67NFCPF9E7C79F9F647B3E7667NFCPF1C797BF9E6C3B3E670OFCPF1C7I3F806C9B060F1OFCOFE4A7033F9E6DC33E1F9OFCOFE426033FBE4DC37E9FBOFCOFEE64F9BFBECDE27ECF3OFCOFCEF5F98F3EC9F606CE7OFCOFDFF1FDC33ED9FE06E6PFCgWFC::^FS^FXQRcode^CFA,20^FO230,150^FDQRcode^FS^FO232,180^BQN,2,3^FDMM,AE177272340618B3110A0000^FS^FXDataMatrix^FO400,150^FDDataMatrix^FS^FO402,180^BXN,5,200^FDE177272340618B3110A0000^FS^FO100,300^FDData:E177272340618B3110A0000^FS^FXCarré1^FO50,50^GB500,300,6^FS^XZ");
            }
            
            if (ShowSpiderChartPopUp == true)
            {
                RefreshTensionChart();
            }

            Label1 = pa.ParamLabel00;
            Label2 = pa.ParamLabel01;
            Label3 = pa.ParamLabel02;
            Label4 = pa.ParamLabel03;
            Label5 = pa.ParamLabel04;

            Data1 = pa.ParamData00;
            Data2 = pa.ParamData01;
            Data3 = pa.ParamData02;
            Data4 = pa.ParamData03;
            Data5 = pa.ParamData04;


            if (ddeIDPopUpShow==1)
            {
                ShowIDPopUp = true;
            }
        }

        // The PrintPage event is raised for each page to be printed. OBLIGATOIRE
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Iterate over the file, printing each line.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, System.Drawing.Brushes.Black,
                   leftMargin, yPos, new System.Drawing.StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
    }
}
