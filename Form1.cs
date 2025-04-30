using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace something
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private Button currentTab;
        private WebView2 currentWebView;
        private FullscreenForm currentFullscreenForm;
        private CloseForm currentCloseForm;

        private List<Button> tabButtons;
        private Dictionary<Button, WebView2> tabWebViewMap = new Dictionary<Button, WebView2>();

        private KeyboardHook _keyboardHook;

        public Form1()
        {
            InitializeComponent();
            DwmHelper.EnableDwm(this.Handle);

            _keyboardHook = new KeyboardHook();
            _keyboardHook.F11Pressed += _keyboardHook_F11Pressed;

            tabButtons = new List<Button>();

            this.FormClosing += Form1_FormClosing;

            tabListPanel.MouseDown += tabListPanel_MouseDown;
            tabListPanel.MouseMove += tabListPanel_MouseMove;
            tabListPanel.MouseUp += tabListPanel_MouseUp;

            newTabBtn.Click += newTabBtn_Click;
            closePageBtn.Click += closePageBtn_Click;
            refreshPageBtn.Click += refreshPageBtn_Click;
            pageBackBtn.Click += pageBackBtn_Click;
            pageForwardBtn.Click += pageForwardBtn_Click;

            searchTextBox.KeyDown += searchTextBox_KeyDown;
            searchTextBox.LostFocus += searchTextBox_LostFocus;
            searchTextBox.GotFocus += searchTextBox_GotFocus;

            urlTextBox.KeyDown += urlTextBox_KeyDown;
            urlTextBox.GotFocus += urlTextBox_GotFocus;
        }

        private void newTabBtn_Click(object sender, EventArgs e)
        {
            if (tabButtons.Count < 10)
            {
                addTab("https://google.com");
            }
        }

        private void _keyboardHook_F11Pressed()
        {
            if (currentFullscreenForm != null)
            {
                if (currentFullscreenForm.ContainsFocus)
                {
                    this.Visible = true;
                    this.Controls.Add(currentWebView);
                    currentWebView.BringToFront();
                    this.Focus();

                    currentFullscreenForm.Dispose();
                    currentFullscreenForm = null;
                }
            }
            else
            {
                if (this.ContainsFocus)
                {
                    this.Visible = false;

                    currentFullscreenForm = new FullscreenForm
                    {
                        FormBorderStyle = FormBorderStyle.None,
                        WindowState = FormWindowState.Maximized,
                        Visible = true
                    };
                    currentFullscreenForm.Controls.Add(currentWebView);
                    currentWebView.BringToFront();
                    currentFullscreenForm.Focus();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentCloseForm = new CloseForm
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            if (currentCloseForm.ShowDialog() == DialogResult.Yes)
            {
                _keyboardHook.Unhook();
            }
            else
            {
                e.Cancel = true;

                currentCloseForm.Dispose();
                currentCloseForm = null;
            }
        }

        private void urlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (urlTextBox.TextLength != 0)
                {
                    currentWebView.Focus();

                    string newUrl = urlTextBox.Text.Contains("https://") ? urlTextBox.Text : "https://" + urlTextBox.Text;
                    SwapUrl(newUrl, currentWebView);
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (urlTextBox.TextLength == 0)
                {
                    e.Handled = true;
                }
            }
        }

        private void urlTextBox_GotFocus(object sender, EventArgs e)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += (s, args) =>
            {
                urlTextBox.SelectAll();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                currentWebView.Focus();

                if (Uri.EscapeDataString(searchTextBox.Text) != "Google%20Search" & searchTextBox.TextLength != 0)
                {
                    string newUrl = "https://www.google.com/search?q=" + Uri.EscapeDataString(searchTextBox.Text);
                    SwapUrl(newUrl, currentWebView);
                }

                searchTextBox.Text = "Google Search";
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (searchTextBox.TextLength == 0)
                {
                    e.Handled = true;
                }
            }
        }

        private void searchTextBox_LostFocus(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.Text = "Google Search";
            }
        }

        private void searchTextBox_GotFocus(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Google Search")
            {
                searchTextBox.ResetText();
            }
        }

        private void pageBackBtn_Click(object sender, EventArgs e)
        {
            if (currentWebView.CoreWebView2.CanGoBack)
            {
                currentWebView.CoreWebView2.GoBack();
            }
        }
        private void pageForwardBtn_Click(object sender, EventArgs e)
        {
            if (currentWebView.CoreWebView2.CanGoForward)
            {
                currentWebView.CoreWebView2.GoForward();
            }
        }

        private async void addTab(string url)
        {
            Button newTab = new Button
            {
                BackColor = System.Drawing.Color.FromArgb(184, 209, 210),
                FlatAppearance = { BorderColor = BackColor, CheckedBackColor = BackColor, MouseOverBackColor = BackColor, MouseDownBackColor = BackColor, BorderSize = 0 },
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Margin = new System.Windows.Forms.Padding(0),
                Size = new System.Drawing.Size(201, 25),
                TabIndex = 0,
            };

            WebView2 webView = new WebView2
            {
                Dock = DockStyle.Fill,
            };

            newTab.Click += (s, e) =>
            {
                currentTab = newTab;
                SwapTab(webView);
                OutlineCurrentTab(newTab);
            };

            CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions
            {
                AreBrowserExtensionsEnabled = true
            };

            try
            {
                CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, null, options);
                await webView.EnsureCoreWebView2Async(env);

                string[] directories = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + @"\Extensions");
                foreach (string directory in directories)
                {
                    await webView.CoreWebView2.Profile.AddBrowserExtensionAsync(directory);
                }

                webView.CoreWebView2.DocumentTitleChanged += (ss, ee) =>
                {
                    newTab.Text = webView.CoreWebView2.DocumentTitle;
                };

                webView.CoreWebView2.SourceChanged += (ss, ee) =>
                {
                    if (urlTextBox.Focused)
                    {
                        urlTextBox.Text = webView.CoreWebView2.Source;
                        var timer = new System.Windows.Forms.Timer();
                        timer.Interval = 1;
                        timer.Tick += (s, args) =>
                        {
                            urlTextBox.SelectAll();
                            timer.Stop();
                            timer.Dispose();
                        };
                        timer.Start();
                    }
                    else
                    {
                        urlTextBox.Text = webView.CoreWebView2.Source;
                    }
                };

                webView.CoreWebView2.NewWindowRequested += (ss, ee) =>
                {
                    ee.Handled = true;
                    if (tabButtons.Count < 10)
                    {
                        addTab(ee.Uri);
                    }
                };

                urlTextBox.Focus();
                webView.Source = new Uri(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return;
            }

            if (currentFullscreenForm != null)
            {
                this.Controls.Add(currentWebView);
                currentFullscreenForm.Controls.Add(webView);
            }
            else
            {
                this.Controls.Add(webView);
            }

            tabListPanel.Controls.Add(newTab);
            webView.BringToFront();
            newTabBtn.SendToBack();

            tabWebViewMap[newTab] = webView;
            tabButtons.Add(newTab);
            currentTab = newTab;
            currentWebView = webView;

            OutlineCurrentTab(newTab);
        }

        private void SwapUrl(string url, WebView2 webView)
        {
            try
            {
                webView.Source = new Uri(url);
            }
            catch
            {
                urlTextBox.Text = webView.CoreWebView2.Source;
            }
        }

        private void SwapTab(WebView2 webView)
        {
            webView.BringToFront();
            currentWebView = webView;

            urlTextBox.Text = webView.Source.ToString();
        }

        private void OutlineCurrentTab(Button currentTab)
        {
            foreach (Button tabButton in tabButtons)
            {
                if (tabButton == currentTab)
                {
                    tabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(209)))), ((int)(((byte)(210)))));
                    tabButton.FlatAppearance.MouseOverBackColor = tabButton.BackColor;
                    tabButton.FlatAppearance.MouseDownBackColor = tabButton.BackColor;
                    tabButton.FlatAppearance.CheckedBackColor = tabButton.BackColor;
                    tabButton.FlatAppearance.BorderColor = tabButton.BackColor;
                }
                else
                {
                    tabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
                    tabButton.FlatAppearance.MouseOverBackColor = tabButton.BackColor;
                    tabButton.FlatAppearance.MouseDownBackColor = tabButton.BackColor;
                    tabButton.FlatAppearance.CheckedBackColor = tabButton.BackColor;
                    tabButton.FlatAppearance.BorderColor = tabButton.BackColor;
                }
            }
        }

        private void refreshPageBtn_Click(object sender, EventArgs e)
        {
            if (currentWebView != null)
            {
                currentWebView.CoreWebView2.Reload();
            }
        }

        private void closePageBtn_Click(object sender, EventArgs e)
        {
            if (currentTab == null || tabButtons.Count == 1) return;

            int currentIndex = tabButtons.IndexOf(currentTab);

            if (currentWebView != null)
            {
                this.Controls.Remove(currentWebView);
                currentWebView.Dispose();
                currentWebView = null;
            }

            if (currentTab != null)
            {
                tabListPanel.Controls.Remove(currentTab);
                tabButtons.Remove(currentTab);
                tabWebViewMap.Remove(currentTab);
                currentTab.Dispose();
                currentTab = null;
            }

            if (tabButtons.Count > 0)
            {
                if (currentIndex >= tabButtons.Count)
                {
                    currentIndex = tabButtons.Count - 1;
                }

                currentTab = tabButtons[currentIndex];
                currentWebView = tabWebViewMap[currentTab];

                OutlineCurrentTab(currentTab);

                currentWebView.BringToFront();

                urlTextBox.Text = currentWebView.Source.ToString();
            }
            else
            {
                currentTab = null;
                currentWebView = null;
                urlTextBox.Text = string.Empty;
            }
        }

        private void tabListPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void tabListPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point delta = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(delta));
            }
        }

        private void tabListPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addTab("https://google.com");
        }
    }
}