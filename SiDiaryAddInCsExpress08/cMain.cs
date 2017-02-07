using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using SiDiaryNET;
namespace sinCsSample
{

    public class cMain : ISiDiary
    {

        public const string ADDIN_NAME = "C#ExpressSample";
        public const string ADDIN_DEVELOPER = "SINOVO Ltd. & Co. KG";
        public const string ADDIN_DESCRIPTION = "C# Demo AddIn for learning purposes.";

        public const bool ADDIN_IS_TREND_PROVIDER = true;
        //If ADDIN_IS_TREND_PROVIDER is set to True you need to code the Trend-Methods:
        //cMain.TrendNumberOfCategories
        //cMain.TrendGetRating
        //cMain.TrendShowSettings

        public const bool ADDIN_IS_STATISTIC_PROVIDER = true;
        //If ADDIN_IS_STATISTIC_PROVIDER is set to True you need to code the Statistic-Methods:
        //cMain.StatisticGetGraph
        //cMain.StatisticGraphName
        //cMain.StatisticNumberOfGraphs

        //
        //##########  ##########
        //##########  #        #
        //##########  #        #
        //##########  #        #
        //##########  ##########
        //
        //##########  ##########
        //##########  ##########
        //##########  ##########
        //##########  ##########              Sinovo Ltd. & Co.KG
        //##########  ##########              www.sinovo.de
        //============================================================================================
        //Modulename: cISiDiary
        //Remarks   :
        // Interface class which needs to be implemented for a valid SiDiary AddIn. SiDiary main
        // application will call several Events of this class:
        // Description as of July, 25th, 2008
        //
        //       AppInit()           will be called on AddIn startup
        //       AppDeInit()         will be called if AddIn will be unloaded
        //       AppEvent()          will be called if the application fires an event which the
        //                           AddIn has registered before
        //       AddInHide()         will be called if the AddIn has shown a window within
        //                           SiDiary which was closed now
        //       AddInMenuClicked()  will be called if the user clicks on a menu that the AddIn
        //                           has created before
        //       InfoDeveloper       Property that will tell SiDiary about the developer of this AddIn
        //       InfoDescription     Property that will tell SiDiary about the purpose of this AddIn
        //  opt. IsTrendProvider     Indicates that this AddIn will provide lines for trend analysis
        //  opt. TrendNumberOfCategories The number of categories provided by this AddIn
        //  opt. TrendGetRating()    Will be called to pickup the current results if the trend in the
        //                           main app is refreshed
        //  opt. TrendShowSettings() Will be called, if the Trend-Settings screen of this AddIn must
        //                           be shown
        //  opt. IsStatisticProvider Indicates that this AddIn will provide graphics for statistics
        //  opt. StatisticNumberOfGraphs The number of graphics provided by this AddIn
        //  opt. StatisticGraphName  Will be called to get a name of the graph provided by this AddIn
        //  opt. StatisticGetGraph() Will be called to pickup the current graphic if the statistic in the
        //                           main app is refreshed (change of filters etc.)
        //  opt. StatisticShowSettings() Will be called, if the Statistic-Settings screen of this AddIn
        //                           must be shown
        //
        //
        // Methods that can be called from SiDiary main application object (given in AppInit):
        //
        //      .EventRegister(genmEvent.All)
        //           Register for various events that your AddIn might be interested in
        //           no return value
        //
        //      .EventDeRegister(genmEvent.All)
        //           Deregister your events if you are not interested in them anymore.
        //           no return value
        //
        //      .CurrentLanguage()
        //           Return value: Will provide the country of the current language, like DE,EN,RU,...
        //
        //      .LanguageString([IDMessage])
        //           Parameters:   [IDMessage] 16bit Integer, In parameter
        //           Return value: String with the Message in current app language
        //                         Valid IDMessage parameters can be taken from the language files
        //                         i.e. SiDiaryEn.txt
        //
        //      .AddMenu([MenuName], [Text displayed in SiDiary Menu],[IDParentMenu], [Error]
        //           Parameters:   [MenuName] string, In parameter
        //                         [Text displayed in SiDiary Menu] string, In parameter
        //                         [IDParentMenu] 16bit Integer, In Parameter, see details below
        //                         [Error] string, Out-parameter if return value of method is False
        //           Return value: True/False. See [Error] if false.
        //           Valid IDMainMenu values: 1-Edit, 2-Diabetesprofile, 3-Statistics, 4-Extras,
        //           5-Tools. File- and About-Menus are invalid targets for AddIns!
        //           Use to add a specific Menu which will be displayed within SiDiary. A click event
        //           will be sent to your AddIn by AddInMenuClicked()
        //
        //      .RemoveMenu([MenuName], [IDParentMenu], [Error])
        //           Parameters:   [MenuName] same as in AddMenu()
        //                         [IDParentMenu] same as in AddMenu()
        //                         [Error] string, Out Parameter if return value of method is false
        //           Return value: True/False. See [Error] if false.
        //
        //      .ShowAddIn([hWnd of AddIn GUI], [Tab text])
        //           Parameters:   [hWnd of AddIn GUI] 32bit long, In Parameter, must specify a
        //                                             valid Window handle to a container the window
        //                                             to be shown in a new SiDiary tabbed window.
        //                                             SiDiary will reposition and resize your
        //                                             AddIn-window, you can track the resize Window
        //                                             message to re-arrange your GUI if the main
        //                                             application window is resized by the user.
        //                         [Tab Text] string, In Parameter, the label of the new tabbed window
        //           no return value
        //
        //      .RequestData([DateFrom], [DateUntil], [Data()], [NumberOfRecords], [Error])
        //           Parameters:   [DateFrom] string, In Parameter, must hold a valid DateTime value
        //                                    with current system locale settings (date format)
        //                         [DateUntil] string, In Prameter, appropriate to [DateFrom]. Both
        //                                     boundaries define the date range for the data that will
        //                                     be returned
        //                         [Data()] Array of cAddInDataType, Out Parameter, Array of the
        //                                  returned records
        //                         [NumberOfRecords] 16bit Integer, Out Parameter, Array [Data()] will
        //                                           go from 0...[NumberOfRecords]-1
        //                         [Error] string, Out Parameter if return value of Method is false
        //           Return value: True/False. See [Error] if false.
        //
        //      .SettingAddInGet([Key], [DefaultValue])
        //           Parameters:   [Key] string, In Parameter, specifies the key you want to load
        //                         [DefaultValue] string, In Prameter, Default value if Key is not set
        //           Return value: Value of the key or default value
        //           Settings are saved in AddIns.ini
        //           AddInGet/AddInSave are designed to store AddIn properties with a general scope
        //                              which apply to all patients
        //
        //      .SettingAddInSave([Key], [Value])
        //           Parameters:   [Key] string, In Parameter, specifies the key you want to save
        //                         [Value] string, In Prameter, value which will be saved for the key
        //           no return value
        //           Settings are saved in AddIns.ini
        //
        //      .SettingPatientGet([Key], [DefaultValue])
        //           Parameters:   [Key] string, In Parameter, specifies the key you want to load
        //                         [DefaultValue] string, In Prameter, Default value if Key is not set
        //           Return value: Value of the key or default value
        //           Settings are saved in SiDiaryProfile.dat
        //           PatientGet/PatientSave are designed to store AddIn properties for the patient
        //                                  currently opened within the main application
        //
        //      .SettingPatientSave([Key], [Value])
        //           Parameters:   [Key] string, In Parameter, specifies the key you want to save
        //                         [Value] string, In Prameter, value which will be saved for the key
        //           no return value
        //           Settings are saved in SiDiaryProfile.dat
        //
        //      .SettingApplicationGet([Section], [Key])
        //           Parameters:   [Section] string, In Parameter, specifies the section you want to
        //                                   read from
        //                         [Key] string, In Parameter, specifies the key you want to load
        //           Return value: Value of the key or empty if section/key doesn't exist
        //           Values are loaded from SiDiary.ini
        //           ApplicationGet is designed to retrieve values from SiDiary.ini from a known key
        //
        //      .SettingProfileGet([Section], [Key])
        //           Parameters:   [Section] string, In Parameter, specifies the section you want to
        //                                   read from
        //                         [Key] string, In Parameter, specifies the key you want to load
        //           Return value: Value of the key or empty if section/key doesn't exist
        //           Values are loaded from SiDiaryProfile.dat
        //           ProfileGet is designed to retrieve values from a known key, i.e. blood glucose
        //           unit of the patient currently opened in the main app
        //********************************************************************************************

