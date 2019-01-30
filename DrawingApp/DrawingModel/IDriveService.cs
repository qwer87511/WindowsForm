using Google.Apis.Download;
using Google.Apis.Upload;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public interface IDriveService
    {
        // 列出所有檔案
        List<Google.Apis.Drive.v2.Data.File> ListRootFileAndFolder();

        // 上傳檔案
        Google.Apis.Drive.v2.Data.File UploadFile(string uploadFileName, string contentType, Action<IUploadProgress> uploadProgressEventHandler = null, Action<Google.Apis.Drive.v2.Data.File> responseReceivedEventHandler = null);

        // 下載檔案
        void DownloadFile(Google.Apis.Drive.v2.Data.File fileToDownload, string downloadPath, Action<IDownloadProgress> downloadProgressChangedEventHandler = null);

        // 刪除檔案
        void DeleteFile(string fileId);

        // 更新檔案
        Google.Apis.Drive.v2.Data.File UpdateFile(string fileName, string fileId, string contentType);
    }
}
