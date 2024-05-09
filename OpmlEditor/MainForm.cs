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
        Opml mainOpml;

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

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://dobon.net/vb/dotnet/form/savefiledialog.html"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveSToolStripMenuItem_Click(object sender, EventArgs e)
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
        }

        // 変数
        List<int> listNodeId = new List<int>();

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
            foreach (var item in listNodeId)
            {
                txtDebug.AppendText(item.ToString() + " ");
            }

            txtDebug.AppendText(Environment.NewLine);
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

            cursor.text = e.Label;
            cursor.title = e.Label;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }
    }
}