        private enum genmEvent
        {
            All = -1,
            PatientOpen = 1,
            LanguageChange = 2,
            ProfileBGUnitChange = 3,
            ExchangeSettingsChange = 4,
            ProfileTargetChange = 5,
            AskForChanges = 6,
            SaveChanges = 7,
            ChangesSaved = 8,
            DiscardChanges = 9,
            WeightUnitChange = 10,
            EventDefinitionsChanged = 11,
            UDTDefinitionsChanged = 12,
            AddInConfigurationChanged = 13,
            RemindersChanged = 14,
            ActiveScreenChanged = 15,
            PumperProfileChanged = 16
        }


        private object mobjMainApplication;
        private string mtCurrentLanguage;

        private frmAddIn mfrmAddIn;

        public void AppEvent(short piIDEvent, ref object[] pvEventArgs)
        {
            //***************************************************************
            //This Method will be called by SiDiary main application in case
            //of any urgent notification
            //piIDEvent specifies the event type, please refer to the Event-
            //Constants defined in genmEvent enumerator.
            //pvEventArgs() is an array with additional but optional
            //parameters.
            //NOTE: You need to register for Application events as a very
            //first step! You can register for a single specific event (which
            //puts a lower load on the main application) or you can register
            //for all events. Refer to Sub AppInit() and AppDeInit() for
            //Register/Deregister-Calls
            //---------------------------------------------------------------
            //aw,  01.06.08: Init
            //***************************************************************

            if ((mfrmAddIn != null))
            {
                mfrmAddIn.lstEvents.Items.Add("Received Application event #" + piIDEvent);
            }

        }

