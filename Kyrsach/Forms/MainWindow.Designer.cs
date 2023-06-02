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
            pServer = new Panel();
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
            bStartGameClient = new Button();
            tbServerIp = new TextBox();
            tbServer = new TextBox();
            pServer.SuspendLayout();
            pClient.SuspendLayout();
            SuspendLayout();
            // 
            // pServer
            // 
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
            pServer.Location = new Point(12, 12);
            pServer.Name = "pServer";
            pServer.Size = new Size(218, 220);
            pServer.TabIndex = 0;
            // 
            // bStartGame
            // 
            bStartGame.Location = new Point(12, 167);
            bStartGame.Name = "bStartGame";
            bStartGame.Size = new Size(190, 25);
            bStartGame.TabIndex = 10;
            bStartGame.Text = "Начать игру";
            bStartGame.UseVisualStyleBackColor = true;
            bStartGame.Click += bStartGame_Click;
            // 
            // tbIP1
            // 
            tbIP1.Location = new Point(77, 43);
            tbIP1.Name = "tbIP1";
            tbIP1.Size = new Size(125, 25);
            tbIP1.TabIndex = 9;
            tbIP1.Visible = false;
            // 
            // tbIP2
            // 
            tbIP2.Location = new Point(77, 74);
            tbIP2.Name = "tbIP2";
            tbIP2.Size = new Size(125, 25);
            tbIP2.TabIndex = 8;
            tbIP2.Visible = false;
            // 
            // tbIP4
            // 
            tbIP4.Location = new Point(77, 136);
            tbIP4.Name = "tbIP4";
            tbIP4.Size = new Size(125, 25);
            tbIP4.TabIndex = 7;
            tbIP4.Visible = false;
            // 
            // tbIP3
            // 
            tbIP3.Location = new Point(77, 105);
            tbIP3.Name = "tbIP3";
            tbIP3.Size = new Size(125, 25);
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
            cbCountPlayers.Size = new Size(48, 25);
            cbCountPlayers.TabIndex = 0;
            cbCountPlayers.SelectedIndexChanged += cbCountPlayers_SelectedIndexChanged;
            // 
            // pClient
            // 
            pClient.Controls.Add(bStartGameClient);
            pClient.Controls.Add(tbServerIp);
            pClient.Controls.Add(tbServer);
            pClient.Location = new Point(245, 12);
            pClient.Name = "pClient";
            pClient.Size = new Size(221, 220);
            pClient.TabIndex = 11;
            // 
            // bStartGameClient
            // 
            bStartGameClient.Location = new Point(12, 167);
            bStartGameClient.Name = "bStartGameClient";
            bStartGameClient.Size = new Size(195, 25);
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
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 249);
            Controls.Add(pClient);
            Controls.Add(pServer);
            DoubleBuffered = true;
            Name = "MainWindow";
            Text = "Form1";
            Paint += MainWindow_Paint;
            KeyDown += MainWindow_KeyDown;
            KeyUp += MainWindow_KeyUp;
            pServer.ResumeLayout(false);
            pServer.PerformLayout();
            pClient.ResumeLayout(false);
            pClient.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pServer;
        private ComboBox cbCountPlayers;
        private TextBox textBox1;
        private TextBox tbIP1;
        private TextBox tbIP2;
        private TextBox tbIP4;
        private TextBox tbIP3;
        private TextBox tbPlayer4;
        private TextBox tbPlayer3;
        private TextBox tbPlayer2;
        private TextBox tbPlayer1;
        private Button bStartGame;
        private Panel pClient;
        private Button bStartGameClient;
        private TextBox tbServerIp;
        private TextBox tbServer;
    }
}