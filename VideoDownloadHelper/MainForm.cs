using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using System.Net;
using System.IO;
using System.Reflection;
using Mono.Addins;
using VideoDownloadHelper.Helper;

[assembly: AddinRoot("VideoDownloadHelper", "1.9", Url = "http://vdhelper.sinaapp.com")]

namespace VideoDownloadHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            String path = Application.StartupPath + "\\plugins";

            AddinManager.Initialize(path, path);
            AddinManager.Registry.Update();
        }

        private void ChangeState(Boolean boolean)
        {
            GetVideoList.Enabled = !boolean;
            VideoInfoList.Enabled = !boolean;
            MessageLabel.Visible = boolean;
            DownSelectItem.Enabled = !boolean;
        }

        IPlugin targetPlugin;

        private void GetVideoList_Click(object sender, EventArgs e)
        {
            String input = TargetUrl.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                MessageBox.Show("请输入网址", "出错了", MessageBoxButtons.OK);
                return;
            }

            bool isVaild = false;
            bool hasPlugin = false;

            targetPlugin = null;

            foreach (IPlugin plugin in AddinManager.GetExtensionObjects<IPlugin>())
            {

                hasPlugin = true;
                if (plugin.isVaild(input))
                {
                    isVaild = true;
                    if (targetPlugin == null)
                    {
                        targetPlugin = plugin;
                    }
                    else if (targetPlugin.GetVersionNumber() < plugin.GetVersionNumber())
                    {
                        targetPlugin = plugin;
                    }
                }
            }

            if (!hasPlugin)
            {
                MessageBox.Show("没有找到插件...\n请检查plugins目录是否存在或者重新下载程序", "出错了", MessageBoxButtons.OK);
                System.Diagnostics.Process.Start("http://vdhelper.sinaapp.com");
                return;
            }

            if (isVaild)
            {
                if (!getlistWorker.IsBusy)
                {
                    VideoInfoList.Items.Clear();
                    ChangeState(true);
                    MessageLabel.Text = "获取中...请等待";
                    getlistWorker.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("上一个任务还没有完成，请等待", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("你输入的地址错误，请检查后重新输入\r\n如果不清楚要输入何种类型的网址，请点击确认访问http://vdhelper.sinaapp.com/support.html", "出错了", MessageBoxButtons.OKCancel))
                {
                    System.Diagnostics.Process.Start("http://vdhelper.sinaapp.com/support.html?"+versionString);
                }
                TargetUrl.Text = string.Empty;
                TargetUrl.Focus();
            }
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            if (VideoInfoList.Items.Count > 0)
            {
                for (int i = 0; i < VideoInfoList.Items.Count; i++)
                {
                    VideoInfoList.Items[i].Checked = true;
                }
            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            if (VideoInfoList.Items.Count > 0)
            {
                for (int i = 0; i < VideoInfoList.Items.Count; i++)
                {
                    VideoInfoList.Items[i].Checked = false;
                }
            }
        }

        private void ExitProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyBlog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://htynkn.cnblogs.com/?td");
        }

        private void TargetUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)13))
            {
                GetVideoList_Click(sender, e);
            }
        }

        private void DownSelectItem_Click(object sender, EventArgs e)
        {
            if (VideoInfoList.Items.Count > 0 && VideoInfoList.CheckedItems.Count > 0)
            {
                MessageLabel.Text = "下载中，请等待...";
                ChangeState(true);
                List<Boolean> listviews = new List<bool>();
                for (int i = 0; i < VideoInfoList.Items.Count; i++)
                {
                    if (VideoInfoList.Items[i].Checked)
                    {
                        listviews.Add(true);
                    }
                    else
                    {
                        listviews.Add(false);
                    }
                }
                Thread thread = new Thread(down);
                thread.IsBackground = true;
                thread.Start(listviews);
            }
            else
            {
                MessageBox.Show("请选择需要下载的视频文件", "提示");
            }
        }

        #region 获取视频列表

        private void getlistWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                targetPlugin.GetList();
                foreach (BaseItem item in targetPlugin.Items)
                {
                    getlistWorker.ReportProgress(1, item);
                }
            }
            catch (WebException)
            {
                getlistWorker.ReportProgress(100, "网络暂时不可用，可能是服务器忙，请稍后再试。\n如确实仍有问题，请联系QQ：512395752");
            }
            catch (FileNotFoundException)
            {
                getlistWorker.ReportProgress(2);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("暂时不支持这种网址"))
                {
                    getlistWorker.ReportProgress(100, "暂时不支持这种网址,换一个吧");
                }
                else
                {
                    getlistWorker.ReportProgress(100, ex.GetType() + " " + ex.Message + "\r\n" + "如果反复尝试均有此错误，可以联系QQ：512395752");
                }
            }
        }

        bool update = true;

        private void getlistWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!updateChecker.IsBusy && update)
            {
                updateChecker.RunWorkerAsync();
                update = false;
            }
            ChangeState(false);
        }

        private void getlistWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                MessageBox.Show(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 1)
            {
                BaseItem item = (BaseItem)e.UserState;
                ListViewItem lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(item.Time);
                VideoInfoList.Items.Add(lvi);
            }
            else if (e.ProgressPercentage == 2)
            {
                if (MessageBox.Show("请检测你的运行环境，程序最低要求net 3.5版本，点击确定前往下载页面", "缺乏运行库文件", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("http://down.tech.sina.com.cn/content/40694.html");
                    this.Close();
                }
            }
        }

        #endregion

        #region 下载事务
        delegate void changeState(Boolean state);

        private void down(Object data)
        {
            List<Boolean> listviews = (List<Boolean>)data;
            bool needDown = false; //是否需要缺少下载工具
            for (int i = 0; i < listviews.Count; i++)
            {
                if (!needDown)
                {
                    if (listviews[i])
                    {
                        try
                        {
                            String targetUrl = targetPlugin.Down(i);
                            if (!targetPlugin.Equals(String.Empty))
                            {
                                System.Diagnostics.Process.Start(targetUrl);
                            }
                            Thread.Sleep(5000);
                        }
                        catch (Win32Exception)
                        {
                            String keyWord = "优酷";
                            String forwardUrl = "http://mobile.youku.com/index/pc";
                            if (TargetUrl.Text.ToLower().Contains("tudou.com"))
                            {
                                keyWord = "土豆";
                                forwardUrl = "http://www.tudou.com/soft/itudou.html";
                            }
                            needDown = true;
                            if (MessageBox.Show("你没有安装" + keyWord + "下载工具，点击确认安装。\n如果你确认你已经安装，请重启后再试。", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                            {
                                System.Diagnostics.Process.Start(forwardUrl);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.GetType() + " " + ex.Message);
                        }
                        finally
                        {
                            changeState c = new changeState(ChangeState);
                            if (DownSelectItem.InvokeRequired)
                            {
                                DownSelectItem.Invoke(c, new object[] { false });
                            }
                        }
                    }
                }
            }
        }
        #endregion

        String versionString = String.Empty;

        private void MainForm_Load(object sender, EventArgs e)
        {
            String[] names = { "Licence.txt" };
            String notice = ProgramHelper.CheckFiles(names);
            if (notice.Length > 0)
            {
                if (MessageBox.Show(notice + "\n点击确定跳到下载页面", "缺少必要的文件", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("http://vdhelper.sinaapp.com");
                }
                this.Close();
            }
            Version ApplicationVersion = new Version(Application.ProductVersion);
            versionString=ApplicationVersion.Major + "." + ApplicationVersion.Minor;
            currentVersion.Text = "当前版本：V" + versionString;
            this.Text = this.Text + " V" + versionString;
            if (!Properties.Settings.Default.isAgree)
            {
                if (new ReadLicence().ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    Close();
                }
            }
        }

        private void updateChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String[] updateInfo = ProgramHelper.UpdateCheck().Split(',');
                int number = int.Parse(updateInfo[1]);
                if (number > ProgramHelper.number)
                {
                    updateChecker.ReportProgress(100, updateInfo);
                }
            }
            catch
            {

            }
        }

        private void updateChecker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                String[] temp = (String[])e.UserState;
                if (temp.Length == 4)
                {
                    UpdateWindow uw = new UpdateWindow(temp);
                    uw.ShowDialog();
                }
            }
        }

        private void OfficeSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vdhelper.sinaapp.com");
        }

        private void currentVersion_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vdhelper.sinaapp.com");
        }

        private void UpdatePlugins_Click(object sender, EventArgs e)
        {
            MessageBox.Show("即将提供...请期待");
        }
    }
}
