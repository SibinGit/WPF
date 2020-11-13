using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Template.EventArgs
{
    class SettingConfirmedEventArgs
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of confirmed setting</param>
        public SettingConfirmedEventArgs(string name)
        {
            Name = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or set the name
        /// </summary>
        public string Name { get; private set; }
        #endregion
    }
}
