using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.HelperClass
{
   public class SetApplicationTimeOut:FrmInvoiceMaster
    {
        #region
        /// <summary>
        /// Private Timer Property
        /// </summary>
        private static Timer _timer;

        /// <summary>
        /// Timer Property
        /// </summary>
        public Timer Timer
        {
            get
            {
                return _timer;
            }
            set
            {
                if (_timer != null)
                {
                    _timer.Tick -= Timer_Tick;
                }

                _timer = value;

                if (_timer != null)
                {
                    _timer.Tick += Timer_Tick;
                }
            }
        }
        #endregion
        #region Events
        public event EventHandler UserActivity;
        #endregion

        #region Constructor
        /// <summary>
        /// Default/Parameterless SetApplicationTimeOut Constructor
        /// </summary>
        public SetApplicationTimeOut()
        {
            KeyPreview = true;
            FormClosed += ObservedForm_FormClosed;
            MouseMove += ObservedForm_MouseMove;
            KeyDown += ObservedForm_KeyDown;
        }
        #endregion
        #region Inherited Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnUserActivity(EventArgs e)
        {
            // Invoking the UserActivity delegate
            UserActivity?.Invoke(this, e);
        }
        /// <summary>
        /// 
        /// </summary>
        public void SetTimeOut()
        {
            // postpone auto-logout by 30 minutes
            _timer = new Timer
            {
                Interval = (1 * 02 * 1000) // Timer set for 30 minutes
            };
            Application.Idle += Application_Idle;
            _timer.Tick += new EventHandler(Timer_Tick);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObservedForm_MouseMove(object sender, MouseEventArgs e)
        {
            OnUserActivity(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObservedForm_KeyDown(object sender, KeyEventArgs e)
        {
            OnUserActivity(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObservedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosed -= ObservedForm_FormClosed;
            MouseMove -= ObservedForm_MouseMove;
            KeyDown -= ObservedForm_KeyDown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_Idle(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            Application.Idle -= Application_Idle;
            //MessageBox.Show("Application Terminating");
            //Application.Exit();
        }

        #endregion
        
    }
}
