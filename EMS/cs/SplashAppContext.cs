using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace EMS.cs
{
    public class SplashAppContext : ApplicationContext
    {
        Form mainForm = null;
        Timer splashTimer = new Timer();

        public SplashAppContext(Form mainForm, Form splashForm)
            : base(splashForm)
        {
            this.mainForm = mainForm;

            splashTimer.Tick += new EventHandler(SplashTimeUp);
            splashTimer.Interval = 2000;
            splashTimer.Enabled = true;
        }

        /// <summary>
        /// This is the timer event handler.  We use the timer to tell the ApplicationContext 
        /// that the splash screen is ready to be closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashTimeUp(object sender, EventArgs e)
        {
            //This is called if the splash is ready to be closed.  In order to do this
            //we first dispose of the timer (we dont need any leaks do we?) and then
            //call the base.MainForm.Close function which will triger the MainFormClosed event
            //that we overrode so we can set the Application Context's main form as the 
            //main form the user passed into the constructor.

            splashTimer.Enabled = false;
            splashTimer.Dispose();

            base.MainForm.Close();
        }

        /// <summary>
        /// Normaly, if not overridden, this event will call ExitThreadCore function.
        /// We have overridden it to catch when the splash form has closed.  When the
        /// spash form closes, we want to set the main form passed in the contructor to
        /// the base.MainForm property.  when the main form closes, this override will be
        /// called again, and we just pass the call onto the base.OnMainFormClosed, with will
        /// tells the Application object to terminate the UI thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (sender is start)
            {
                base.MainForm = this.mainForm;
                base.MainForm.Show();
            }
            else if (sender is login)
            {
                base.OnMainFormClosed(sender, e);
            }
        }

        /// <summary>
        /// This sets how long the spash form will show once it is at 100% opacity.  Default is 2 seconds.
        /// </summary>
        public int SecondsSplashShown
        {
            set
            {
                splashTimer.Interval = value * 1000;
            }
        }
    }



    public class SplashFadeAppContext : ApplicationContext
    {
        /// <summary>
        /// Internal flags to tell process what state the splash form is in
        /// </summary>
        private enum FormStatus
        {
            Open = 1,
            Opening = 2,
            Closing = 4,
            Closed = 8
        }

        private FormStatus formStatus = FormStatus.Open;
        private Form mainForm = null;
        private Timer splashTimer = new Timer();
        private int showSplashInterval = 2000;
        private int fadeInterval = 50;
        private bool doFadeClose = false;


        public SplashFadeAppContext(Form mainForm, Form splashForm)
            : base(splashForm)
        {
            this.mainForm = mainForm;

            splashTimer.Tick += new EventHandler(SplashTimeUp);
            splashTimer.Interval = fadeInterval;
            splashTimer.Enabled = true;
        }

        /// <summary>
        /// This is the timer event that controls what our spash screen does.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashTimeUp(object sender, EventArgs e)
        {
            if (formStatus == FormStatus.Opening)
            {
                //if the splash is opening, the opacity will increase in increments of 5 until it is fully
                //shown.  Once it is fully opacic, it sets the status flag to open.
                if (base.MainForm.Opacity < 1)
                    base.MainForm.Opacity += .05;
                else
                    formStatus = FormStatus.Open;
            }
            else if (formStatus == FormStatus.Closing)
            {
                //if the splash is closing, the opacity will decrease in increments of 5 until it is fully
                //hidden.  Once it is fully transparent, it sets the status flag to closed.
                if (base.MainForm.Opacity > .10)
                {
                    base.MainForm.Opacity -= .05;
                    splashTimer.Interval = fadeInterval;
                }
                else
                {
                    formStatus = FormStatus.Closed;
                }
            }
            else if (formStatus == FormStatus.Open)
            {
                //Once the splash is open and fully shown, the timer interval is set to the splash delay setting,
                //which is defaulted to 2 seconds, and then sets the status flag depending on if the user
                //wants to just close the splash or fade it out.
                splashTimer.Interval = showSplashInterval;

                if (doFadeClose)
                    formStatus = FormStatus.Closing;
                else
                    formStatus = FormStatus.Closed;
            }
            else if (formStatus == FormStatus.Closed)
            {
                //This is called if the splash is ready to be closed.  In order to do this
                //we first dispose of the timer (we dont need any leaks do we?) and then
                //call the base.MainForm.Close function which will triger the MainFormClosed event
                //that we overrode so we can set the Application Context's main form as the 
                //main form the user passed into the constructor.
                splashTimer.Enabled = false;
                splashTimer.Dispose();
                base.MainForm.Close();
            }
        }

        /// <summary>
        /// Normaly, if not overridden, this event will call ExitThreadCore function.
        /// We have overridden it to catch when the splash form has closed.  When the
        /// spash form closes, we want to set the main form passed in the contructor to
        /// the base.MainForm property.  when the main form closes, this override will be
        /// called again, and we just pass the call onto the base.OnMainFormClosed, with will
        /// tells the Application object to terminate the UI thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (sender is start)
            {
                base.MainForm = this.mainForm;
                base.MainForm.Show();
            }
            else if (sender is login)
            {
                base.OnMainFormClosed(sender, e);
            }
        }

        #region Public Properties

        /// <summary>
        /// Bool that determines if spash form will fade up from 0% opacity to 100% when 
        /// the spash form opens.  Default is false.
        /// </summary>
        public bool DoFadeOpen
        {
            set
            {
                if (value == true)
                {
                    base.MainForm.Opacity = 0;
                    formStatus = FormStatus.Opening;
                }
            }
        }

        /// <summary>
        /// Bool that determines if spash form will fade down from 100% opacity to 0% when 
        /// the spash form closes.  Default is false.
        /// </summary>
        public bool DoFadeClose
        {
            set
            {
                doFadeClose = value;
            }
        }

        /// <summary>
        /// This sets how long the spash form will show once it is at 100% opacity.  Default is 2 seconds.
        /// </summary>
        public int SecondsSplashShown
        {
            set
            {
                showSplashInterval = value * 1000;
            }
        }
        #endregion Public Properties
    }
}
