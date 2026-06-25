using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SafeBox.Application.Services;
using SafeBox.Application.Interfaces;

namespace SafeBox.Presentation.UC.Vault
{
    public partial class UC_VaultContent : UserControl
    {
        public event Action BackToVaultsRequested;

        private int _vaultId;
        private string _vaultName;
        private readonly IFileService _fileService;
        private readonly IVaultService _vaultService;
        private ProgressBar _uploadProgress;
        private Label _lblUploadStatus;

        public UC_VaultContent()
        {
            InitializeComponent();

            if (IsInDesignMode())
                return;

            _fileService = new FileService();
            _vaultService = new VaultService();
            CreateProgressControls();
            WireUpEventsIfNeeded();
        }

        public UC_VaultContent(IFileService fileService, IVaultService vaultService)
        {
            InitializeComponent();
            _fileService = fileService;
            _vaultService = vaultService;
            CreateProgressControls();
            WireUpEventsIfNeeded();
        }

        public UC_VaultContent(int vaultId, string vaultName) : this()
        {
            SetVault(vaultId, vaultName);
        }

        private void CreateProgressControls()
        {
            _uploadProgress = new ProgressBar
            {
                Location = new Point(20, 175),
                Size = new Size(400, 10),
                Visible = false,
                Style = ProgressBarStyle.Continuous
            };
            this.Controls.Add(_uploadProgress);
            _uploadProgress.BringToFront();

            _lblUploadStatus = new Label
            {
                Location = new Point(430, 170),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(100, 100, 100),
                Visible = false,
                AutoSize = true
            };
            this.Controls.Add(_lblUploadStatus);
            _lblUploadStatus.BringToFront();
        }

        public void SetVault(int vaultId, string vaultName)
        {
            _vaultId = vaultId;
            _vaultName = vaultName;

            if (lblVaultName != null)
                lblVaultName.Content = vaultName;

            if (IsInDesignMode())
                return;

            LoadFiles();
        }

        public void RefreshFiles()
        {
            if (IsInDesignMode())
                return;

            LoadFiles();
        }

        private void WireUpEventsIfNeeded()
        {
            if (btnBack != null)
                btnBack.Click += BtnBack_Click;

            if (btnUpload != null)
                btnUpload.Click += BtnUpload_Click;

            if (dropZonePanel != null)
            {
                dropZonePanel.AllowDrop = true;
                dropZonePanel.DragEnter += DropZonePanel_DragEnter;
                dropZonePanel.DragLeave += DropZonePanel_DragLeave;
                dropZonePanel.DragDrop += DropZonePanel_DragDrop;
            }

            this.Resize += (s, e) => ResizeFileRows();
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime
                   || (this.Site?.DesignMode ?? false);
        }

        private void DropZonePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (dropZonePanel == null) return;

            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DropZonePanel_DragLeave(object sender, EventArgs e)
        {
        }

        private async void DropZonePanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                await UploadFilesAsync(files);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            BackToVaultsRequested?.Invoke();
        }

        private async void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select files to upload";
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await UploadFilesAsync(openFileDialog.FileNames);
                }
            }
        }

        private async Task UploadFilesAsync(string[] filePaths)
        {
            if (IsInDesignMode())
                return;

            if (filePaths == null || filePaths.Length == 0)
                return;

            int userId = SessionManager.CurrentUserId;
            if (userId == 0)
            {
                MessageBox.Show("Please log in to upload files.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _uploadProgress.Visible = true;
            _lblUploadStatus.Visible = true;
            btnUpload.Enabled = false;

            int totalFiles = filePaths.Length;
            int currentFile = 0;
            int successCount = 0;

            foreach (string filePath in filePaths)
            {
                currentFile++;
                string fileName = Path.GetFileName(filePath);
                _lblUploadStatus.Text = $"Uploading {currentFile}/{totalFiles}: {fileName}";

                try
                {
                    await Task.Run(() =>
                    {
                        _fileService.UploadFile(filePath, _vaultId, userId);
                    });
                    successCount++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to upload {fileName}: {ex.Message}",
                        "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int progress = (int)((currentFile * 100) / totalFiles);
                _uploadProgress.Value = Math.Min(progress, 100);
            }

            _uploadProgress.Visible = false;
            _uploadProgress.Value = 0;

            _lblUploadStatus.Text = $"Successfully uploaded {successCount}/{totalFiles} file(s)";
            btnUpload.Enabled = true;

            LoadFiles();

            await Task.Delay(3000);
            _lblUploadStatus.Visible = false;
        }

        private void LoadFiles()
        {
            if (IsInDesignMode())
                return;

            try
            {
                for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
                {
                    Control ctrl = flowLayoutPanel1.Controls[i];
                    flowLayoutPanel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }

                var files = _fileService.GetFilesByVaultId(_vaultId);

                if (files == null || !files.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No files in this vault yet. Upload some files to get started!",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(20),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top
                    };
                    flowLayoutPanel1.Controls.Add(lblEmpty);
                    return;
                }

                var vault = _vaultService.GetVaultById(_vaultId);
                string vaultName = vault?.VaultName ?? "Unknown";

                flowLayoutPanel1.SuspendLayout();

                foreach (var file in files)
                {
                    UC_VaultFileRow row = new UC_VaultFileRow();
                    row.SetService(_fileService);
                    row.SetFileData(file.FileId, file.FileName, file.FileType, vaultName,
                        file.FileSize, file.UploadDate, _vaultId);

                    row.Height = 70;
                    row.Margin = new Padding(0, 5, 0, 5);
                    row.Width = Math.Max(0, flowLayoutPanel1.ClientSize.Width - 20);

                    row.FileDeleted += OnFileDeleted;
                    row.FileDownloaded += OnFileDownloaded;

                    flowLayoutPanel1.Controls.Add(row);
                }

                flowLayoutPanel1.ResumeLayout(true);
                flowLayoutPanel1.PerformLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResizeFileRows()
        {
            if (flowLayoutPanel1 == null) return;

            flowLayoutPanel1.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_VaultFileRow)
                {
                    ctrl.Width = Math.Max(0, flowLayoutPanel1.ClientSize.Width - 20);
                }
            }
            flowLayoutPanel1.ResumeLayout(true);
        }

        private void OnFileDeleted(int fileId)
        {
            LoadFiles();
        }

        private void OnFileDownloaded(int fileId)
        {
        }
    }
}
