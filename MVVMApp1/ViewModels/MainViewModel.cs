

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MVVMApp1.ViewModels
{
    internal class MainViewModel : NotificationObject
    {

        private string _httpStatus;
        /// <summary>
        /// すべて大文字に変換した文字列を取得します。
        /// </summary>
        public string HttpStatus
        {
            get { return this._httpStatus; }
            private set { SetProperty(ref this._httpStatus, value); }
        }

        private string _inputUrl;
        /// <summary>
        /// 入力文字列を取得または設定します。
        /// </summary>
        public string InputUrl
        {
            get { return this._inputUrl; }
            set
            {
               if (SetProperty(ref this._inputUrl, value))
               {
                    // 出力ウィンドウに結果を表示します
                    System.Diagnostics.Debug.WriteLine("GetHttpStatus");
               }
            }
        }

        private DelegateCommand _getHttpStatusCommand;
        /// <summary>
        /// クリアコマンドを取得します。
        /// </summary>
        public DelegateCommand GetHttpStatusCommand
        {
            get
            {
                {
                    return this._getHttpStatusCommand ?? (this._getHttpStatusCommand = new DelegateCommand(
                    (InputUrl) => HttpStatus = GetHttpStatus(InputUrl)));
                }
            }
        }

        private string GetHttpStatus(object inputUrl)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(inputUrl.ToString());
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            return myHttpWebResponse.Headers.ToString();
        }
    }
}
    
