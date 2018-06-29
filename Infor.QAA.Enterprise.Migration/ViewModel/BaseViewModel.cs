/******************************************************
 *                      NOTICE
 * 
 * THIS SOFTWARE IS THE PROPERTY OF AND CONTAINS
 * CONFIDENTIAL INFORMATION OF INFOR AND SHALL NOT
 * BE DISCLOSED WITHOUT PRIOR WRITTEN PERMISSION.
 * LICENSED CUSTOMERS MAY COPY AND ADAPT THIS
 * SOFTWARE FOR THEIR OWN USE IN ACCORDANCE WITH
 * THE TERMS OF THEIR SOFTWARE LICENSE AGREEMENT.
 * ALL OTHER RIGHTS RESERVED.
 * 
 * COPYRIGHT (c) 2011 - 2012 INFOR. ALL RIGHTS RESERVED.
 * THE WORD AND DESIGN MARKS SET FORTH HEREIN ARE
 * TRADEMARKS AND/OR REGISTERED TRADEMARKS OF INFOR
 * AND/OR RELATED AFFILIATES AND SUBSIDIARIES. ALL
 * RIGHTS RESERVED. ALL OTHER TRADEMARKS LISTED
 * HEREIN ARE THE PROPERTY OF THEIR RESPECTIVE
 * OWNERS. WWW.INFOR.COM.
 * 
 * *****************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region utility to check if it's currently in visual studio designer
        private static bool? _isInDesignMode;
        /// <summary>
        /// Gets a value indicating whether the control is in design mode (running in Blend or Visual Studio).
        /// </summary>
        public static bool IsInDesignModeStatic
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    _isInDesignMode
                    = (bool)DependencyPropertyDescriptor
                    .FromProperty(prop, typeof(FrameworkElement))
                    .Metadata.DefaultValue;
                }

                return _isInDesignMode.Value;
            }
        }
        /// <summary>
        /// Gets a value indicating whether the control is in design mode (running under Blend or Visual Studio).
        /// </summary>
        [SuppressMessage(
        "Microsoft.Performance",
        "CA1822:MarkMembersAsStatic",
        Justification = "Non static member needed for data binding")]
        public bool IsInDesignMode
        {
            get
            {
                return IsInDesignModeStatic;
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyLanguageChange()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
            foreach (var item in properties)
            {
                if (!string.IsNullOrEmpty(item.Name) && !item.Name.Equals("ResourceManager") && !item.Name.Equals("Culture"))
                {
                    NotifyPropertyChange(item.Name);
                }
            }
        }

        #region Debugging Aides

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            Contract.Requires(propertyName != null);
            // Verify that the property name matches a real,  
            // public, instance/static property on this object.

            if (this.GetType().GetProperty(propertyName, BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public) == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides

        protected void NotifyPropertyChange(string property)
        {
            Contract.Requires(!string.IsNullOrEmpty(property));

            this.VerifyPropertyName(property);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }

    public class BaseDialogViewModel : BaseViewModel
    {
        private ICommand cancelCommand;
        private ICommand okCommand;
        private ICommand helpCommand;

        private bool? dialogResult;

        public bool? DialogResult
        {
            get { return this.dialogResult; }
            set
            {
                if (this.dialogResult != value)
                {
                    this.dialogResult = value;
                    NotifyPropertyChange("DialogResult");
                }
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand
                    (
                        param =>
                        {
                            this.DialogClose(false);
                        }
                    );
                }

                return cancelCommand;

            }
        }

        protected virtual bool DialogWillClose()
        {
            return true;
        }

        /// <summary>
        /// If the dialog view model will use cell reference, it cannot be show dialog with not-modal directly. 
        /// It should be show top most in another thread. So the view model should override the dialogclose method.
        /// Because the DependencyProperty DialogResult will not work in another thread.
        /// In a word, please override this dialog close method if the view model will be shown in another thread. For example DataSendViewModel
        /// </summary>
        /// <param name="result"></param>
        protected virtual void DialogClose(bool result)
        {
            DialogResult = result;
        }

        protected virtual bool ValidateBeforeClose()
        {
            return true;
        }

        public ICommand OKCommand
        {
            get
            {
                if (okCommand == null)
                {
                    okCommand = new RelayCommand
                    (
                        param =>
                        {
                            if (this.DialogWillClose())
                            {
                                this.DialogClose(true);
                            }
                        },
                        param =>
                        {
                            return this.ValidateBeforeClose();
                        }
                    );
                }

                return okCommand;

            }
        }

    }

}