        public void AddInMenuClicked(ref string ptMenuName)
        {
            //***************************************************************
            //This Method will be called by SiDiary main application in case
            //that the user has clicked the menu of your AddIn.
            //You can use code like the one from below to show your own
            //screen, do statistics, graphing etc.
            //---------------------------------------------------------------
            //aw,  18.09.09: Init
            //***************************************************************

            if (ptMenuName == "mnuCS2008E")
            {
                mfrmAddIn.Show();

                //The third parameter is VERY important!
                SiDiaryNET.mAddInObject.ShowAddIn(mfrmAddIn.Handle.ToInt32(), mtGetLanguageText(2), "CsTest");
            }
        }

        public void AddInHide(string ptRefKey)
        {
            //***************************************************************
            //This Method will be called by SiDiary main application in case
            //that the user has closed the tabbed window of your AddIn
            //The main application will still have an object reference to
            //your AddIn - it's just to notify you, that the window was
            //closed
            //---------------------------------------------------------------
            //aw,  01.06.08: Init
            //***************************************************************


            //NOTE: Even if your AddIn-Window is now invisible - you are still receiving
            //notifications which may slow down the main application - so take care of ressources!
            //Late assign/attach and early free/release ressources and events!!!

            if (ptRefKey == "CsTest")
            {
                if ((mfrmAddIn != null))
                {
                    mfrmAddIn.Hide();
                }
            }

        }

        public void AppInit(ref object pobjMainApplication, ref bool pbCancel, ref string ptCancelReason)
        {
            //***************************************************************
            //This Method will be called by SiDiary main application on the
            //startup of your addin. Keep a module reference of the given
            //MainApploication object as you will need it to pass calls to
            //SiDiary application
            //If any circumstance occurrs that the AddIn CANNOT be used
            //set pbCancel to True.
            //Valid Main-Menu Index:
            //1-Edit
            //2-Diabetesprofile
            //3-Statistics
            //4-Extras
            //5-Tools
            //File and About-Menues are invalid targets for AddIns
            //---------------------------------------------------------------
            //aw,  18.09.09: Init
            //***************************************************************
            string ltError = "";

            mobjMainApplication = pobjMainApplication;

            mAddInObject.EventRegister(ISiDiary.genmEvent.All);

            mtCurrentLanguage = mAddInObject.CurrentLanguage(mobjMainApplication);

            if (!mAddInObject.AddMenu("mnuCS2008E", mtGetLanguageText(2), 1, ref ltError))
                System.Windows.Forms.MessageBox.Show(ltError);


            if (mfrmAddIn == null)
            {
                mfrmAddIn = new frmAddIn();
                mfrmAddIn.InitObjects(this);
            }
        }

