using System;
using System.Drawing;
using System.Windows.Forms;
using SafeBox.Services;
using System.Diagnostics;

using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;

namespace SafeBox.Presentation.UC.Search
{
    public partial class UC_SearchFileRow : UserControl
    {
        public event Action<int, string> ShowInVaultRequested; // vaultId, vaultName
        public event Action<int> FileDownloaded; // fileId

        private int _fileId;
        private int _vaultId;
        private string _vaultName;
        private string _fileName;
        private IFileService _fileService;

        public UC_SearchFileRow()
        {
            InitializeComponent();
            _fileService = new FileService(); // Default

            // Wire up events

            // Wire up events
            btnDownload.Click += BtnDownload_Click;
            btnShowinVault.Click += BtnShowInVault_Click;

            // Make references clickable
            lblFileName.Click += (s, e) => BtnShowInVault_Click(s, e);
            this.Click += (s, e) => BtnShowInVault_Click(s, e);
        }

        public void SetService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void SetData(int fileId, string fileName, long fileSize, DateTime uploadDate, string vaultName, int vaultId)
        {
            _fileId = fileId;
            _fileName = fileName;
            _vaultId = vaultId;
            _vaultName = vaultName;

            lblFileName.Content = fileName;
            lblSize.Content = FormatSize(fileSize);
            lblDate.Content = uploadDate.ToString("dd MMM yyyy");
            lblVault.Content = vaultName;
        }

        private void BtnShowInVault_Click(object sender, EventArgs e)
        {
            ShowInVaultRequested?.Invoke(_vaultId, _vaultName);
        }

        private void BtnDownload_Click(object sender, EventArgs e)
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

        private string FormatSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            if (bytes < 1024 * 1024 * 1024) return $"{bytes / (1024.0 * 1024):F1} MB";
            return $"{bytes / (1024.0 * 1024 * 1024):F1} GB";
        }
    }
}
