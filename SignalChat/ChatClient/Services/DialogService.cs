using Microsoft.Win32;
using System;
using System.Windows;

namespace ChatClient.Services
{
    public class DialogService : IDialogService
    {
        public string OpenFile(string caption, string filter = "All files (*.*)|*.*")
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dialog.Title = caption;
            dialog.Filter = filter;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == true) return dialog.FileName;
            return string.Empty;
        }

        public bool ShowConfirmationRequest(string message, string caption = "")
        {
            var result = MessageBox.Show(message, caption, MessageBoxButton.OKCancel);
            return result.HasFlag(MessageBoxResult.OK);
        }

        public void ShowNotification(string message, string caption = "")
        {
            MessageBox.Show(message, caption);
        }
    }
}
