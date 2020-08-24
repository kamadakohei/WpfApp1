

namespace MVVMApp1.ViewModels
{
    internal class MainViewModel : NotificationObject
    {
        private string _upperString;
        /// <summary>
        /// すべて大文字に変換した文字列を取得します。
        /// </summary>
        public string UpperString
        {
            get { return this._upperString; }
            private set { SetProperty(ref this._upperString, value); }
        }

        private string _inputString;
        /// <summary>
        /// 入力文字列を取得または設定します。
        /// </summary>
        public string InputString
        {
            get { return this._inputString; }
            set
            {
               if (SetProperty(ref this._inputString, value))
 {
 // 入力された文字列を大文字に変換します
 this.UpperString = this._inputString.ToUpper();
 // コマンドの実行可能判別結果に影響を与えているので変更通知をおこないます
 this.ClearCommand.RaiseCanExecuteChanged();
 // 出力ウィンドウに結果を表示します
 System.Diagnostics.Debug.WriteLine("UpperString=" + this.UpperString);
 }
            }
        }

        private DelegateCommand _getHttpBodyCommand;
        /// <summary>
        /// クリアコマンドを取得します。
        /// </summary>
        public DelegateCommand ClearCommand
        {
            get
            {
                {
                    return this._clearCommand ?? (this._clearCommand = new DelegateCommand(
                    _ => this.InputString = "",
                    _ => !string.IsNullOrEmpty(this.InputString)));
                }
            }
        }
    }
}
    
