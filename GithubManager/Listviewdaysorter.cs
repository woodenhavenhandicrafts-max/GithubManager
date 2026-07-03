namespace GithubManager
{
    using System.Collections;
    using System.Windows.Forms;

    public class ListViewDaySorter : IComparer
    {
        private int _col;
        private SortOrder _order = SortOrder.Ascending;

        public void SetColumn(int col)
        {
            if (_col == col)
                _order = _order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            else
            {
                _col = col;
                _order = SortOrder.Descending; // most days first by default
            }
        }

        public int Compare(object x, object y)
        {
            var itemX = (ListViewItem)x;
            var itemY = (ListViewItem)y;

            int result;

            // Column 1 = days — stored as int in Tag, fall back to string compare
            if (_col == 1)
            {
                int daysX = itemX.Tag is int tx ? tx : int.MaxValue;
                int daysY = itemY.Tag is int ty ? ty : int.MaxValue;
                result = daysX.CompareTo(daysY);
            }
            else
            {
                result = string.Compare(
                    itemX.SubItems[_col].Text,
                    itemY.SubItems[_col].Text,
                    StringComparison.OrdinalIgnoreCase);
            }

            return _order == SortOrder.Ascending ? result : -result;
        }
    }
}