        public void AppDeInit()
        {
            //***************************************************************
            //This Method will be called by SiDiary main application on the
            //termination of your addin. This is the right place for freeing
            //any resources which you've requested on initializing, i.e.
            //deregister events etc.
            //---------------------------------------------------------------
            //aw,  01.06.08: Init
            //***************************************************************

            try
            {
                if ((mfrmAddIn != null))
                {
                    mfrmAddIn.Hide();
                }
                mfrmAddIn = null;

                mAddInObject.EventDeRegister(ISiDiary.genmEvent.All);

                mobjMainApplication = null;
            }

            catch
            {
            }

        }

        public string InfoDeveloper
        {
            //***************************************************************
            //This Property will be used by the application to identify the
            //developing company of this AddIn.
            //---------------------------------------------------------------
            //aw,  18.09.09: Init
            //***************************************************************


            get { return ADDIN_DEVELOPER; }
        }

        public string get_InfoDescription(string ptCurrentLanguage)
        {
            //***************************************************************
            //This Property will be used by the application to identify the
            //description of what this AddIn is designed for
            //---------------------------------------------------------------
            //aw,  18.09.09: Init
            //***************************************************************

            if (ptCurrentLanguage.Length > 0)
            {
                mtCurrentLanguage = ptCurrentLanguage;
            }
            return ADDIN_DESCRIPTION;
        }

        public bool IsTrendProvider
        {
            //***************************************************************
            //This Property will be used by the application to identify the
            //AddIn as a provider for a new trend analysis category
            //---------------------------------------------------------------
            //aw,  24.07.08: Init
            //***************************************************************


            get { return ADDIN_IS_TREND_PROVIDER; }
        }

        public short TrendNumberOfCategories
        {
            //***************************************************************
            //This Property will be used by the application to identify how
            //much categories (number of trend lines) this AddIn is providing
            //---------------------------------------------------------------
            //aw,  24.07.08: Init
            //***************************************************************


            get { return 2; }
        }

        public bool IsStatisticProvider
        {
            //***************************************************************
            //This Property will be used by the application to identify the
            //AddIn as a provider for a new graphical statistic
            //---------------------------------------------------------------
            //aw,  25.07.08: Init
            //***************************************************************


            get { return ADDIN_IS_STATISTIC_PROVIDER; }
        }

        public short StatisticNumberOfGraphs
        {
            //***************************************************************
            //This Property will be used by the application to identify how
            //much graphics this AddIn is providing
            //---------------------------------------------------------------
            //'aw,  25.07.08: Init
            //***************************************************************


            get { return 2; }
        }

        public string get_StatisticGraphName(short piIndexOfGraph)
        {
            //***************************************************************
            //This Property will be used by the application to obtain a name
            //for the graphic asked by piIndexOfGraph
            //---------------------------------------------------------------
            //aw,  25.07.08: Init
            //***************************************************************


            //Put your code here...
            switch (piIndexOfGraph)
            {
                case 1:
                    return "C# Statistic Graph 1";

                case 2:
                    return "C# Statistic Graph 2";
            }
            return "C# Statistics Graph";
        }

