using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleDriveUploader.GoogleDrive;
using System.IO;

namespace GoogleDriveUploader.View
{
    public partial class GoogleDriveExample : Form
    {
        private string _uploadFileName;
        private string _downloadPath;
        GoogleDriveService _service;

        public GoogleDriveExample()
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            InitializeComponent();

            _uploadButton.Enabled = false;
            _downloadButton.Enabled = false;
            _downloadBrowseButton.Enabled = false;
            _uploadFileOpenFileDialog.FileName = "";
            _uploadFileOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            _downloadFolderBrowserDialog.SelectedPath = Directory.GetCurrentDirectory();
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        private void ClickBrowseUploadFileButton(object sender, EventArgs e)
        {
            DialogResult result = _uploadFileOpenFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                _uploadButton.Enabled = true;
                _uploadFilePathTextBox.Text = _uploadFileOpenFileDialog.FileName;
                _uploadFileName = _uploadFileOpenFileDialog.FileName;
            }
        }

        private void ClickUploadButton(object sender, EventArgs e)
        {
            const string CONTENT_TYPE = "image/jpeg";
            Console.WriteLine(_uploadFileName);
            _service.UploadFile(_uploadFileName, CONTENT_TYPE);
        }

        private void ClickListFileOnRootButton(object sender, EventArgs e)
        {
            const string DISPLAY_MEMBER = "Title";
            const string VALUE_MEMBER = "Id";
            const string FOLDER_MIME_TYPE = @"application/vnd.google-apps.folder";

            List<Google.Apis.Drive.v2.Data.File> rootFolderFiles = _service.ListRootFileAndFolder();
            rootFolderFiles.RemoveAll(i =>
            {
                return i.MimeType == FOLDER_MIME_TYPE;
            });

            _fileListBox.DisplayMember = DISPLAY_MEMBER;
            _fileListBox.ValueMember = VALUE_MEMBER;
            _fileListBox.DataSource = rootFolderFiles;

            _downloadBrowseButton.Enabled = true;
        }

        private void ClickDownloadBrowseButton(object sender, EventArgs e)
        {
            DialogResult result = _downloadFolderBrowserDialog.ShowDialog();
            if (result==System.Windows.Forms.DialogResult.OK)
            {
                _downloadPath = _downloadFolderBrowserDialog.SelectedPath;
                _downloadToTextBox.Text = _downloadPath;
                _downloadButton.Enabled = true;
            }
        }

        private void ClickDownloadButton(object sender, EventArgs e)
        {
            Google.Apis.Drive.v2.Data.File selectedFile = _fileListBox.SelectedItem as Google.Apis.Drive.v2.Data.File;
            _service.DownloadFile(selectedFile, _downloadPath);
        }

        private void ClickUpdateButton(object sender, EventArgs e)
        {
            const string UPDATE_FILE_NAME = "updateSample.jpeg";
            const string CONTENT_TYPE = "image/jpeg";
            const string FILE_TITLE_ON_DRIVE = "Sample.jpeg";

            List<Google.Apis.Drive.v2.Data.File> files = _service.ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File file = files.Find(i =>
            {
                return i.Title == FILE_TITLE_ON_DRIVE;
            });
            _service.UpdateFile(UPDATE_FILE_NAME, file.Id, CONTENT_TYPE);
        }

        private void ClickDeleteButton(object sender, EventArgs e)
        {
            const string DELETE_FILE_NAME = "Sample.jpeg";

            var files = _service.ListRootFileAndFolder();
            var file = files.Find(i =>
            {
                return i.Title == DELETE_FILE_NAME;
            });

            _service.DeleteFile(file.Id);
        }
    }
}
