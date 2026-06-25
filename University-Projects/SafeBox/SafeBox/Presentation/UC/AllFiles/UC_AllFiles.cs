using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories; // For default constructor

namespace SafeBox.Presentation.UC.AllFiles
{
    public partial class UC_AllFiles : UserControl
    {
        private readonly IFileService _fileService;
        private readonly IVaultService _vaultService;

        public event Action<int, string> OpenVaultContentRequested;

        public UC_AllFiles()
        {
            InitializeComponent();
            _fileService = new FileService();
            _vaultService = new VaultService();
            if (!this.DesignMode) LoadAllFiles();
        }

        public UC_AllFiles(IFileService fileService, IVaultService vaultService)
        {
            InitializeComponent();
            _fileService = fileService;
            _vaultService = vaultService;
            LoadAllFiles();
        }

        private void LoadAllFiles()
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                if (userId == 0)
                {
                    MessageBox.Show("Please log in to view files.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                flowFilesList.Controls.Clear();

                var files = _fileService.GetAllFiles(userId);
                long totalStorage = _fileService.GetTotalStorageSize(userId);
                int totalFileCount = _fileService.GetTotalFileCount(userId);

                if (lblTotalFiles != null)
                    lblTotalFiles.Content = $"Total: {totalFileCount} files";

                if (lblSize != null)
                    lblSize.Content = $"Size: {FormatFileSize(totalStorage)}";

                if (!files.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No files found. Upload files to vaults to see them here.",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(20)
                    };
                    flowFilesList.Controls.Add(lblEmpty);
                    return;
                }

                var vaults = _vaultService.GetVaultsByUserId(userId).ToDictionary(v => v.VaultId, v => v.VaultName);

                foreach (var file in files)
                {
                    string vaultName = vaults.ContainsKey(file.VaultId) ? vaults[file.VaultId] : "Unknown";

                    UC_FileRow row = new UC_FileRow();
                    row.SetService(_fileService);
                    row.SetFileData(file.FileId, file.FileName, file.FileType, vaultName,
                        file.FileSize, file.UploadDate, file.VaultId);

                    row.Tag = file.FileId;

                    row.MouseEnter += (s, e) =>
                    {
                        if (row.BackColor != Color.FromArgb(255, 240, 200))
                            row.BackColor = Color.FromArgb(250, 250, 250);
                    };
                    row.MouseLeave += (s, e) =>
                    {
                        if (row.BackColor != Color.FromArgb(255, 240, 200))
                            row.BackColor = Color.White;
                    };

                    row.Click += (s, e) => OpenVaultContentRequested?.Invoke(file.VaultId, vaultName);

                    row.Width = flowFilesList.Width - 25;
                    row.FileDeleted += OnFileDeleted;
                    row.FileDownloaded += OnFileDownloaded;

                    flowFilesList.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics(int fileCount, long totalStorage)
        {
        }

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

        private void OnFileDeleted(int fileId)
        {
            LoadAllFiles();
        }

        private void OnFileDownloaded(int fileId)
        {
        }

        public void RefreshFiles()
        {
            LoadAllFiles();
        }

        public void HighlightFile(int fileId)
        {
            try
            {
                foreach (Control control in flowFilesList.Controls)
                {
                    if (control is UC_FileRow fileRow)
                    {
                        if (control.Tag != null && (int)control.Tag == fileId)
                        {
                            fileRow.BackColor = Color.FromArgb(255, 240, 200);
                            control.BringToFront();
                            flowFilesList.ScrollControlIntoView(control);

                            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                            timer.Interval = 3000;
                            timer.Tick += (s, e) =>
                            {
                                fileRow.BackColor = Color.White;
                                timer.Stop();
                                timer.Dispose();
                            };
                            timer.Start();

                            return;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void LoadAllFiles(int highlightFileId = 0)
        {
            LoadAllFiles();

            if (highlightFileId > 0)
            {
                this.BeginInvoke(new Action(() =>
                {
                    HighlightFile(highlightFileId);
                }));
            }
        }
    }
}
