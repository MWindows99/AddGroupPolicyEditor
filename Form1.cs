using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddGroupPolicyEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Label文字変更
            progress.Text = "Waiting...";

            // 確認する
            DialogResult dialogResult = MessageBox.Show(
                "インストールを開始してもよろしいですか？",
                "Question",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                // ボタンを無効にする
                button1.Enabled = false;
                exit.Enabled = false;

                // ここから処理

                // プロセス起動情報構築
                ProcessStartInfo startInfo = new ProcessStartInfo();

                // バッチファイル
                startInfo.FileName = "cmd.exe";

                // コマンド処理実行後、コマンドプロンプトを終了
                startInfo.Arguments = "/c ";

                // コマンド処理であるバッチファイル
                startInfo.Arguments += @"instpro.bat ";

                startInfo.CreateNoWindow = true; // コマンドプロンプトを非表示
                startInfo.UseShellExecute = false; // シェル機能オフ

                // バッチファイルを起動
                var proc = Process.Start(startInfo);

                // Label文字変更
                progress.Text = "実行中...";

                // 上記バッチ処理が終了するまで待機
                proc.WaitForExit();

                // Label文字変更
                progress.Text = "終了.";

                // メッセージを表示する
                MessageBox.Show("インストールが完了しました。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                // 終了処理
                Application.Exit();

            }
            else
            {

                // Label文字変更
                progress.Text = "キャンセル.";

                // メッセージを表示する
                MessageBox.Show("キャンセルしました。","Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                // 再実行に備える
                progress.Text = "待機中 (準備完了)";
            }


        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
