namespace Kyrsach
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pGameInfo = new Panel();
            bGameInfoBack = new Button();
            pMainMenu = new Panel();
            bExit = new Button();
            bClient = new Button();
            bServer = new Button();
            pServer = new Panel();
            bServerBack = new Button();
            bStartGame = new Button();
            tbIP1 = new TextBox();
            tbIP2 = new TextBox();
            tbIP4 = new TextBox();
            tbIP3 = new TextBox();
            tbPlayer4 = new TextBox();
            tbPlayer3 = new TextBox();
            tbPlayer2 = new TextBox();
            tbPlayer1 = new TextBox();
            textBox1 = new TextBox();
            cbCountPlayers = new ComboBox();
            pClient = new Panel();
            bClientBack = new Button();
            tbClientIP = new TextBox();
            tbClient = new TextBox();
            bStartGameClient = new Button();
            tbServerIp = new TextBox();
            tbServer = new TextBox();
            pbGameZone = new PictureBox();
            pGameInfo.SuspendLayout();
            pMainMenu.SuspendLayout();
            pServer.SuspendLayout();
            pClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbGameZone).BeginInit();
            SuspendLayout();
            // 
            // pGameInfo
            // 
            pGameInfo.BackColor = Color.Transparent;
            pGameInfo.Controls.Add(bGameInfoBack);
            pGameInfo.Location = new Point(897, 0);
            pGameInfo.Name = "pGameInfo";
            pGameInfo.Size = new Size(344, 900);
            pGameInfo.TabIndex = 14;
            pGameInfo.Visible = false;
            // 
            // bGameInfoBack
            // 
            bGameInfoBack.Location = new Point(88, 850);
            bGameInfoBack.Name = "bGameInfoBack";
            bGameInfoBack.Size = new Size(195, 38);
            bGameInfoBack.TabIndex = 16;
            bGameInfoBack.Text = "В главное меню";
            bGameInfoBack.UseVisualStyleBackColor = true;
            bGameInfoBack.Click += bGameInfoBack_Click;
            // 
            // pMainMenu
            // 
            pMainMenu.BackColor = Color.Transparent;
            pMainMenu.Controls.Add(bExit);
            pMainMenu.Controls.Add(bClient);
            pMainMenu.Controls.Add(bServer);
            pMainMenu.Location = new Point(515, 340);
            pMainMenu.Name = "pMainMenu";
            pMainMenu.Size = new Size(220, 260);
            pMainMenu.TabIndex = 12;
            // 
            // bExit
            // 
            bExit.Location = new Point(12, 210);
            bExit.Name = "bExit";
            bExit.Size = new Size(190, 38);
            bExit.TabIndex = 3;
            bExit.Text = "Выход";
            bExit.UseVisualStyleBackColor = true;
            bExit.Click += bExit_Click;
            // 
            // bClient
            // 
            bClient.Location = new Point(12, 56);
            bClient.Name = "bClient";
            bClient.Size = new Size(190, 38);
            bClient.TabIndex = 1;
            bClient.Text = "Клиент";
            bClient.UseVisualStyleBackColor = true;
            bClient.Click += bClient_Click;
            // 
            // bServer
            // 
            bServer.Location = new Point(12, 12);
            bServer.Name = "bServer";
            bServer.Size = new Size(190, 38);
            bServer.TabIndex = 0;
            bServer.Text = "Сервер";
            bServer.UseVisualStyleBackColor = true;
            bServer.Click += bServer_Click;
            // 
            // pServer
            // 
            pServer.BackColor = Color.Transparent;
            pServer.Controls.Add(bServerBack);
            pServer.Controls.Add(bStartGame);
            pServer.Controls.Add(tbIP1);
            pServer.Controls.Add(tbIP2);
            pServer.Controls.Add(tbIP4);
            pServer.Controls.Add(tbIP3);
            pServer.Controls.Add(tbPlayer4);
            pServer.Controls.Add(tbPlayer3);
            pServer.Controls.Add(tbPlayer2);
            pServer.Controls.Add(tbPlayer1);
            pServer.Controls.Add(textBox1);
            pServer.Controls.Add(cbCountPlayers);
            pServer.Location = new Point(515, 340);
            pServer.Name = "pServer";
            pServer.Size = new Size(220, 260);
            pServer.TabIndex = 0;
            pServer.Visible = false;
            // 
            // bServerBack
            // 
            bServerBack.Location = new Point(12, 210);
            bServerBack.Name = "bServerBack";
            bServerBack.Size = new Size(195, 38);
            bServerBack.TabIndex = 16;
            bServerBack.Text = "В главное меню";
            bServerBack.UseVisualStyleBackColor = true;
            bServerBack.Click += bServerBack_Click;
            // 
            // bStartGame
            // 
            bStartGame.Location = new Point(12, 167);
            bStartGame.Name = "bStartGame";
            bStartGame.Size = new Size(195, 38);
            bStartGame.TabIndex = 10;
            bStartGame.Text = "Начать игру";
            bStartGame.UseVisualStyleBackColor = true;
            bStartGame.Click += bStartGame_Click;
            // 
            // tbIP1
            // 
            tbIP1.Location = new Point(77, 43);
            tbIP1.Name = "tbIP1";
            tbIP1.ReadOnly = true;
            tbIP1.Size = new Size(130, 25);
            tbIP1.TabIndex = 9;
            tbIP1.Visible = false;
            // 
            // tbIP2
            // 
            tbIP2.Location = new Point(77, 74);
            tbIP2.Name = "tbIP2";
            tbIP2.Size = new Size(130, 25);
            tbIP2.TabIndex = 8;
            tbIP2.Visible = false;
            // 
            // tbIP4
            // 
            tbIP4.Location = new Point(77, 136);
            tbIP4.Name = "tbIP4";
            tbIP4.Size = new Size(130, 25);
            tbIP4.TabIndex = 7;
            tbIP4.Visible = false;
            // 
            // tbIP3
            // 
            tbIP3.Location = new Point(77, 105);
            tbIP3.Name = "tbIP3";
            tbIP3.Size = new Size(130, 25);
            tbIP3.TabIndex = 6;
            tbIP3.Visible = false;
            // 
            // tbPlayer4
            // 
            tbPlayer4.Location = new Point(12, 136);
            tbPlayer4.Name = "tbPlayer4";
            tbPlayer4.ReadOnly = true;
            tbPlayer4.Size = new Size(59, 25);
            tbPlayer4.TabIndex = 5;
            tbPlayer4.Text = "Игрок 4";
            tbPlayer4.Visible = false;
            // 
            // tbPlayer3
            // 
            tbPlayer3.Location = new Point(12, 105);
            tbPlayer3.Name = "tbPlayer3";
            tbPlayer3.ReadOnly = true;
            tbPlayer3.Size = new Size(59, 25);
            tbPlayer3.TabIndex = 4;
            tbPlayer3.Text = "Игрок 3";
            tbPlayer3.Visible = false;
            // 
            // tbPlayer2
            // 
            tbPlayer2.Location = new Point(12, 74);
            tbPlayer2.Name = "tbPlayer2";
            tbPlayer2.ReadOnly = true;
            tbPlayer2.Size = new Size(59, 25);
            tbPlayer2.TabIndex = 3;
            tbPlayer2.Text = "Игрок 2";
            tbPlayer2.Visible = false;
            // 
            // tbPlayer1
            // 
            tbPlayer1.Location = new Point(12, 43);
            tbPlayer1.Name = "tbPlayer1";
            tbPlayer1.ReadOnly = true;
            tbPlayer1.Size = new Size(59, 25);
            tbPlayer1.TabIndex = 2;
            tbPlayer1.Text = "Игрок 1";
            tbPlayer1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(136, 25);
            textBox1.TabIndex = 1;
            textBox1.Text = "Количество игроков";
            // 
            // cbCountPlayers
            // 
            cbCountPlayers.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountPlayers.FormattingEnabled = true;
            cbCountPlayers.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cbCountPlayers.Location = new Point(154, 12);
            cbCountPlayers.Name = "cbCountPlayers";
            cbCountPlayers.Size = new Size(53, 25);
            cbCountPlayers.TabIndex = 0;
            cbCountPlayers.SelectedIndexChanged += cbCountPlayers_SelectedIndexChanged;
            // 
            // pClient
            // 
            pClient.BackColor = Color.Transparent;
            pClient.Controls.Add(bClientBack);
            pClient.Controls.Add(tbClientIP);
            pClient.Controls.Add(tbClient);
            pClient.Controls.Add(bStartGameClient);
            pClient.Controls.Add(tbServerIp);
            pClient.Controls.Add(tbServer);
            pClient.Location = new Point(515, 340);
            pClient.Name = "pClient";
            pClient.Size = new Size(220, 260);
            pClient.TabIndex = 11;
            pClient.Visible = false;
            // 
            // bClientBack
            // 
            bClientBack.Location = new Point(12, 210);
            bClientBack.Name = "bClientBack";
            bClientBack.Size = new Size(195, 38);
            bClientBack.TabIndex = 15;
            bClientBack.Text = "В главное меню";
            bClientBack.UseVisualStyleBackColor = true;
            bClientBack.Click += bClientBack_Click;
            // 
            // tbClientIP
            // 
            tbClientIP.Location = new Point(82, 12);
            tbClientIP.Name = "tbClientIP";
            tbClientIP.ReadOnly = true;
            tbClientIP.Size = new Size(125, 25);
            tbClientIP.TabIndex = 14;
            // 
            // tbClient
            // 
            tbClient.Location = new Point(12, 12);
            tbClient.Name = "tbClient";
            tbClient.ReadOnly = true;
            tbClient.Size = new Size(64, 25);
            tbClient.TabIndex = 13;
            tbClient.Text = "Клиент";
            // 
            // bStartGameClient
            // 
            bStartGameClient.Location = new Point(12, 167);
            bStartGameClient.Name = "bStartGameClient";
            bStartGameClient.Size = new Size(195, 38);
            bStartGameClient.TabIndex = 12;
            bStartGameClient.Text = "Начать игру";
            bStartGameClient.UseVisualStyleBackColor = true;
            bStartGameClient.Click += bStartGameClient_Click;
            // 
            // tbServerIp
            // 
            tbServerIp.Location = new Point(82, 43);
            tbServerIp.Name = "tbServerIp";
            tbServerIp.Size = new Size(125, 25);
            tbServerIp.TabIndex = 11;
            // 
            // tbServer
            // 
            tbServer.Location = new Point(12, 43);
            tbServer.Name = "tbServer";
            tbServer.ReadOnly = true;
            tbServer.Size = new Size(64, 25);
            tbServer.TabIndex = 0;
            tbServer.Text = "Сервер";
            // 
            // pbGameZone
            // 
            pbGameZone.Location = new Point(0, 0);
            pbGameZone.Name = "pbGameZone";
            pbGameZone.Size = new Size(900, 900);
            pbGameZone.TabIndex = 15;
            pbGameZone.TabStop = false;
            pbGameZone.Visible = false;
            pbGameZone.Paint += pbGameZone_Paint;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.Background;
            ClientSize = new Size(1234, 899);
            Controls.Add(pMainMenu);
            Controls.Add(pServer);
            Controls.Add(pClient);
            Controls.Add(pGameInfo);
            Controls.Add(pbGameZone);
            DoubleBuffered = true;
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "2D Танчики";
            KeyDown += MainWindow_KeyDown;
            KeyUp += MainWindow_KeyUp;
            pGameInfo.ResumeLayout(false);
            pMainMenu.ResumeLayout(false);
            pServer.ResumeLayout(false);
            pServer.PerformLayout();
            pClient.ResumeLayout(false);
            pClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbGameZone).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pGameInfo;
        private Button bGameInfoBack;
        private Panel pServer;
        private Button bServerBack;
        private Button bStartGame;
        private TextBox tbIP1;
        private TextBox tbIP2;
        private TextBox tbIP4;
        private TextBox tbIP3;
        private TextBox tbPlayer4;
        private TextBox tbPlayer3;
        private TextBox tbPlayer2;
        private TextBox tbPlayer1;
        private TextBox textBox1;
        private ComboBox cbCountPlayers;
        private Panel pMainMenu;
        private Button bExit;
        private Button bClient;
        private Button bServer;
        private Panel pClient;
        private Button bClientBack;
        private TextBox tbClientIP;
        private TextBox tbClient;
        private Button bStartGameClient;
        private TextBox tbServerIp;
        private TextBox tbServer;
        private PictureBox pbGameZone;
    }
}