        public bool TrendGetRating(short piIndexOfCategory, string ptDateFrom1, string ptDateUntil1, string ptDateFrom2, string ptDateUntil2, short piPPFilter, string ptPPMinutesMin, string ptPPMinutesMax, ref object ptTrendCategoryName, ref short piTrend,
                                   ref short piRating, ref object ptTrendDetails, ref object ptError)
        {
            //***************************************************************
            //This Method will be called if the trend analysis will show
            //current ratings and needs the details from this trend provider
            //Valid Rating Numbers are:
            //1-excellent
            //2-good
            //3-satisfactory
            //4-poor
            //5-unknown
            //Valid trend numbers are:
            //1-became better
            //2-hasn't changed much
            //3-became worse
            //4-unknown
            //---------------------------------------------------------------
            //aw,  24.07.08: Init
            //***************************************************************

            Random rnd = new Random();

            ptTrendCategoryName = "C# Random sample #" + piIndexOfCategory;
            ptTrendDetails = "Rating is absolutely random!!";
            piTrend = (short)rnd.Next(1, 4);
            piRating = (short)rnd.Next(1, 5);
            
            return true;

        }

        public void TrendShowSettings(string Internal_Classname)
        {
            //***************************************************************
            //This Method will be called if the AddIn shall show his settings
            //screen to adjust the settings.
            //---------------------------------------------------------------
            //aw,  24.07.08: Init
            //***************************************************************


        }

        public bool StatisticGetGraph(short piIndexOfGraph, string ptDateFrom, string ptDateUntil, short piWidth, short piHeight, string ptFilterMask, string ptFilterEventMask, ref int plhWndGraph, string ptTmpFileGraph, ref object ptError)
        {
            bool functionReturnValue = false;
            //***************************************************************
            //This Method will be called if the statistic screen is refreshed
            //You must provide a handle to a picturebox-object (faster) or
            //you can save your graph picture to the tempfile given.
            //Note: Your picture must have correct size, specified by piWidth
            //and piHeight (both in Pixel)!
            //FilterMask is a String like a bit-sequence: 0110011...
            // the first 7 "bits" are 1 if the checkbox for the weekday is
            // currently checked (Monday, Tuesday, ...)
            // The next "Bits" are set if the checkboxes for the mealtimes
            // are set (before breakfast, after breakfast, etc...
            //FilterEventMask is a tokenbased string (comma-delimited) with
            //all currently selected Events, i.e. +,++,-,D?...
            //---------------------------------------------------------------
            //aw,  25.07.08: Init
            //***************************************************************
            Bitmap lbmpSave = null;

            if ((mfrmAddIn != null))
            {
                lbmpSave = (Bitmap)mfrmAddIn.picDummy.Image;
                lbmpSave.Save(ptTmpFileGraph, System.Drawing.Imaging.ImageFormat.Bmp);
                functionReturnValue = true;
            }
            else
            {
                ptError = "This is just a demo: Open the AddIn-Window from the Edit-Menu first! :)";
                functionReturnValue = false;
            }
            return functionReturnValue;

        }

        public void StatisticShowSettings(string Internal_Classname)
        {
            //***************************************************************
            //This Method will be called if the AddIn shall show his settings
            //screen to adjust the settings.
            //---------------------------------------------------------------
            //aw,  25.07.08: Init
            //***************************************************************

            //Put your code here...

            //Set frmSettingsStatistic.objMainApplication = mobjMainApplication
            //frmSettingsStatistic.Show (1)

        }

        private string mtGetLanguageText(int plIDMessage)
        {
            string functionReturnValue = null;
            //***************************************************************
            //Liefert den Sprachtext zur ID
            //---------------------------------------------------------------
            //aw,  18.09.09: Init
            //***************************************************************

            functionReturnValue = "";

            if (mAddInObject.CurrentLanguage(mobjMainApplication) == "DE")
            {
                switch (plIDMessage)
                {
                    case 1:
                        functionReturnValue = "Demo für AddIn-Ereignisse und Lesen & Schreiben";
                        break;
                    case 2:
                        functionReturnValue = "AddIn-Beispiel mit C# 2008 Express";
                        break;
                }
            }
            else
            {
                switch (plIDMessage)
                {
                    case 1:
                        functionReturnValue = "Demonstration of Application-Events and reading & writing of data";
                        break;
                    case 2:
                        functionReturnValue = "AddIn-Sample created with C# 2008 Express";
                        break;
                }
            }
            return functionReturnValue;

        }


        public cMain()
        {
        }
    }
}