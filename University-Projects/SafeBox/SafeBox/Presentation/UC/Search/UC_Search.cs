using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Domain.Entities;

// SearchService was Application layer service. I should check if ISearchService exists? 
// Previous session didn't mention ISearchService, but I should use IFileService logic or create ISearchService.
// UC_Search used FileService and VaultService.
// It also used SearchService _searchService.
// I should inject ISearchService if available.
// I'll check SearchService content later. for now, assuming IFileService and IVaultService are main ones.
// The original code instantiated SearchService but didn't seem to use it in PerformSearchAsync (used _fileService).
// Wait, PerformSearchAsync used `_fileService.SearchFiles`.
// Variable `_searchService` was unused? Or used elsewhere?
// I see `_searchService = new SearchService();` in constructor.
// But only `_fileService.SearchFiles` is called in `PerformSearchAsync`.
// So I will remove SearchService dependency if unused, or inject it if I missed usage.
// I'll stick to IFileService and IVaultService.

namespace SafeBox.Presentation.UC.Search
{
    public partial class UC_Search : UserControl
    {
        public event Action<int, string> OpenVaultContentRequested;

        private readonly IVaultService _vaultService;
        private readonly IFileService _fileService;
        private System.Windows.Forms.Timer searchTimer;
        private Label lblPlaceholder;
        private const string PLACEHOLDER_TEXT = "Search by filename..";

        public UC_Search()
        {
            InitializeComponent();
            _vaultService = new VaultService();
            _fileService = new FileService();

            SetupSearchTimer();
            SetupPlaceholder();
            WireUpEvents();
        }

        public UC_Search(IFileService fileService, IVaultService vaultService)
        {
            InitializeComponent();
            _fileService = fileService;
            _vaultService = vaultService;

            SetupSearchTimer();
            SetupPlaceholder();
            WireUpEvents();
        }

        private void SetupSearchTimer()
        {
            searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            searchTimer.Tick += (s, e) =>
            {
                searchTimer.Stop();
                PerformSearchAsync();
            };
        }

        private void SetupPlaceholder()
        {
            lblPlaceholder = new Label
            {
                Text = "Type to search files across your vaults...",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            flowSearchResults.Controls.Add(lblPlaceholder);
            flowSearchResults.Visible = true;
        }

        private void WireUpEvents()
        {
            txtFind.KeyDown += OnSearchKeyDown;
            txtFind.TextChanged += OnSearchTextChanged;
            txtFind.Enter += OnSearchEnter;
            txtFind.Leave += OnSearchLeave;
        }

        private void OnSearchEnter(object sender, EventArgs e)
        {
            if (txtFind.Text == PLACEHOLDER_TEXT)
            {
                txtFind.Text = "";
            }
        }

        private void OnSearchLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFind.Text))
            {
                txtFind.Text = PLACEHOLDER_TEXT;
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            string term = txtFind.Text?.Trim() ?? "";

            // Ignore if it matches placeholder or is empty
            if (string.IsNullOrWhiteSpace(term) || term == PLACEHOLDER_TEXT)
            {
                if (term != PLACEHOLDER_TEXT) // Only show empty placeholder if user actually cleared text
                {
                    ShowPlaceholder();
                }
                searchTimer.Stop();
                return;
            }

            searchTimer.Stop();
            searchTimer.Start();
        }

        private void OnSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchTimer.Stop();
                PerformSearchAsync();
                e.SuppressKeyPress = true;
            }
        }

        private void ShowPlaceholder()
        {
            ClearResults();
            lblPlaceholder.Text = "Type to search files across your vaults...";
            flowSearchResults.Controls.Add(lblPlaceholder);
            flowSearchResults.Visible = true;
        }

        private void ShowNoResults(string term)
        {
            ClearResults();
            lblPlaceholder.Text = $"No files found matching \"{term}\"";
            flowSearchResults.Controls.Add(lblPlaceholder);
        }

        private void ClearResults()
        {
            var controls = flowSearchResults.Controls.Cast<Control>().ToList();
            flowSearchResults.Controls.Clear();
            foreach (var ctrl in controls)
            {
                if (ctrl != lblPlaceholder)
                    ctrl.Dispose();
            }
        }

        private async void PerformSearchAsync()
        {
            string term = txtFind.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(term) || term == PLACEHOLDER_TEXT)
            {
                ShowPlaceholder();
                return;
            }

            int userId = SessionManager.CurrentUserId;
            if (userId == 0)
                userId = SessionManager.CurrentAdminId;

            if (userId == 0)
            {
                ShowNoResults(term);
                return;
            }

            try
            {
                ClearResults();
                flowSearchResults.Visible = true;

                // Run search on background thread
                var files = await Task.Run(() => _fileService.SearchFiles(term, userId).ToList());
                var vaults = await Task.Run(() => _vaultService.GetVaultsByUserId(userId)
                    .ToDictionary(v => v.VaultId, v => v.VaultName));

                if (!files.Any())
                {
                    ShowNoResults(term);
                    return;
                }

                foreach (var file in files)
                {
                    string vaultName = vaults.ContainsKey(file.VaultId) ? vaults[file.VaultId] : "Unknown";
                    var row = CreateFileRow(file, vaultName);
                    flowSearchResults.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                ClearResults();
                lblPlaceholder.Text = $"Search error: {ex.Message}";
                flowSearchResults.Controls.Add(lblPlaceholder);
            }
        }

        private Control CreateFileRow(File file, string vaultName)
        {
            UC_SearchFileRow row = new UC_SearchFileRow();
            row.SetService(_fileService);
            row.SetData(file.FileId, file.FileName, file.FileSize, file.UploadDate, vaultName, file.VaultId);

            // Subscribe to events
            row.ShowInVaultRequested += (vId, vName) => OpenVaultContentRequested?.Invoke(vId, vName);

            // Add to layout
            row.Width = flowSearchResults.Width - 30;
            row.Margin = new Padding(5);

            return row;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                searchTimer?.Stop();
                searchTimer?.Dispose();
                ClearResults();
                lblPlaceholder?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
