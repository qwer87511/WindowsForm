using DrawingModel;
using Google.Apis.Download;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    public class DriveServiceAdapter : IDriveService
    {
        // 刪除檔案
        public void DeleteFile(string fileId)
        {
        }

        // 下載檔案
        public void DownloadFile(File fileToDownload, string downloadPath, Action<IDownloadProgress> downloadProgressChangedEventHandler = null)
        {
        }

        // 列出所有檔案
        public List<File> ListRootFileAndFolder()
        {
            return null;
        }

        // 更新檔案
        public File UpdateFile(string fileName, string fileId, string contentType)
        {
            return null;
        }

        // 上傳檔案
        public File UploadFile(string uploadFileName, string contentType, Action<IUploadProgress> uploadProgressEventHandler = null, Action<File> responseReceivedEventHandler = null)
        {
            return null;
        }
    }
}
