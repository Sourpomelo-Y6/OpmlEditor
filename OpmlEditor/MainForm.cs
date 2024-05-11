using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpmlEditor
{
    public partial class MainForm : Form
    {
        Random rand;
        Opml mainOpml;
        String nowFileName;

        public MainForm()
        {
            InitializeComponent();

            mainOpml = new Opml()
            {
                head = new Head()
                {
                    title = "test"
                },
                body = new Body()
                {
                    outlines = new List<Outline>()
                }
            };

            rand = new Random();

            nowFileName = "";

            timerMain.Start();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("test");
            mainOpml.body.outlines.Add(
                new Outline() {
                    text = "test",
                    title = "test",
                    desctiption = "",
                    SubOutlines = new List<Outline>()
                });
        }

        private void toolStripButton_AddInner_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null) 
            {
                treeView1.SelectedNode.Nodes.Add("test_Inner");
                GetSelNodeIndex();

                Outline search = mainOpml.body.outlines[listNodeId[0]];
                for (int i = 1; i < listNodeId.Count;i++) 
                {
                    search = search.SubOutlines[listNodeId[i]];
                }

                search.SubOutlines.Add(
                new Outline()
                {
                    text = "test_Inner",
                    title = "test_Inner",
                    desctiption = "",
                    SubOutlines = new List<Outline>()
                });
            }
        }

        private void toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                GetSelNodeIndex();

                Outline old = null;
                Outline search = mainOpml.body.outlines[listNodeId[0]];
                for (int i = 1; i < listNodeId.Count; i++)
                {
                    old = search;
                    search = search.SubOutlines[listNodeId[i]];
                }

                if (old != null)
                {
                    old.SubOutlines.Remove(search);
                }
                else 
                {
                    mainOpml.body.outlines.Remove(search);
                }

                treeView1.SelectedNode.Remove();
                treeView1.SelectedNode = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://dobon.net/vb/dotnet/form/openfiledialog.html"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "OPMLファイル(*.opml)|*.opml|すべてのファイル(*.*)|*.*";

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer reader =
                    new System.Xml.Serialization.XmlSerializer(typeof(Opml));

                using (var file = new System.IO.StreamReader(ofd.FileName))
                {
                    Opml opml = (Opml)reader.Deserialize(file);

                    treeView1.Nodes.Clear();

                    var outlines = opml.body.outlines;
                    for (int i = 0; i < outlines.Count; i++) 
                    {
                        treeView1.Nodes.Add(outlines[i].title);

                        SetTreeRecursive(outlines[i],treeView1.Nodes[i]);
                        //var sub = outlines[i].SubOutlines;
                        //for (int j = 0; j < sub.Count ; j++) 
                        //{
                        //    treeView1.Nodes[i].Nodes.Add(sub[j].title);

                        //}
                    }

                    mainOpml = opml;
                    nowFileName = ofd.FileName;
                }
            }
        }

        private void SetTreeRecursive(Outline outline, TreeNode treeNode)
        {
            var sub = outline.SubOutlines;
            for (int j = 0; j < sub.Count; j++) 
            {
                treeNode.Nodes.Add(sub[j].title);
                SetTreeRecursive(sub[j], treeNode.Nodes[j]);
            }
        }


        private void saveSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOrSaveAs();
        }

        void SaveOrSaveAs()
        {
            if (System.IO.File.Exists(nowFileName))
            {
                SaveOpmlFile();
            }
            else
            {
                SaveOpmlFileDialog();
            }
        }

        private void SaveOpmlFile()
        {
            //セーブ前に今書き込んだデータを保持
            if (old_cursor != null)
            {
                old_cursor.desctiption = txtMain.Text;
            }

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Opml));

            using (var file = System.IO.File.Create(nowFileName))
            {
                writer.Serialize(file, mainOpml);
            }

            dataChanged = false;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://dobon.net/vb/dotnet/form/savefiledialog.html"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOpmlFileDialog();
        }

        private void SaveOpmlFileDialog()
        {
            //セーブ前に今書き込んだデータを保持
            if (old_cursor != null)
            {
                old_cursor.desctiption = txtMain.Text;
            }

            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "OPMLファイル(*.opml)|*.opml|すべてのファイル(*.*)|*.*";
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Opml));

                using (var file = System.IO.File.Create(sfd.FileName))
                {
                    writer.Serialize(file, mainOpml);
                }

                dataChanged = false;
            }
        }

        private void closeXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //とあるノードがクリックされたらopml階層構造を読んでdescriptionをtxtMainに表示する
            
        }

        Outline old_cursor = null;

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (old_cursor != null)
            {
                old_cursor.desctiption = txtMain.Text;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetSelNodeIndex();
            
            Outline cursor = mainOpml.body.outlines[listNodeId[0]];
            for (int i = 1; i < listNodeId.Count; i++)
            {
                cursor = cursor.SubOutlines[listNodeId[i]];
            }
            
            txtMain.Text = cursor.desctiption;

            old_cursor = cursor;

            if (previousSelectedNode != null)
            {
                previousSelectedNode.BackColor = treeView1.BackColor;
                previousSelectedNode.ForeColor = treeView1.ForeColor;
            }
        }

        // 変数
        List<int> listNodeId = new List<int>();

        public bool dataChanged { get; private set; }

        /// <summary>
        /// 選択ノードのIndexを取得
        /// </summary>
        /// <see cref="https://effect.hatenablog.com/entry/2019/06/13/153910"/>
        private void GetSelNodeIndex()
        {
            // リストとラベルを空にする
            listNodeId.Clear();

            // 選択ノードを取得
            TreeNode tn = treeView1.SelectedNode;

            // 選択ノードのIndexを取得してListに格納
            listNodeId.Add(tn.Index);

            // 親ノードを取得
            TreeNode tnP = tn.Parent;

            // 再帰処理
            GetSelNodeRecursive(tnP);

            // ラベルに表示（とりあえず雑に）
            //foreach (var item in listNodeId)
            //{
            //    txtDebug.AppendText(item.ToString() + " ");
            //}

            //txtDebug.AppendText(Environment.NewLine);
        }
        
        /// <summary>
        /// 再帰処理
        /// </summary>
        /// <see cref="https://effect.hatenablog.com/entry/2019/06/13/153910"/>
        /// <param name="tnP"></param>
        private void GetSelNodeRecursive(TreeNode tnP)
        {
            // 親がある場合
            if (tnP != null)
            {
                // 親ノードのIndexを取得してListの先頭に挿入
                listNodeId.Insert(0, tnP.Index);

                // さらに親に対して実行
                GetSelNodeRecursive(tnP.Parent);
            }
        }

        // 最終的に選択したいノードを宣言
        TreeNode selNode;

        // 選択ノードのIndexを取得
        private void SetSelNodeIndex(List<int> listNodeId)
        {
            // リストからトップ階層のノードを取得
            TreeNode tnP = treeView1.Nodes[listNodeId[0]];
            // 最終的に選択したいノードに一旦指定
            selNode = tnP;

            // リストのIndex指定用
            int i = 1;

            // リストに子のIndex情報がある場合
            if (listNodeId.Count > i)
            {
                SetSelNodeRecursive(listNodeId,tnP, i);
            }

            treeView1.Focus();
            treeView1.SelectedNode = selNode;
        }
        // 再帰処理
        private void SetSelNodeRecursive(List<int> listNodeId, TreeNode tnP, int i)
        {
            // リストから1つ下の子ノードを取得
            TreeNode tnC = tnP.Nodes[listNodeId[i]];
            // 最終的に選択したいノードに指定
            selNode = tnC;

            // カウントアップ
            i++;

            // リストに子のIndex情報がある場合
            if (listNodeId.Count > i)
            {
                SetSelNodeRecursive(listNodeId,tnC, i);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://dobon.net/vb/dotnet/control/tvlabeledit.html"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            GetSelNodeIndex();
            Outline cursor = mainOpml.body.outlines[listNodeId[0]];
            for (int i = 1; i < listNodeId.Count; i++)
            {
                cursor = cursor.SubOutlines[listNodeId[i]];
            }

            //変更がなされていない場合e.Labelはnull,(変更がある場合はその内容)
            if (e.Label != null
            && (cursor.text != e.Label
            || cursor.title != e.Label))
            {
                cursor.text = e.Label;
                cursor.title = e.Label;

                dataChanged = true;
            }

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataChanged)
            {
                DialogResult result = MessageBox.Show(
                  "ファイルが変更されています、保存しますか",
                  "確認",
                  MessageBoxButtons.YesNoCancel,
                  MessageBoxIcon.Asterisk,
                  MessageBoxDefaultButton.Button1
                );

                switch (result) 
                {
                    case DialogResult.Yes:
                        SaveOrSaveAs();
                        break;
                    case DialogResult.No:
                        //DoNothing
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
                
            }
        }

        private void txtMain_ModifiedChanged(object sender, EventArgs e)
        {
            dataChanged = true;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            toolStripTxtTimer.Text = DateTime.Now.ToString();
        }

        private void toolStripButton_ToDo_Click(object sender, EventArgs e)
        {
            int now_cursor = txtMain.SelectionStart;

            string workstr = txtMain.Text.Insert(now_cursor, "[ToDo]");

            txtMain.Text = workstr;
            //txtMain.Refresh();

            txtMain.SelectionStart = now_cursor;

            dataChanged = true;
        }

        List<NodeAndLineNo> listNodeAndLineNo = new List<NodeAndLineNo>();
        private TreeNode previousSelectedNode;

        private void toolStripButton_NextDo_Click(object sender, EventArgs e)
        {
            //まずは全探索（でかいファイル弄るときやばそう）
            listNodeAndLineNo.Clear();    

            var outlines = mainOpml.body.outlines;
            for (int i = 0; i < outlines.Count; i++)
            {
                List<int> listNodeNo = new List<int>();
                listNodeNo.Add(i);

                int hitline = outlines[i].desctiption.IndexOf("[ToDo]");
                while (hitline > -1)
                {
                    listNodeAndLineNo.Add(new NodeAndLineNo() { listNodeNo = new List<int>(listNodeNo), LineNo = hitline });
                    hitline = outlines[i].desctiption.IndexOf("[ToDo]",hitline+1);
                }
                SearchToDoTreeRecursive(listNodeNo, outlines[i], treeView1.Nodes[i]);
            }

            //検索結果表示（デバック）
            //txtDebug.AppendText("SearchTest:"+Environment.NewLine);
            //foreach (var item in listNodeAndLineNo)
            //{                
            //    foreach (var item2 in item.listNodeNo) {
            //        txtDebug.AppendText(item2 + " "); 
            //    }
            //    txtDebug.AppendText("(" + item.LineNo + ")");
            //    txtDebug.AppendText(Environment.NewLine);
            //}

            //見つからない場合のメッセージボックス
            if (listNodeAndLineNo.Count == 0) 
            {
                MessageBox.Show("Not Found!", "NextDo",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                //ランダムに選択
                int select_rand = rand.Next(0, listNodeAndLineNo.Count);

                SetSelNodeIndex(listNodeAndLineNo[select_rand].listNodeNo);

                txtMain.Focus();
                txtMain.SelectionStart = listNodeAndLineNo[select_rand].LineNo;
                txtMain.SelectionLength = 6;
            }
        }

        private void SearchToDoTreeRecursive(List<int> listNodeNo, Outline outline, TreeNode treeNode)
        {
            var sub = outline.SubOutlines;
            for (int j = 0; j < sub.Count; j++)
            {
                List<int> listNodeNo2 = new List<int>(listNodeNo);
                listNodeNo2.Add(j);

                int hitline = sub[j].desctiption.IndexOf("[ToDo]");
                while (hitline > -1)
                {
                    listNodeAndLineNo.Add(new NodeAndLineNo() { listNodeNo = new List<int>(listNodeNo2), LineNo = hitline });
                    hitline = sub[j].desctiption.IndexOf("[ToDo]",hitline+1);
                }
                SearchToDoTreeRecursive(listNodeNo2, sub[j], treeNode.Nodes[j]);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://www.web-dev-qa-db-ja.com/ja/c%23/treeview%E3%81%8C%E3%83%95%E3%82%A9%E3%83%BC%E3%82%AB%E3%82%B9%E3%81%95%E3%82%8C%E3%81%A6%E3%81%84%E3%81%AA%E3%81%84%E3%81%A8%E3%81%8D%E3%81%ABtreenode%E3%81%8Cbackcolor%E3%82%92%E9%81%B8%E6%8A%9E%E3%81%97%E3%81%9F/1043868512/"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_Validating(object sender, CancelEventArgs e)
        {
            //treeViewに何もないとき終了するとエラーが発生する
            if (treeView1.Nodes.Count != 0)
            {
                treeView1.SelectedNode.BackColor = SystemColors.Highlight;
                treeView1.SelectedNode.ForeColor = Color.White;
                previousSelectedNode = treeView1.SelectedNode;
            }
        }




    }
}
