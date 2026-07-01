using System.Drawing;

namespace GithubManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.tabDiff = new System.Windows.Forms.TabPage();
            this.tabCrawler = new System.Windows.Forms.TabPage();
            this.tabAFB = new System.Windows.Forms.TabPage();
            this.tabStarBack = new System.Windows.Forms.TabPage();
            this.tabRepoHealth = new System.Windows.Forms.TabPage();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tabAchievements = new System.Windows.Forms.TabPage();

            // ============================================================
            // Overview tab
            // ============================================================
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.Left = 10; this.lblStatus.Top = 10; this.lblStatus.Width = 500; this.lblStatus.Text = "Not logged in";

            this.lblFollowers = new System.Windows.Forms.Label();
            this.lblFollowers.Left = 10; this.lblFollowers.Top = 38; this.lblFollowers.Width = 200; this.lblFollowers.Text = "Followers: -";

            this.lblFollowing = new System.Windows.Forms.Label();
            this.lblFollowing.Left = 10; this.lblFollowing.Top = 60; this.lblFollowing.Width = 200; this.lblFollowing.Text = "Following: -";

            this.lblRateLimit = new System.Windows.Forms.Label();
            this.lblRateLimit.Left = 10; this.lblRateLimit.Top = 82; this.lblRateLimit.Width = 300; this.lblRateLimit.Text = "API calls remaining: -";

            this.btnRefreshOverview = new System.Windows.Forms.Button();
            this.btnRefreshOverview.Left = 10; this.btnRefreshOverview.Top = 110; this.btnRefreshOverview.Width = 120; this.btnRefreshOverview.Text = "Refresh";
            this.btnRefreshOverview.Click += new System.EventHandler(this.btnRefreshOverview_Click);

            this.btnChangeToken = new System.Windows.Forms.Button();
            this.btnChangeToken.Left = 140; this.btnChangeToken.Top = 110; this.btnChangeToken.Width = 130; this.btnChangeToken.Text = "Change Token";
            this.btnChangeToken.Click += new System.EventHandler(this.btnChangeToken_Click);

            this.tabOverview.Controls.Add(this.lblStatus);
            this.tabOverview.Controls.Add(this.lblFollowers);
            this.tabOverview.Controls.Add(this.lblFollowing);
            this.tabOverview.Controls.Add(this.lblRateLimit);
            this.tabOverview.Controls.Add(this.btnRefreshOverview);
            this.tabOverview.Controls.Add(this.btnChangeToken);
            this.tabOverview.Text = "Overview";

            // ============================================================
            // Follow Diff tab
            // ============================================================
            this.btnLoadDiff = new System.Windows.Forms.Button();
            this.btnLoadDiff.Left = 10; this.btnLoadDiff.Top = 10; this.btnLoadDiff.Width = 120; this.btnLoadDiff.Text = "Load Diff";
            this.btnLoadDiff.Click += new System.EventHandler(this.btnLoadDiff_Click);

            this.lblDiffStatus = new System.Windows.Forms.Label();
            this.lblDiffStatus.Left = 140; this.lblDiffStatus.Top = 15; this.lblDiffStatus.Width = 640; this.lblDiffStatus.Text = "";

            this.lvNotFollowingBack = new System.Windows.Forms.ListView();
            this.lvNotFollowingBack.Left = 10; this.lvNotFollowingBack.Top = 42; this.lvNotFollowingBack.Width = 370; this.lvNotFollowingBack.Height = 240;
            this.lvNotFollowingBack.CheckBoxes = true; this.lvNotFollowingBack.View = System.Windows.Forms.View.Details; this.lvNotFollowingBack.FullRowSelect = true;
            this.lvNotFollowingBack.Columns.Add("Doesn't Follow Back", 220);
            this.lvNotFollowingBack.Columns.Add("Following Since", 130);

            this.btnSelectAllNotFollowingBack = new System.Windows.Forms.Button();
            this.btnSelectAllNotFollowingBack.Left = 10; this.btnSelectAllNotFollowingBack.Top = 288; this.btnSelectAllNotFollowingBack.Width = 100; this.btnSelectAllNotFollowingBack.Text = "Select All";
            this.btnSelectAllNotFollowingBack.Click += new System.EventHandler(this.btnSelectAllNotFollowingBack_Click);

            this.btnUnfollowSelected = new System.Windows.Forms.Button();
            this.btnUnfollowSelected.Left = 118; this.btnUnfollowSelected.Top = 288; this.btnUnfollowSelected.Width = 130; this.btnUnfollowSelected.Text = "Unfollow Selected";
            this.btnUnfollowSelected.Click += new System.EventHandler(this.btnUnfollowSelected_Click);

            this.btnAddToKeep = new System.Windows.Forms.Button();
            this.btnAddToKeep.Left = 256; this.btnAddToKeep.Top = 288; this.btnAddToKeep.Width = 120; this.btnAddToKeep.Text = "→ Keep List";
            this.btnAddToKeep.Click += new System.EventHandler(this.btnAddToKeep_Click);

            this.lvNotFollowedYet = new System.Windows.Forms.ListView();
            this.lvNotFollowedYet.Left = 395; this.lvNotFollowedYet.Top = 42; this.lvNotFollowedYet.Width = 385; this.lvNotFollowedYet.Height = 240;
            this.lvNotFollowedYet.CheckBoxes = true; this.lvNotFollowedYet.View = System.Windows.Forms.View.Details; this.lvNotFollowedYet.FullRowSelect = true;
            this.lvNotFollowedYet.Columns.Add("Follows You (Unreciprocated)", 250);
            this.lvNotFollowedYet.Columns.Add("Age", 110);

            this.btnSelectAllNotFollowedYet = new System.Windows.Forms.Button();
            this.btnSelectAllNotFollowedYet.Left = 395; this.btnSelectAllNotFollowedYet.Top = 288; this.btnSelectAllNotFollowedYet.Width = 100; this.btnSelectAllNotFollowedYet.Text = "Select All";
            this.btnSelectAllNotFollowedYet.Click += new System.EventHandler(this.btnSelectAllNotFollowedYet_Click);

            this.btnFollowSelected = new System.Windows.Forms.Button();
            this.btnFollowSelected.Left = 503; this.btnFollowSelected.Top = 288; this.btnFollowSelected.Width = 140; this.btnFollowSelected.Text = "Follow Selected";
            this.btnFollowSelected.Click += new System.EventHandler(this.btnFollowSelected_Click);

            this.btnCancelBulk = new System.Windows.Forms.Button();
            this.btnCancelBulk.Left = 651; this.btnCancelBulk.Top = 288; this.btnCancelBulk.Width = 80; this.btnCancelBulk.Text = "Cancel";
            this.btnCancelBulk.Click += new System.EventHandler(this.btnCancelBulk_Click);

            this.lblKeepListHeader = new System.Windows.Forms.Label();
            this.lblKeepListHeader.Left = 10; this.lblKeepListHeader.Top = 320; this.lblKeepListHeader.Width = 350; this.lblKeepListHeader.Text = "Keep List (always excluded from unfollow):";
            this.lblKeepListHeader.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.lvKeepList = new System.Windows.Forms.ListView();
            this.lvKeepList.Left = 10; this.lvKeepList.Top = 340; this.lvKeepList.Width = 580; this.lvKeepList.Height = 120;
            this.lvKeepList.View = System.Windows.Forms.View.Details; this.lvKeepList.FullRowSelect = true; this.lvKeepList.MultiSelect = true;
            this.lvKeepList.Columns.Add("Username", 280);
            this.lvKeepList.Columns.Add("Added", 275);

            this.btnRemoveFromKeep = new System.Windows.Forms.Button();
            this.btnRemoveFromKeep.Left = 600; this.btnRemoveFromKeep.Top = 340; this.btnRemoveFromKeep.Width = 180; this.btnRemoveFromKeep.Height = 40; this.btnRemoveFromKeep.Text = "Remove from Keep List";
            this.btnRemoveFromKeep.Click += new System.EventHandler(this.btnRemoveFromKeep_Click);

            this.lstLog = new System.Windows.Forms.ListBox();
            this.lstLog.Left = 10; this.lstLog.Top = 470; this.lstLog.Width = 770; this.lstLog.Height = 90;

            this.tabDiff.Controls.Add(this.btnLoadDiff);
            this.tabDiff.Controls.Add(this.lblDiffStatus);
            this.tabDiff.Controls.Add(this.lvNotFollowingBack);
            this.tabDiff.Controls.Add(this.btnSelectAllNotFollowingBack);
            this.tabDiff.Controls.Add(this.btnUnfollowSelected);
            this.tabDiff.Controls.Add(this.btnAddToKeep);
            this.tabDiff.Controls.Add(this.lvNotFollowedYet);
            this.tabDiff.Controls.Add(this.btnSelectAllNotFollowedYet);
            this.tabDiff.Controls.Add(this.btnFollowSelected);
            this.tabDiff.Controls.Add(this.btnCancelBulk);
            this.tabDiff.Controls.Add(this.lblKeepListHeader);
            this.tabDiff.Controls.Add(this.lvKeepList);
            this.tabDiff.Controls.Add(this.btnRemoveFromKeep);
            this.tabDiff.Controls.Add(this.lstLog);
            this.tabDiff.Text = "Follow Diff";

            // ============================================================
            // Crawler tab
            // ============================================================
            this.lblTargetUser = new System.Windows.Forms.Label();
            this.lblTargetUser.Left = 10; this.lblTargetUser.Top = 10; this.lblTargetUser.Width = 185; this.lblTargetUser.Text = "Pull candidates from user:";

            this.txtTargetUser = new System.Windows.Forms.TextBox();
            this.txtTargetUser.Left = 10; this.txtTargetUser.Top = 30; this.txtTargetUser.Width = 180;

            this.btnValidateTarget = new System.Windows.Forms.Button();
            this.btnValidateTarget.Left = 198; this.btnValidateTarget.Top = 28; this.btnValidateTarget.Width = 65; this.btnValidateTarget.Text = "Validate";
            this.btnValidateTarget.Click += new System.EventHandler(this.btnValidateTarget_Click);

            this.btnPullCandidates = new System.Windows.Forms.Button();
            this.btnPullCandidates.Left = 270; this.btnPullCandidates.Top = 28; this.btnPullCandidates.Width = 55; this.btnPullCandidates.Text = "Pull";
            this.btnPullCandidates.Click += new System.EventHandler(this.btnPullCandidates_Click);

            this.rbSourceFollowers = new System.Windows.Forms.RadioButton();
            this.rbSourceFollowers.Left = 10; this.rbSourceFollowers.Top = 56; this.rbSourceFollowers.Width = 145; this.rbSourceFollowers.Text = "Their followers"; this.rbSourceFollowers.Checked = true;

            this.rbSourceFollowing = new System.Windows.Forms.RadioButton();
            this.rbSourceFollowing.Left = 158; this.rbSourceFollowing.Top = 56; this.rbSourceFollowing.Width = 145; this.rbSourceFollowing.Text = "Who they follow";

            this.chkQualityFilter = new System.Windows.Forms.CheckBox();
            this.chkQualityFilter.Left = 10; this.chkQualityFilter.Top = 78; this.chkQualityFilter.Width = 310; this.chkQualityFilter.Text = "Apply quality filter (1 extra API call/candidate)";

            this.lblMinRepos = new System.Windows.Forms.Label();
            this.lblMinRepos.Left = 10; this.lblMinRepos.Top = 100; this.lblMinRepos.Width = 110; this.lblMinRepos.Text = "Min public repos:";

            this.numMinRepos = new System.Windows.Forms.NumericUpDown();
            this.numMinRepos.Left = 128; this.numMinRepos.Top = 98; this.numMinRepos.Width = 70; this.numMinRepos.Minimum = 0; this.numMinRepos.Maximum = 1000; this.numMinRepos.Value = 1;

            this.lblMaxRatio = new System.Windows.Forms.Label();
            this.lblMaxRatio.Left = 10; this.lblMaxRatio.Top = 124; this.lblMaxRatio.Width = 110; this.lblMaxRatio.Text = "Max follow ratio:";

            this.numMaxRatio = new System.Windows.Forms.NumericUpDown();
            this.numMaxRatio.Left = 128; this.numMaxRatio.Top = 122; this.numMaxRatio.Width = 70; this.numMaxRatio.Minimum = 1; this.numMaxRatio.Maximum = 1000; this.numMaxRatio.Value = 10;

            this.lblQueueTarget = new System.Windows.Forms.Label();
            this.lblQueueTarget.Left = 10; this.lblQueueTarget.Top = 148; this.lblQueueTarget.Width = 130; this.lblQueueTarget.Text = "Stop after N queued:";

            this.numQueueTarget = new System.Windows.Forms.NumericUpDown();
            this.numQueueTarget.Left = 148; this.numQueueTarget.Top = 146; this.numQueueTarget.Width = 80; this.numQueueTarget.Minimum = 10; this.numQueueTarget.Maximum = 5000; this.numQueueTarget.Value = 200; this.numQueueTarget.Increment = 10;

            this.lblCandidates = new System.Windows.Forms.Label();
            this.lblCandidates.Left = 10; this.lblCandidates.Top = 175; this.lblCandidates.Width = 300; this.lblCandidates.Text = "Candidate queue (filtered):";

            this.txtCandidates = new System.Windows.Forms.TextBox();
            this.txtCandidates.Left = 10; this.txtCandidates.Top = 193; this.txtCandidates.Width = 300; this.txtCandidates.Height = 88;
            this.txtCandidates.Multiline = true; this.txtCandidates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; this.txtCandidates.ReadOnly = true;

            this.picTargetAvatar = new System.Windows.Forms.PictureBox();
            this.picTargetAvatar.Left = 330; this.picTargetAvatar.Top = 10; this.picTargetAvatar.Width = 72; this.picTargetAvatar.Height = 72;
            this.picTargetAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTargetAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTargetName = new System.Windows.Forms.Label();
            this.lblTargetName.Left = 412; this.lblTargetName.Top = 10; this.lblTargetName.Width = 370; this.lblTargetName.Text = "";
            this.lblTargetName.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            this.lblTargetFollowers = new System.Windows.Forms.Label();
            this.lblTargetFollowers.Left = 412; this.lblTargetFollowers.Top = 32; this.lblTargetFollowers.Width = 370; this.lblTargetFollowers.Text = "";

            this.lblTargetFollowing = new System.Windows.Forms.Label();
            this.lblTargetFollowing.Left = 412; this.lblTargetFollowing.Top = 50; this.lblTargetFollowing.Width = 370; this.lblTargetFollowing.Text = "";

            this.lblTargetRepos = new System.Windows.Forms.Label();
            this.lblTargetRepos.Left = 412; this.lblTargetRepos.Top = 68; this.lblTargetRepos.Width = 370; this.lblTargetRepos.Text = "";

            this.lnkTargetProfile = new System.Windows.Forms.LinkLabel();
            this.lnkTargetProfile.Left = 330; this.lnkTargetProfile.Top = 88; this.lnkTargetProfile.Width = 300; this.lnkTargetProfile.Text = "";
            this.lnkTargetProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTargetProfile_LinkClicked);

            this.lblTargetAssessment = new System.Windows.Forms.Label();
            this.lblTargetAssessment.Left = 330; this.lblTargetAssessment.Top = 108; this.lblTargetAssessment.Width = 450; this.lblTargetAssessment.Text = "";
            this.lblTargetAssessment.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            this.lblDailyCap = new System.Windows.Forms.Label();
            this.lblDailyCap.Left = 330; this.lblDailyCap.Top = 138; this.lblDailyCap.Width = 100; this.lblDailyCap.Text = "Daily cap:";

            this.numDailyCap = new System.Windows.Forms.NumericUpDown();
            this.numDailyCap.Left = 450; this.numDailyCap.Top = 136; this.numDailyCap.Width = 80; this.numDailyCap.Minimum = 1; this.numDailyCap.Maximum = 500; this.numDailyCap.Value = 50;

            this.lblMinInterval = new System.Windows.Forms.Label();
            this.lblMinInterval.Left = 330; this.lblMinInterval.Top = 164; this.lblMinInterval.Width = 115; this.lblMinInterval.Text = "Min interval (min):";

            this.numMinInterval = new System.Windows.Forms.NumericUpDown();
            this.numMinInterval.Left = 450; this.numMinInterval.Top = 162; this.numMinInterval.Width = 80; this.numMinInterval.Minimum = 1; this.numMinInterval.Maximum = 1440; this.numMinInterval.Value = 1;

            this.lblMaxInterval = new System.Windows.Forms.Label();
            this.lblMaxInterval.Left = 330; this.lblMaxInterval.Top = 190; this.lblMaxInterval.Width = 115; this.lblMaxInterval.Text = "Max interval (min):";

            this.numMaxInterval = new System.Windows.Forms.NumericUpDown();
            this.numMaxInterval.Left = 450; this.numMaxInterval.Top = 188; this.numMaxInterval.Width = 80; this.numMaxInterval.Minimum = 1; this.numMaxInterval.Maximum = 1440; this.numMaxInterval.Value = 5;

            this.btnStartCrawler = new System.Windows.Forms.Button();
            this.btnStartCrawler.Left = 330; this.btnStartCrawler.Top = 218; this.btnStartCrawler.Width = 155; this.btnStartCrawler.Text = "Start Follow Crawler";
            this.btnStartCrawler.Click += new System.EventHandler(this.btnStartCrawler_Click);

            this.btnStopCrawler = new System.Windows.Forms.Button();
            this.btnStopCrawler.Left = 493; this.btnStopCrawler.Top = 218; this.btnStopCrawler.Width = 110; this.btnStopCrawler.Text = "Stop Crawler"; this.btnStopCrawler.Enabled = false;
            this.btnStopCrawler.Click += new System.EventHandler(this.btnStopCrawler_Click);

            this.lblCrawlerStatus = new System.Windows.Forms.Label();
            this.lblCrawlerStatus.Left = 330; this.lblCrawlerStatus.Top = 250; this.lblCrawlerStatus.Width = 450; this.lblCrawlerStatus.Text = "Crawler idle.";

            this.lblNextFollowCountdown = new System.Windows.Forms.Label();
            this.lblNextFollowCountdown.Left = 330; this.lblNextFollowCountdown.Top = 270; this.lblNextFollowCountdown.Width = 450; this.lblNextFollowCountdown.Text = "";

            this.btnExportCandidates = new System.Windows.Forms.Button();
            this.btnExportCandidates.Left = 10; this.btnExportCandidates.Top = 287; this.btnExportCandidates.Width = 148; this.btnExportCandidates.Text = "Export Candidate Queue";
            this.btnExportCandidates.Click += new System.EventHandler(this.btnExportCandidates_Click);

            this.btnExportFollowLog = new System.Windows.Forms.Button();
            this.btnExportFollowLog.Left = 165; this.btnExportFollowLog.Top = 287; this.btnExportFollowLog.Width = 145; this.btnExportFollowLog.Text = "Export Follow Log";
            this.btnExportFollowLog.Click += new System.EventHandler(this.btnExportFollowLog_Click);

            this.lstCrawlerLog = new System.Windows.Forms.ListBox();
            this.lstCrawlerLog.Left = 10; this.lstCrawlerLog.Top = 317; this.lstCrawlerLog.Width = 770; this.lstCrawlerLog.Height = 240;

            this.tabCrawler.Controls.Add(this.lblTargetUser);
            this.tabCrawler.Controls.Add(this.txtTargetUser);
            this.tabCrawler.Controls.Add(this.btnValidateTarget);
            this.tabCrawler.Controls.Add(this.btnPullCandidates);
            this.tabCrawler.Controls.Add(this.rbSourceFollowers);
            this.tabCrawler.Controls.Add(this.rbSourceFollowing);
            this.tabCrawler.Controls.Add(this.chkQualityFilter);
            this.tabCrawler.Controls.Add(this.lblMinRepos);
            this.tabCrawler.Controls.Add(this.numMinRepos);
            this.tabCrawler.Controls.Add(this.lblMaxRatio);
            this.tabCrawler.Controls.Add(this.numMaxRatio);
            this.tabCrawler.Controls.Add(this.lblQueueTarget);
            this.tabCrawler.Controls.Add(this.numQueueTarget);
            this.tabCrawler.Controls.Add(this.lblCandidates);
            this.tabCrawler.Controls.Add(this.txtCandidates);
            this.tabCrawler.Controls.Add(this.picTargetAvatar);
            this.tabCrawler.Controls.Add(this.lblTargetName);
            this.tabCrawler.Controls.Add(this.lblTargetFollowers);
            this.tabCrawler.Controls.Add(this.lblTargetFollowing);
            this.tabCrawler.Controls.Add(this.lblTargetRepos);
            this.tabCrawler.Controls.Add(this.lnkTargetProfile);
            this.tabCrawler.Controls.Add(this.lblTargetAssessment);
            this.tabCrawler.Controls.Add(this.lblDailyCap);
            this.tabCrawler.Controls.Add(this.numDailyCap);
            this.tabCrawler.Controls.Add(this.lblMinInterval);
            this.tabCrawler.Controls.Add(this.numMinInterval);
            this.tabCrawler.Controls.Add(this.lblMaxInterval);
            this.tabCrawler.Controls.Add(this.numMaxInterval);
            this.tabCrawler.Controls.Add(this.btnStartCrawler);
            this.tabCrawler.Controls.Add(this.btnStopCrawler);
            this.tabCrawler.Controls.Add(this.lblCrawlerStatus);
            this.tabCrawler.Controls.Add(this.lblNextFollowCountdown);
            this.tabCrawler.Controls.Add(this.btnExportCandidates);
            this.tabCrawler.Controls.Add(this.btnExportFollowLog);
            this.tabCrawler.Controls.Add(this.lstCrawlerLog);
            this.tabCrawler.Text = "Crawler";

            // ============================================================
            // Auto Follow-Back tab
            // ============================================================
            this.lblAFBInterval = new System.Windows.Forms.Label();
            this.lblAFBInterval.Left = 10; this.lblAFBInterval.Top = 12; this.lblAFBInterval.Width = 130; this.lblAFBInterval.Text = "Poll interval (min):";

            this.numAFBInterval = new System.Windows.Forms.NumericUpDown();
            this.numAFBInterval.Left = 148; this.numAFBInterval.Top = 10; this.numAFBInterval.Width = 80; this.numAFBInterval.Minimum = 1; this.numAFBInterval.Maximum = 1440; this.numAFBInterval.Value = 30;

            this.btnStartAutoFollowBack = new System.Windows.Forms.Button();
            this.btnStartAutoFollowBack.Left = 240; this.btnStartAutoFollowBack.Top = 8; this.btnStartAutoFollowBack.Width = 140; this.btnStartAutoFollowBack.Text = "Start Auto Follow-Back";
            this.btnStartAutoFollowBack.Click += new System.EventHandler(this.btnStartAutoFollowBack_Click);

            this.btnStopAutoFollowBack = new System.Windows.Forms.Button();
            this.btnStopAutoFollowBack.Left = 388; this.btnStopAutoFollowBack.Top = 8; this.btnStopAutoFollowBack.Width = 80; this.btnStopAutoFollowBack.Text = "Stop"; this.btnStopAutoFollowBack.Enabled = false;
            this.btnStopAutoFollowBack.Click += new System.EventHandler(this.btnStopAutoFollowBack_Click);

            this.btnRunAFBNow = new System.Windows.Forms.Button();
            this.btnRunAFBNow.Left = 476; this.btnRunAFBNow.Top = 8; this.btnRunAFBNow.Width = 110; this.btnRunAFBNow.Text = "Run Once Now";
            this.btnRunAFBNow.Click += new System.EventHandler(this.btnRunAFBNow_Click);

            this.lblAFBStatus = new System.Windows.Forms.Label();
            this.lblAFBStatus.Left = 10; this.lblAFBStatus.Top = 38; this.lblAFBStatus.Width = 500; this.lblAFBStatus.Text = "Idle.";

            this.lblAFBCountdown = new System.Windows.Forms.Label();
            this.lblAFBCountdown.Left = 10; this.lblAFBCountdown.Top = 58; this.lblAFBCountdown.Width = 300; this.lblAFBCountdown.Text = "";

            this.lstAFBLog = new System.Windows.Forms.ListBox();
            this.lstAFBLog.Left = 10; this.lstAFBLog.Top = 82; this.lstAFBLog.Width = 770; this.lstAFBLog.Height = 470;

            this.tabAFB.Controls.Add(this.lblAFBInterval);
            this.tabAFB.Controls.Add(this.numAFBInterval);
            this.tabAFB.Controls.Add(this.btnStartAutoFollowBack);
            this.tabAFB.Controls.Add(this.btnStopAutoFollowBack);
            this.tabAFB.Controls.Add(this.btnRunAFBNow);
            this.tabAFB.Controls.Add(this.lblAFBStatus);
            this.tabAFB.Controls.Add(this.lblAFBCountdown);
            this.tabAFB.Controls.Add(this.lstAFBLog);
            this.tabAFB.Text = "Auto Follow-Back";

            // ============================================================
            // Star-Back tab
            // ============================================================
            this.lblFollowersToScan = new System.Windows.Forms.Label();
            this.lblFollowersToScan.Left = 10; this.lblFollowersToScan.Top = 12; this.lblFollowersToScan.Width = 130; this.lblFollowersToScan.Text = "Followers to scan:";

            this.numFollowersToScan = new System.Windows.Forms.NumericUpDown();
            this.numFollowersToScan.Left = 148; this.numFollowersToScan.Top = 10; this.numFollowersToScan.Width = 80; this.numFollowersToScan.Minimum = 1; this.numFollowersToScan.Maximum = 500; this.numFollowersToScan.Value = 50;

            this.lblMinStarsForStar = new System.Windows.Forms.Label();
            this.lblMinStarsForStar.Left = 240; this.lblMinStarsForStar.Top = 12; this.lblMinStarsForStar.Width = 90; this.lblMinStarsForStar.Text = "Min repo stars:";

            this.numMinStarsForStar = new System.Windows.Forms.NumericUpDown();
            this.numMinStarsForStar.Left = 334; this.numMinStarsForStar.Top = 10; this.numMinStarsForStar.Width = 70; this.numMinStarsForStar.Minimum = 0; this.numMinStarsForStar.Maximum = 10000; this.numMinStarsForStar.Value = 5;

            this.btnLoadStarCandidates = new System.Windows.Forms.Button();
            this.btnLoadStarCandidates.Left = 416; this.btnLoadStarCandidates.Top = 8; this.btnLoadStarCandidates.Width = 130; this.btnLoadStarCandidates.Text = "Load Candidates";
            this.btnLoadStarCandidates.Click += new System.EventHandler(this.btnLoadStarCandidates_Click);

            this.btnCancelStarScan = new System.Windows.Forms.Button();
            this.btnCancelStarScan.Left = 554; this.btnCancelStarScan.Top = 8; this.btnCancelStarScan.Width = 70; this.btnCancelStarScan.Text = "Cancel"; this.btnCancelStarScan.Enabled = false;
            this.btnCancelStarScan.Click += new System.EventHandler(this.btnCancelStarScan_Click);

            this.btnSelectAllStars = new System.Windows.Forms.Button();
            this.btnSelectAllStars.Left = 632; this.btnSelectAllStars.Top = 8; this.btnSelectAllStars.Width = 90; this.btnSelectAllStars.Text = "Select All";
            this.btnSelectAllStars.Click += new System.EventHandler(this.btnSelectAllStars_Click);

            this.btnStarSelected = new System.Windows.Forms.Button();
            this.btnStarSelected.Left = 730; this.btnStarSelected.Top = 8; this.btnStarSelected.Width = 110; this.btnStarSelected.Text = "⭐ Star Checked";
            this.btnStarSelected.Click += new System.EventHandler(this.btnStarSelected_Click);

            this.btnOpenStarUrl = new System.Windows.Forms.Button();
            this.btnOpenStarUrl.Left = 750; this.btnOpenStarUrl.Top = 8; this.btnOpenStarUrl.Width = 108; this.btnOpenStarUrl.Text = "Open in Browser";
            this.btnOpenStarUrl.Click += new System.EventHandler(this.btnOpenStarUrl_Click);

            this.lblStarBackStatus = new System.Windows.Forms.Label();
            this.lblStarBackStatus.Left = 10; this.lblStarBackStatus.Top = 38; this.lblStarBackStatus.Width = 760; this.lblStarBackStatus.Text = "";

            this.dgvStarBack = new System.Windows.Forms.DataGridView();
            this.dgvStarBack.Left = 10; this.dgvStarBack.Top = 58; this.dgvStarBack.Width = 770; this.dgvStarBack.Height = 390;
            this.dgvStarBack.AllowUserToAddRows = false; this.dgvStarBack.ReadOnly = false;
            this.dgvStarBack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStarBack.Columns.Add(new System.Windows.Forms.DataGridViewCheckBoxColumn { HeaderText = "Star?", Width = 50 });
            this.dgvStarBack.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Repo", Width = 300, ReadOnly = true });
            this.dgvStarBack.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Stars", Width = 70, ReadOnly = true });
            this.dgvStarBack.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "URL", Width = 320, ReadOnly = true });

            this.lstStarBackLog = new System.Windows.Forms.ListBox();
            this.lstStarBackLog.Left = 10; this.lstStarBackLog.Top = 458; this.lstStarBackLog.Width = 770; this.lstStarBackLog.Height = 98;

            this.tabStarBack.Controls.Add(this.lblFollowersToScan);
            this.tabStarBack.Controls.Add(this.numFollowersToScan);
            this.tabStarBack.Controls.Add(this.lblMinStarsForStar);
            this.tabStarBack.Controls.Add(this.numMinStarsForStar);
            this.tabStarBack.Controls.Add(this.btnLoadStarCandidates);
            this.tabStarBack.Controls.Add(this.btnCancelStarScan);
            this.tabStarBack.Controls.Add(this.btnSelectAllStars);
            this.tabStarBack.Controls.Add(this.btnStarSelected);
            this.tabStarBack.Controls.Add(this.btnOpenStarUrl);
            this.tabStarBack.Controls.Add(this.lblStarBackStatus);
            this.tabStarBack.Controls.Add(this.dgvStarBack);
            this.tabStarBack.Controls.Add(this.lstStarBackLog);
            this.tabStarBack.Text = "Star-Back";

            // ============================================================
            // Repo Health tab
            // ============================================================
            this.btnScanRepos = new System.Windows.Forms.Button();
            this.btnScanRepos.Left = 10; this.btnScanRepos.Top = 10; this.btnScanRepos.Width = 120; this.btnScanRepos.Text = "Scan My Repos";
            this.btnScanRepos.Click += new System.EventHandler(this.btnScanRepos_Click);

            this.btnOpenRepoUrl = new System.Windows.Forms.Button();
            this.btnOpenRepoUrl.Left = 138; this.btnOpenRepoUrl.Top = 10; this.btnOpenRepoUrl.Width = 120; this.btnOpenRepoUrl.Text = "Open in Browser";
            this.btnOpenRepoUrl.Click += new System.EventHandler(this.btnOpenRepoUrl_Click);

            this.btnQuickFixTopics = new System.Windows.Forms.Button();
            this.btnQuickFixTopics.Left = 266; this.btnQuickFixTopics.Top = 10; this.btnQuickFixTopics.Width = 130; this.btnQuickFixTopics.Text = "Set Topics (selected)";
            this.btnQuickFixTopics.Click += new System.EventHandler(this.btnQuickFixTopics_Click);

            this.lblRepoHealthStatus = new System.Windows.Forms.Label();
            this.lblRepoHealthStatus.Left = 408; this.lblRepoHealthStatus.Top = 15; this.lblRepoHealthStatus.Width = 372; this.lblRepoHealthStatus.Text = "";

            this.dgvRepoHealth = new System.Windows.Forms.DataGridView();
            this.dgvRepoHealth.Left = 10; this.dgvRepoHealth.Top = 40; this.dgvRepoHealth.Width = 770; this.dgvRepoHealth.Height = 520;
            this.dgvRepoHealth.AllowUserToAddRows = false; this.dgvRepoHealth.ReadOnly = true; this.dgvRepoHealth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRepoHealth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Repo", Width = 160 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "⭐", Width = 45 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "README", Width = 65 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Desc", Width = 45 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Topics", Width = 180 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "URL", Width = 45 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Activity", Width = 75 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Health", Width = 80 });
            this.dgvRepoHealth.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "GitHub URL", Width = 60 });

            this.tabRepoHealth.Controls.Add(this.btnScanRepos);
            this.tabRepoHealth.Controls.Add(this.btnOpenRepoUrl);
            this.tabRepoHealth.Controls.Add(this.btnQuickFixTopics);
            this.tabRepoHealth.Controls.Add(this.lblRepoHealthStatus);
            this.tabRepoHealth.Controls.Add(this.dgvRepoHealth);
            this.tabRepoHealth.Text = "Repo Health";

            // ============================================================
            // Profile Preview tab
            // ============================================================
            this.btnRefreshProfile = new System.Windows.Forms.Button();
            this.btnRefreshProfile.Left = 10; this.btnRefreshProfile.Top = 10; this.btnRefreshProfile.Width = 90; this.btnRefreshProfile.Text = "Refresh";
            this.btnRefreshProfile.Click += new System.EventHandler(this.btnRefreshProfile_Click);

            this.btnOpenProfileBrowser = new System.Windows.Forms.Button();
            this.btnOpenProfileBrowser.Left = 108; this.btnOpenProfileBrowser.Top = 10; this.btnOpenProfileBrowser.Width = 120; this.btnOpenProfileBrowser.Text = "Open in Browser";
            this.btnOpenProfileBrowser.Click += new System.EventHandler(this.btnOpenProfileBrowser_Click);

            this.lblProfileRefreshInterval = new System.Windows.Forms.Label();
            this.lblProfileRefreshInterval.Left = 240; this.lblProfileRefreshInterval.Top = 13; this.lblProfileRefreshInterval.Width = 110; this.lblProfileRefreshInterval.Text = "Auto-refresh (sec):";

            this.numProfileRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.numProfileRefreshInterval.Left = 354; this.numProfileRefreshInterval.Top = 10; this.numProfileRefreshInterval.Width = 70; this.numProfileRefreshInterval.Minimum = 1; this.numProfileRefreshInterval.Maximum = 3600; this.numProfileRefreshInterval.Value = 30;

            this.btnStartProfileAutoRefresh = new System.Windows.Forms.Button();
            this.btnStartProfileAutoRefresh.Left = 432; this.btnStartProfileAutoRefresh.Top = 8; this.btnStartProfileAutoRefresh.Width = 110; this.btnStartProfileAutoRefresh.Text = "Start Auto-Refresh";
            this.btnStartProfileAutoRefresh.Click += new System.EventHandler(this.btnStartProfileAutoRefresh_Click);

            this.btnStopProfileAutoRefresh = new System.Windows.Forms.Button();
            this.btnStopProfileAutoRefresh.Left = 550; this.btnStopProfileAutoRefresh.Top = 8; this.btnStopProfileAutoRefresh.Width = 60; this.btnStopProfileAutoRefresh.Text = "Stop"; this.btnStopProfileAutoRefresh.Enabled = false;
            this.btnStopProfileAutoRefresh.Click += new System.EventHandler(this.btnStopProfileAutoRefresh_Click);

            this.lblProfileStatus = new System.Windows.Forms.Label();
            this.lblProfileStatus.Left = 622; this.lblProfileStatus.Top = 13; this.lblProfileStatus.Width = 158; this.lblProfileStatus.Text = "";

            this.webProfile = new System.Windows.Forms.WebBrowser();
            this.webProfile.Left = 10; this.webProfile.Top = 60; this.webProfile.Width = 770; this.webProfile.Height = 500;
            this.webProfile.ScriptErrorsSuppressed = true;

            this.tabProfile.Controls.Add(this.btnRefreshProfile);
            this.tabProfile.Controls.Add(this.btnOpenProfileBrowser);
            this.tabProfile.Controls.Add(this.lblProfileRefreshInterval);
            this.tabProfile.Controls.Add(this.numProfileRefreshInterval);
            this.tabProfile.Controls.Add(this.btnStartProfileAutoRefresh);
            this.tabProfile.Controls.Add(this.btnStopProfileAutoRefresh);
            this.tabProfile.Controls.Add(this.lblProfileStatus);
            this.tabProfile.Controls.Add(this.webProfile);
            this.tabProfile.Text = "Profile";
            this.tabProfile.Enter += new System.EventHandler(this.tabProfile_Enter);

            // ============================================================
            // Achievements tab
            // ============================================================
            this.btnCheckAchievements = new System.Windows.Forms.Button();
            this.btnCheckAchievements.Left = 10; this.btnCheckAchievements.Top = 10; this.btnCheckAchievements.Width = 160; this.btnCheckAchievements.Text = "Check My Achievements";
            this.btnCheckAchievements.Click += new System.EventHandler(this.btnCheckAchievements_Click);

            this.lblAchievementStatus = new System.Windows.Forms.Label();
            this.lblAchievementStatus.Left = 180; this.lblAchievementStatus.Top = 14; this.lblAchievementStatus.Width = 580; this.lblAchievementStatus.Text = "Click Check to load your achievement progress.";

            this.dgvAchievements = new System.Windows.Forms.DataGridView();
            this.dgvAchievements.Left = 10; this.dgvAchievements.Top = 40; this.dgvAchievements.Width = 770; this.dgvAchievements.Height = 440;
            this.dgvAchievements.AllowUserToAddRows = false; this.dgvAchievements.ReadOnly = true;
            this.dgvAchievements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAchievements.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Achievement", Width = 165 });
            this.dgvAchievements.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Status", Width = 90 });
            this.dgvAchievements.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Tier", Width = 75 });
            this.dgvAchievements.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Progress", Width = 100 });
            this.dgvAchievements.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Next Goal", Width = 80 });
            this.dgvAchievements.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Description", Width = 220 });
            this.dgvAchievements.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Notes", Width = 200 });

            this.btnOpenAchievementUrl = new System.Windows.Forms.Button();
            this.btnOpenAchievementUrl.Left = 10; this.btnOpenAchievementUrl.Top = 490; this.btnOpenAchievementUrl.Width = 160; this.btnOpenAchievementUrl.Text = "Open in Browser";
            this.btnOpenAchievementUrl.Click += new System.EventHandler(this.btnOpenAchievementUrl_Click);

            this.btnHowToUnlock = new System.Windows.Forms.Button();
            this.btnHowToUnlock.Left = 178; this.btnHowToUnlock.Top = 490; this.btnHowToUnlock.Width = 160; this.btnHowToUnlock.Text = "How To Unlock";
            this.btnHowToUnlock.Click += new System.EventHandler(this.btnHowToUnlock_Click);

            this.tabAchievements.Controls.Add(this.btnCheckAchievements);
            this.tabAchievements.Controls.Add(this.lblAchievementStatus);
            this.tabAchievements.Controls.Add(this.dgvAchievements);
            this.tabAchievements.Controls.Add(this.btnOpenAchievementUrl);
            this.tabAchievements.Controls.Add(this.btnHowToUnlock);
            this.tabAchievements.Text = "Achievements";

            // ============================================================
            // Tab control + Form
            // ============================================================
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.TabPages.Add(this.tabOverview);
            this.tabControl1.TabPages.Add(this.tabDiff);
            this.tabControl1.TabPages.Add(this.tabCrawler);
            this.tabControl1.TabPages.Add(this.tabAFB);
            this.tabControl1.TabPages.Add(this.tabStarBack);
            this.tabControl1.TabPages.Add(this.tabRepoHealth);
            this.tabControl1.TabPages.Add(this.tabProfile);
            this.tabControl1.TabPages.Add(this.tabAchievements);

            this.ClientSize = new Size(800, 620);
            this.Controls.Add(this.tabControl1);
            this.Text = "GitHub Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        // Overview
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOverview, tabDiff, tabCrawler, tabAFB, tabStarBack, tabRepoHealth, tabProfile;
        private System.Windows.Forms.Label lblStatus, lblFollowers, lblFollowing, lblRateLimit;
        private System.Windows.Forms.Button btnRefreshOverview;
        private System.Windows.Forms.Button btnChangeToken;

        // Diff
        private System.Windows.Forms.Button btnLoadDiff, btnUnfollowSelected, btnFollowSelected, btnCancelBulk;
        private System.Windows.Forms.Button btnSelectAllNotFollowingBack, btnSelectAllNotFollowedYet;
        private System.Windows.Forms.Button btnAddToKeep, btnRemoveFromKeep;
        private System.Windows.Forms.Label lblDiffStatus, lblKeepListHeader;
        private System.Windows.Forms.ListView lvNotFollowingBack, lvNotFollowedYet, lvKeepList;
        private System.Windows.Forms.ListBox lstLog;

        // Crawler
        private System.Windows.Forms.Label lblTargetUser, lblCandidates, lblMinRepos, lblMaxRatio;
        private System.Windows.Forms.Label lblQueueTarget, lblDailyCap, lblMinInterval, lblMaxInterval;
        private System.Windows.Forms.Label lblCrawlerStatus, lblNextFollowCountdown;
        private System.Windows.Forms.Label lblTargetName, lblTargetFollowers, lblTargetFollowing, lblTargetRepos, lblTargetAssessment;
        private System.Windows.Forms.TextBox txtTargetUser, txtCandidates;
        private System.Windows.Forms.Button btnValidateTarget, btnPullCandidates, btnStartCrawler, btnStopCrawler;
        private System.Windows.Forms.Button btnExportCandidates, btnExportFollowLog;
        private System.Windows.Forms.RadioButton rbSourceFollowers, rbSourceFollowing;
        private System.Windows.Forms.CheckBox chkQualityFilter;
        private System.Windows.Forms.NumericUpDown numMinRepos, numMaxRatio, numQueueTarget, numDailyCap, numMinInterval, numMaxInterval;
        private System.Windows.Forms.PictureBox picTargetAvatar;
        private System.Windows.Forms.LinkLabel lnkTargetProfile;
        private System.Windows.Forms.ListBox lstCrawlerLog;

        // Auto Follow-Back
        private System.Windows.Forms.Label lblAFBInterval, lblAFBStatus, lblAFBCountdown;
        private System.Windows.Forms.NumericUpDown numAFBInterval;
        private System.Windows.Forms.Button btnStartAutoFollowBack, btnStopAutoFollowBack, btnRunAFBNow;
        private System.Windows.Forms.ListBox lstAFBLog;

        // Star-Back
        private System.Windows.Forms.Label lblFollowersToScan, lblMinStarsForStar, lblStarBackStatus;
        private System.Windows.Forms.NumericUpDown numFollowersToScan, numMinStarsForStar;
        private System.Windows.Forms.Button btnLoadStarCandidates, btnCancelStarScan, btnSelectAllStars, btnStarSelected, btnOpenStarUrl;
        private System.Windows.Forms.DataGridView dgvStarBack;
        private System.Windows.Forms.ListBox lstStarBackLog;

        // Repo Health
        private System.Windows.Forms.Button btnScanRepos, btnOpenRepoUrl, btnQuickFixTopics;
        private System.Windows.Forms.Label lblRepoHealthStatus;
        private System.Windows.Forms.DataGridView dgvRepoHealth;

        // Profile
        private System.Windows.Forms.Button btnRefreshProfile, btnOpenProfileBrowser;
        private System.Windows.Forms.Button btnStartProfileAutoRefresh, btnStopProfileAutoRefresh;
        private System.Windows.Forms.Label lblProfileRefreshInterval, lblProfileStatus;
        private System.Windows.Forms.NumericUpDown numProfileRefreshInterval;
        private System.Windows.Forms.WebBrowser webProfile;

        // Achievements
        private System.Windows.Forms.TabPage tabAchievements;
        private System.Windows.Forms.Button btnCheckAchievements, btnOpenAchievementUrl, btnHowToUnlock;
        private System.Windows.Forms.Label lblAchievementStatus;
        private System.Windows.Forms.DataGridView dgvAchievements;
    }
}