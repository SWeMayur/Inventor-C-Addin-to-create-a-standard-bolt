using InvAddIn;
using Inventor;
using System;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BoltAddin
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [GuidAttribute("bc5e9bc5-6368-41a3-8042-ec65aa1609df")]
    public class StandardAddInServer : Inventor.ApplicationAddInServer
    {

        // Inventor application object.
        public static Inventor.Application m_inventorApplication;
        public static ButtonDefinition m_helloWorldButton;
        public StandardAddInServer()
        {
        }

        #region ApplicationAddInServer Members

        /// <summary>
        /// Called when the add-in is activated.
        /// </summary>
        public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            // Initialize AddIn members.
            m_inventorApplication = addInSiteObject.Application;
            AddButton();
        }
        /// <summary>
        /// Called when the add-in is deactivated.
        /// </summary>
        public void Deactivate()
        {
            m_inventorApplication = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Adds a custom button to the Inventor UI.
        /// </summary>
        private void AddButton()
        {
            string filename = @"../../Resources/boltIcon2.ico";
            string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string fullPath = System.IO.Path.Combine(directory, filename);
            Icon commandIcon = new Icon(filename);
            Icon smallCommandIcon = new Icon(commandIcon, 16, 16);
            Icon largeCommandIcon = new Icon(commandIcon, 32, 32);
            stdole.IPictureDisp smallic = PictureDispConverter.ToIPictureDisp(smallCommandIcon);
            stdole.IPictureDisp bigicon = PictureDispConverter.ToIPictureDisp(largeCommandIcon);

            UserInterfaceManager uiMgr = m_inventorApplication.UserInterfaceManager;

            // Create a button definition
            m_helloWorldButton = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
                "Create Bolt", "CreateBolt", CommandTypesEnum.kFileOperationsCmdType, Guid.NewGuid().ToString(), "Create a Bolt", "Create Bolt Button", smallic, bigicon);

            // Get the tools tab
            Ribbon toolsRibbon = uiMgr.Ribbons["Part"];

            //Get the tools tab
            RibbonTab toolsTab = toolsRibbon.RibbonTabs["id_TabTools"];

            // Get the tools panel within the tools tab
            RibbonPanel toolsPanel = toolsTab.RibbonPanels["id_PanelP_ShowPanels"];

            // Add the button to the panel
            CommandControl commandControl = toolsPanel.CommandControls.AddButton(
                m_helloWorldButton,
                true,
                true,
                "",
                false);
            // Wire up the event handler
            //m_helloWorldButton.OnExecute += OnExecute;
            m_helloWorldButton.OnExecute += CreateBoltButton_OnExecute;
        }

        /// <summary>
        /// Event handler for the "Create Bolt" button click.
        /// Opens a form for entering bolt parameters and creates a bolt based on the input.
        /// </summary>
        //Bolt code:
        private void CreateBoltButton_OnExecute(NameValueMap Context)
        {
            try
            {
                IBoltFactory boltFactory = new StandardBoltFactory();
                BoltParametersWindow boltParametersWindow = new BoltParametersWindow();
                if((bool)boltParametersWindow.ShowDialog())
                {
                    IBolt bolt = boltFactory.CreateBolt(boltParametersWindow.BoltDiameter, boltParametersWindow.BoltLength, boltParametersWindow.BoltThreadDepth, boltParametersWindow.BoltThreadPitch);
                    bolt.Create(m_inventorApplication);
                }
                //BoltParametersForm boltParametersForm = new BoltParametersForm();
                //if (boltParametersForm.ShowDialog() == DialogResult.OK)
                //{
                //    IBolt bolt = boltFactory.CreateBolt(boltParametersForm.BoltDiameter, boltParametersForm.BoltLength, boltParametersForm.BoltThreadDepth, boltParametersForm.BoltThreadPitch);
                //    bolt.Create(m_inventorApplication);
                //}
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(new Exception($"Error handling form input: {ex.Message}"));
            }
        }

        /// <summary>
        /// Executes a command with the given ID.
        /// </summary>
        public void ExecuteCommand(int commandID){}

        /// <summary>
        /// Gets the Automation object associated with this add-in.
        /// </summary>
        public object Automation
        {
            get
            {
                return null;
            }
        }

        #endregion
    }
}