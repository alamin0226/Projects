using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SafeBox.Application.Services;
using SafeBox.Application.Interfaces;

namespace SafeBox.Presentation.UC.Vault
{
    public partial class UC_VaultFileRow : UserControl
    {
        public event Action<int> FileDeleted;
        public event Action<int> FileDownloaded;

        private int _fileId;
        private int _vaultId;
        private string _fileName;

        private IFileService _fileService;

        public UC_VaultFileRow()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;

            // Wire up events
            this.btnDownload.Click += new EventHandler(btnDownload_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        public void SetService(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Sets file data for display
        /// </summary>
        public void SetFileData(int fileId, string fileName, string fileType, string vaultName, long fileSize, DateTime uploadDate, int vaultId)
        {
            _fileId = fileId;
            _vaultId = vaultId;
            _fileName = fileName;

            lblFileName.Content = fileName;
            lblFileType.Content = fileType;
            lblVault.Content = vaultName;
            lblSize.Content = FormatFileSize(fileSize);
            lblDate.Content = uploadDate.ToString("M/d/yyyy HH:mm");
        }

        /// <summary>
        /// Legacy method for backward compatibility
        /// </summary>
        public void SetData(string fileName, string fileType, string vault, string size, string date)
        {
            _fileName = fileName;
            lblFileName.Content = fileName;
            lblFileType.Content = fileType;
            lblVault.Content = vault;
            lblSize.Content = size;
            lblDate.Content = date;
        }

        /// <summary>
        /// Formats file size
        /// </summary>
        private string FormatFileSize(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";
            else if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:F1} KB";
            else if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / (1024.0 * 1024.0):F1} MB";
            else
                return $"{bytes / (1024.0 * 1024.0 * 1024.0):F1} GB";
        }

        /// <summary>
        /// Handles download button click
        /// </summary>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                if (userId == 0)
                {
                    MessageBox.Show("Please log in to download files.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = _fileName;
                    saveDialog.Title = "Save file as";
                    saveDialog.Filter = "All Files (*.*)|*.*";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        _fileService.DownloadFile(_fileId, saveDialog.FileName, userId);
                        FileDownloaded?.Invoke(_fileId);

                        MessageBox.Show($"File downloaded successfully to:\n{saveDialog.FileName}",
                            "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult result = MessageBox.Show("Do you want to open the file?",
                            "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start(saveDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Download failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles delete button click
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete '{_fileName}'?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int userId = SessionManager.CurrentUserId;
                    _fileService.DeleteFile(_fileId, userId);

                    if (FileDeleted != null)
                    {
                        // Signal the parent to refresh the list.
                        // IMPORTANT: This often causes the control to be disposed.
                        FileDeleted.Invoke(_fileId);
                    }
                    else
                    {
                        // If no one is listening, we manually remove it safely.
                        this.BeginInvoke(new Action(() =>
                        {
                            try
                            {
                                if (this.Parent != null && !this.IsDisposed)
                                {
                                    this.Parent.Controls.Remove(this);
                                    this.Dispose();
                                }
                            }
                            catch { /* Ignore UI errors during disposal */ }
                        }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Delete failed: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sharing functionality is currently under maintenance.", "Feature Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
