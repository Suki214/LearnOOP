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
using System.Diagnostics;
using System.Windows.Input;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    /// <summary>
    /// A command whose sole purpose is to 
    /// relay its functionality to other
    /// objects by invoking delegates. The
    /// default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    internal class RelayCommand : ICommand
    {
        #region Fields

        readonly Action<object> _executeDelegate;
        readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="executeDelegate">The execution logic.</param>
        public RelayCommand(Action<object> executeDelegate)
            : this(executeDelegate, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="executeDelegate">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> executeDelegate, Predicate<object> canExecute)
        {
            if (executeDelegate == null)
                throw new ArgumentNullException("execute");

            _executeDelegate = executeDelegate;
            _canExecute = canExecute;
        }

        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _executeDelegate(parameter);
        }

        #endregion // ICommand Members
    }
}