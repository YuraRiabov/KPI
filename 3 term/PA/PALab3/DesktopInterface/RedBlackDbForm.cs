using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopInterface
{
    public partial class RedBlackDbForm : Form
    {
        private const string RedBlackDbLocation = "tree.json";
        private RedBlackDb _db;
        public RedBlackDbForm()
        {
            InitializeComponent();
            if (!File.Exists(RedBlackDbLocation))
            {
                _db = new RedBlackDb();
                for (int i = 0; i < 10000; i++)
                {
                    var entrance = new DbEntrance()
                    {
                        Key = i,
                        Value = i.ToString()
                    };
                    _db.Tree.Insert(entrance);
                }

                _db.CurrentIndex = 10000;
                Save();
            }
            else
            {
                Load();
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            var entrance = new DbEntrance()
            {
                Key = _db.CurrentIndex,
                Value = InsertInput.Text
            };
            _db.Tree.Insert(entrance);
            InsertResultLabel.Text = $"Successfully inserted, key: {_db.CurrentIndex}";
            _db.CurrentIndex++;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(FindInput.Text, out int key))
            {
                var (result, count) = _db.Tree.FindWithCount(new DbEntrance() { Key = key });
                if (result is null)
                {
                    FindResultLabel.Text = $"No value with such key, {count} comparisons";
                    return;
                }
                FindResultLabel.Text = $"{result.Value.Value}, {count} comparisons";
            }
            else
            {
                FindResultLabel.Text = "Invalid key, please enter a number";
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(FindInput.Text, out int key))
            {
                var toDelete = _db.Tree.Find(new DbEntrance() { Key = key });
                _db.Tree.Remove(toDelete);
            }
            else
            {
                FindResultLabel.Text = "Invalid key, please enter a number";
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var args = UpdateInput.Text.Split(", ");
            if (args.Length == 2 && int.TryParse(args[0], out int key))
            {
                var toUpdate = _db.Tree.Find(new DbEntrance() { Key = key });
                toUpdate.Value.Value = args[1];
            }
            else
            {
                UpdateInput.Text = "Invalid input";
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            using var fs = new FileStream(RedBlackDbLocation, FileMode.Create);
            JsonSerializer.Serialize(fs, _db);
        }

        private void Load()
        {
            using var fs = new FileStream(RedBlackDbLocation, FileMode.Open);
            _db = JsonSerializer.Deserialize<RedBlackDb>(fs);
            _db.Tree.RestoreConnections();
        }
    }
}
